using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia
{
    internal class PersistenciaPrestamo:IPersistenciaPrestamo
    {
        private static PersistenciaPrestamo _instancia = null;
        private PersistenciaPrestamo() { }
        public static PersistenciaPrestamo GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaPrestamo();
            return _instancia;
        }

        public Prestamo Buscar(string codigo)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            Prestamo _prestamo = null;

            SqlCommand _comando = new SqlCommand("BuscarPrestamo", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@codigo", codigo);

            try
            {
                _cnn.Open();
                SqlDataReader _lector = _comando.ExecuteReader();
                if (_lector.HasRows)
                {

                    _lector.Read();
                    Cliente cliente = PersistenciaCliente.GetInstancia().Buscar(Convert.ToInt32(_lector["NumCli"]));
                    _prestamo = new Prestamo(codigo, cliente, Convert.ToDouble(_lector["MontoPrestado"]), Convert.ToInt32(_lector["Cuotas"]));

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
            return _prestamo;
        }

        public void Alta(Prestamo prestamo)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand _comando = new SqlCommand("AltaPrestamo", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;

            _comando.Parameters.AddWithValue("@codigo", prestamo.Codigo);
            _comando.Parameters.AddWithValue("@numCli", prestamo.Cliente.NumCli);
            _comando.Parameters.AddWithValue("@montoPrestado", prestamo.Monto);
            _comando.Parameters.AddWithValue("@cuotas", prestamo.Cuotas);

            SqlParameter _retorno = new SqlParameter("@Retorno", System.Data.SqlDbType.Int);
            _retorno.Direction = System.Data.ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_retorno);

            try
            {
                _cnn.Open();
                _comando.ExecuteNonQuery();

                switch ((int)_retorno.Value)
                {
                    case -1:

                        throw new Exception("Ya existe un prestamo con la informacion ingresada");

                        break;

                    case -2:

                        throw new Exception("No existe el cliente ingresado");

                        break;

                    case -3:

                        throw new Exception("Ocurrio un error al intentar ingresar el prestamo al sistema");

                        break;
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
        }

        public void Modificacion(Prestamo prestamo)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand _comando = new SqlCommand("ModificarPrestamo", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;

            _comando.Parameters.AddWithValue("@codigo", prestamo.Codigo);
            _comando.Parameters.AddWithValue("@montoPrestado", prestamo.Monto);
            _comando.Parameters.AddWithValue("@cuotas", prestamo.Cuotas);

            SqlParameter _retorno = new SqlParameter("@Retorno", System.Data.SqlDbType.Int);
            _retorno.Direction = System.Data.ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_retorno);

            try
            {
                _cnn.Open();
                _comando.ExecuteNonQuery();

                switch ((int)_retorno.Value)
                {
                    case -1:

                        throw new Exception("No existe un prestamo con la informacion ingresada");

                        break;

                    case -2:

                        throw new Exception("Ocurrio un error al intentar modificar el prestamo en el sistema");

                        break;
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
        }

        public void Baja(Prestamo prestamo)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand _comando = new SqlCommand("BajaPrestamo", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@codigo", prestamo.Codigo);

            SqlParameter _retorno = new SqlParameter("@Retorno", System.Data.SqlDbType.Int);
            _retorno.Direction = System.Data.ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_retorno);

            try
            {
                _cnn.Open();
                _comando.ExecuteNonQuery();

                switch ((int)_retorno.Value)
                {
                    case -1:

                        throw new Exception("No existe un prestamo con la informacion ingresada");

                        break;

                    case -2:

                        throw new Exception("Ocurrio un error al intentar eliminar el prestamo en el sistema");

                        break;
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
        }

        public List<Prestamo> Listar()
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            Prestamo _prestamo = null;
            List<Prestamo> prestamos = new List<Prestamo>();

            SqlCommand _comando = new SqlCommand("ListarPrestamos", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                _cnn.Open();
                SqlDataReader _lector = _comando.ExecuteReader();

                Cliente cliente;

                if (_lector.HasRows)
                {
                    while (_lector.Read())
                    {
                        cliente = PersistenciaCliente.GetInstancia().Buscar(Convert.ToInt32(_lector["NumCli"]));
                        _prestamo = new Prestamo(_lector["Codigo"].ToString(), cliente, Convert.ToDouble(_lector["MontoPrestado"]), Convert.ToInt32(_lector["Cuotas"]));

                        prestamos.Add(_prestamo);
                    }
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
            return prestamos;
        }
    }

}
