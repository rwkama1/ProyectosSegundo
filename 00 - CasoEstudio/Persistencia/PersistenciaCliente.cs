using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using System.Data.SqlClient;

namespace Persistencia
{
    public class PersistenciaCliente
    {

        public static void ClienteAlta(Cliente pCliente)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            
            SqlCommand _comando = new SqlCommand("ClienteAlta", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@NomCli", pCliente.NomCli);
            _comando.Parameters.AddWithValue("@DirCli", pCliente.DirCli);
 
            try
            {
                _cnn.Open();
                int _afectados = _comando.ExecuteNonQuery();
                if (_afectados == 0)
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

        public static void ClienteBaja(Cliente pCliente)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand _comando = new SqlCommand("ClienteBaja", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@NumCli", pCliente.NumCli);
            SqlParameter _retorno = new SqlParameter("@Retorno", System.Data.SqlDbType.Int);
            _retorno.Direction = System.Data.ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_retorno);

            try
            {
                _cnn.Open();
                _comando.ExecuteNonQuery();
                if ((int)_retorno.Value == -1)
                    throw new Exception("El cliente tiene cuenta asociada");
                else if ((int)_retorno.Value == -2)
                    throw new Exception("Error en Baja");
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

        public static void ClienteModificar(Cliente pCliente)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand _comando = new SqlCommand("ClienteModificar", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@NumCli", pCliente.NumCli);
            _comando.Parameters.AddWithValue("@NomCli", pCliente.NomCli);
            _comando.Parameters.AddWithValue("@DirCli", pCliente.DirCli);
            SqlParameter _retorno = new SqlParameter("@Retorno", System.Data.SqlDbType.Int);
            _retorno.Direction = System.Data.ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_retorno);

            try
            {
                _cnn.Open();
                _comando.ExecuteNonQuery();
                if ((int)_retorno.Value == -1)
                    throw new Exception("El cliente no existe");
                else if ((int)_retorno.Value == -2)
                    throw new Exception("Error en Modificacion");
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

        public static Cliente ClienteBuscar(int pNumCli)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            Cliente _unCliente = null;

            SqlCommand _comando = new SqlCommand("ClienteBuscar", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@NumCli", pNumCli);

            try
            {
                _cnn.Open();
                SqlDataReader _lector = _comando.ExecuteReader();
                if (_lector.HasRows)
                {
                    _lector.Read();
                    _unCliente = new Cliente(pNumCli, (string)_lector["NomCLi"],  (string)_lector["DirCli"]);
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
            return _unCliente;
        }

        public static List<Cliente> ClienteListar()
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            Cliente _unCliente = null;
            List<Cliente> _lista = new List<Cliente>();

            SqlCommand _comando = new SqlCommand("ClienteListado", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                _cnn.Open();
                SqlDataReader _lector = _comando.ExecuteReader();
                if (_lector.HasRows)
                {
                    while (_lector.Read())
                    {
                        _unCliente = new Cliente((int)_lector["NumCli"], (string)_lector["NomCLi"], (string)_lector["DirCli"]);
                        _lista.Add(_unCliente);
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
