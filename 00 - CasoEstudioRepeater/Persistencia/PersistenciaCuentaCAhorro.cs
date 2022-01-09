using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using System.Data.SqlClient;


namespace Persistencia
{
   public class PersistenciaCuentaCAhorro
    {

       public static void Alta(CuentaCAhorro pCuenta)
       {
           SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

           SqlCommand _comando = new SqlCommand("CuentaCAhorroAlta", _cnn);
           _comando.CommandType = System.Data.CommandType.StoredProcedure;
           _comando.Parameters.AddWithValue("@NumCli", pCuenta.UnCliente.NumCli);
           _comando.Parameters.AddWithValue("@MovsCta", pCuenta.MovsCta);
           _comando.Parameters.AddWithValue("@CostoMovCta", pCuenta.NumCta);
           SqlParameter _retorno = new SqlParameter("@Retorno", System.Data.SqlDbType.Int);
           _retorno.Direction = System.Data.ParameterDirection.ReturnValue;
           _comando.Parameters.Add(_retorno);

           try
           {
               _cnn.Open();
               _comando.ExecuteNonQuery();
               if ((int)_retorno.Value == -1)
                   throw new Exception("El cliente no existe - No se creo cuenta");
               else if ((int)_retorno.Value == -2)
                   throw new Exception("Error en Alta");
           }
           catch (Exception ex)
           {
               throw new Exception(ex.Message);
           }
           finally
           {
               _cnn.Close();
           }

       }

       public static void Baja(CuentaCAhorro pCuenta)
       {
           SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

           SqlCommand _comando = new SqlCommand("CuentaCAhorroBaja", _cnn);
           _comando.CommandType = System.Data.CommandType.StoredProcedure;
           _comando.Parameters.AddWithValue("@NumCta", pCuenta.NumCta);
           SqlParameter _retorno = new SqlParameter("@Retorno", System.Data.SqlDbType.Int);
           _retorno.Direction = System.Data.ParameterDirection.ReturnValue;
           _comando.Parameters.Add(_retorno);

           try
           {
               _cnn.Open();
               _comando.ExecuteNonQuery();
               if ((int)_retorno.Value == -1)
                   throw new Exception("La cuenta tiene Movimientos asignados");
               else if ((int)_retorno.Value == -2)
                   throw new Exception("Error en Borrar Cuenta Corriente");
               else if ((int)_retorno.Value == -3)
                   throw new Exception("Error en Borrar Cuenta");

           }
           catch (Exception ex)
           {
               throw new Exception(ex.Message);
           }
           finally
           {
               _cnn.Close();
           }
       }

       public static CuentaCAhorro Buscar(int pNumCta)
       {
           SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
           CuentaCAhorro _unaCta = null;

           SqlCommand _comando = new SqlCommand("CuentaCAhorroBuscar", _cnn);
           _comando.CommandType = System.Data.CommandType.StoredProcedure;
           _comando.Parameters.AddWithValue("@NumCta", pNumCta);

           try
           {
               _cnn.Open();
               SqlDataReader _lector = _comando.ExecuteReader();
               if (_lector.HasRows)
               {
                   _lector.Read();
                   _unaCta = new CuentaCAhorro((int)_lector["NumCta"], (PersistenciaCliente.ClienteBuscar((int)_lector["NumCli"])), Convert.ToDouble(_lector["SaldoCta"]), Convert.ToInt32(_lector["MovsCta"]), Convert.ToDouble(_lector["CostoMovCta"]));
               }
           }
           catch (Exception ex)
           {
               throw new Exception(ex.Message);
           }
           finally
           {
               _cnn.Close();
           }
           return _unaCta;
       }

       public static List<CuentaCAhorro> CuentaCAhorroListado()
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            CuentaCAhorro _unaCta = null;
            List<CuentaCAhorro> _lista = new List<CuentaCAhorro>();

            SqlCommand _comando = new SqlCommand("CuentaCAhorroListado", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                _cnn.Open();
                SqlDataReader _lector = _comando.ExecuteReader();
                if (_lector.HasRows)
                {
                    while (_lector.Read())
                    {
                        _unaCta = new CuentaCAhorro((int)_lector["NumCta"], PersistenciaCliente.ClienteBuscar((int)_lector["NumCli"]), Convert.ToDouble(_lector["SaldoCta"]), (int)_lector["MovsCta"], Convert.ToDouble(_lector["CostoMovCta"]));
                        _lista.Add(_unaCta);
                    }
                }
                _lector.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _cnn.Close();
            }
            return _lista;
        }
 
    }
}
