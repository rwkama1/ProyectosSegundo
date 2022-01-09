using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    internal class PersistenciaCliente:IPersistenciaCliente
    {
        //singleton
        private static PersistenciaCliente _instancia = null;
        private PersistenciaCliente() { }
        public static PersistenciaCliente GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaCliente();
            return _instancia;
        }

        //operaciones
        public void Alta(Cliente unCliente)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            
            SqlCommand _comando = new SqlCommand("ClienteAlta", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@NomCli", unCliente.NomCli);
            _comando.Parameters.AddWithValue("@DirCli", unCliente.DirCli);
            _comando.Parameters.AddWithValue("@UsuCli", unCliente.UsuCli);
            _comando.Parameters.AddWithValue("@PassCli", unCliente.PassCli);

            SqlParameter _ParmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _ParmRetorno.Direction = ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_ParmRetorno);

            SqlTransaction _miTransaccion = null;

            try
            {
                // conecto a la bd
                _cnn.Open();

                //determino que voy a trabajar en una unica transaccion
                _miTransaccion = _cnn.BeginTransaction();

                //ejecuto comando de alta del cliente en la transaccion
                _comando.Transaction = _miTransaccion;
                _comando.ExecuteNonQuery();

                //verifico si hay errores
                int _Codcli = Convert.ToInt32(_ParmRetorno.Value);
                if (_Codcli == -1)
                    throw new Exception("Cliente ya existente");
                else if (_Codcli == -2)
                    throw new Exception("Error en chequeos de datos en la tabla");

                //si llego aca es pq pude dar de alta al cliente

                //genero alta para sus telefonos
                foreach (EntidadesCompartidas.Telefono unTel in unCliente.ListaTelefonos)
                {
                    PersitenciaTelefono.Alta(unTel, _Codcli, _miTransaccion);
                }

                //si llegue aca es pq no hubo problemas con los telefonos
                _miTransaccion.Commit();
            }
            catch (Exception ex)
            {
                _miTransaccion.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                _cnn.Close();
            }
        }

        public void Baja(Cliente pCliente)
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
                    throw new Exception("Error en Eliminar los Telefonos del Cliente");
                else if ((int)_retorno.Value == -3)
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

        public void Modificar(Cliente unCliente)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand _comando = new SqlCommand("ClienteModificar", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@NumCli", unCliente.NumCli);
            _comando.Parameters.AddWithValue("@NomCli", unCliente.NomCli);
            _comando.Parameters.AddWithValue("@DirCli", unCliente.DirCli);
            _comando.Parameters.AddWithValue("@UsuCli", unCliente.UsuCli);
            _comando.Parameters.AddWithValue("@PassCli", unCliente.PassCli);

            SqlParameter _retorno = new SqlParameter("@Retorno", System.Data.SqlDbType.Int);
            _retorno.Direction = System.Data.ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_retorno);

            SqlTransaction _miTransaccion = null;

            try
            {
                // conecto a la bd
                _cnn.Open();

                //determino que voy a trabajar en una unica transaccion
                _miTransaccion = _cnn.BeginTransaction();

                //elimino todos los telefonos anteriores
                PersitenciaTelefono.EliminarTelsCliente(unCliente, _miTransaccion);

                //mando a modificar al cliente
                _comando.Transaction = _miTransaccion;
                _comando.ExecuteNonQuery();
                if ((int)_retorno.Value == -1)
                    throw new Exception("El cliente no existe");
                else if ((int)_retorno.Value == -2)
                    throw new Exception("Error en Modificacion del cliente");

              //si llego aca es pq pude modificar al cliente

               //genero alta para sus telefonos
               foreach (EntidadesCompartidas.Telefono unTel in unCliente.ListaTelefonos)
               {
                   PersitenciaTelefono.Alta(unTel, unCliente.NumCli, _miTransaccion);
               }

               //si llegue aca es pq no hubo problemas con los telefonos
               _miTransaccion.Commit();
           }
           catch (Exception ex)
           {
               _miTransaccion.Rollback();
               throw ex;
           }
            finally
            {
                _cnn.Close();
            }
        }
 
        public Cliente Buscar(int pNumCli)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            Cliente _unCliente = null;

            SqlCommand _comando = new SqlCommand("BuscarCliente", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@NumCli", pNumCli);

            try
            {
                _cnn.Open();
                SqlDataReader _lector = _comando.ExecuteReader();
                if (_lector.HasRows)
                {
                    _lector.Read();
                    _unCliente = new Cliente(pNumCli, (string)_lector["NomCLi"], (string)_lector["DirCli"], (string)_lector["UsuCli"], (string)_lector["PassCli"], Persistencia.PersitenciaTelefono.CargoTelCliente(pNumCli));
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

        public List<Cliente> Listar()
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            Cliente _unCliente = null;
            List<Cliente> _lista = new List<Cliente>();

            SqlCommand _comando = new SqlCommand("ListadoSoloClientes", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                _cnn.Open();
                SqlDataReader _lector = _comando.ExecuteReader();
                if (_lector.HasRows)
                {
                    while (_lector.Read())
                    {
                        _unCliente = new Cliente((int)_lector["NumCLi"], (string)_lector["NomCLi"], (string)_lector["DirCli"], (string)_lector["UsuCli"], (string)_lector["PassCli"], Persistencia.PersitenciaTelefono.CargoTelCliente((int)_lector["NumCLi"]));
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

        public List<EntidadesCompartidas.Cuenta> ListaCuentasDeCliente(EntidadesCompartidas.Cliente pCLiente)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            Cuenta _unaCta = null;
            List<Cuenta> _lista = new List<Cuenta>();

            SqlCommand _comando = new SqlCommand("ListadoCuentasCliente", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@NumCli", pCLiente.NumCli );

            try
            {
                _cnn.Open();
                SqlDataReader _lector = _comando.ExecuteReader();
                if (_lector.HasRows)
                {
                    while (_lector.Read())
                    {
                        _unaCta = new Cuenta((int)_lector["NumCta"], (PersistenciaCliente.GetInstancia().Buscar((int)_lector["NumCli"])), Convert.ToDouble(_lector["SaldoCta"]));
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
