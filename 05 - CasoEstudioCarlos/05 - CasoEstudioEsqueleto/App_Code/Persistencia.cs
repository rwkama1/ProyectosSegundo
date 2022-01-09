using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

    public static class Persistencia
    {
        //atributo
        private static string _cnn = "Data Source=.; Initial Catalog = Ventas; Integrated Security = true";

        //Operaciones
        public static void EliminarArt(int Codigo)
        {
            SqlConnection oConexion = new SqlConnection(_cnn);
            SqlCommand oComando = new SqlCommand("BajaArticulo", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter _codigo = new SqlParameter("@cod", Codigo);
            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            int oAfectados = -1;

            oComando.Parameters.Add(_codigo);
            oComando.Parameters.Add(_Retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("El articulo no existia - No se borro");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }
  
        public static List<Articulo> ListarArt()
        {
            int _codigo;
            string _nombre;
            decimal _precio;
            List<Articulo> _Lista = new List<Articulo>();
            SqlConnection _Conexion = new SqlConnection(_cnn);
            SqlCommand _Comando = new SqlCommand("Exec ListoArticulo", _Conexion);
            SqlDataReader _Reader;
            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();
                while (_Reader.Read())
                {
                    _codigo = (int)_Reader["CodArt"];
                    _nombre = (string)_Reader["NomArt"];
                    _precio = (decimal)_Reader["PreArt"];
                    Articulo a = new Articulo(_codigo, _nombre, _precio, BuscarFam((int)_Reader["CodFam"]));
                    _Lista.Add(a);
                }
                _Reader.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                _Conexion.Close();
            }
            return _Lista;
        }

        public static List<Articulo> ListarArtFam(int pCodigo)
        {
            int _codigo;
            string _nombre;
            decimal _precio;
            List<Articulo> _Lista = new List<Articulo>();

            //objetos necesarios para acceder a la bd
            SqlConnection _Conexion = new SqlConnection(_cnn);
            SqlCommand _Comando = new SqlCommand("Exec ListoArticuloXfamilia " + pCodigo, _Conexion);
            SqlDataReader _Reader;

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();
                while (_Reader.Read())
                {
                    _codigo = (int)_Reader["CodArt"];
                    _nombre = (string)_Reader["NomArt"];
                    _precio = (decimal)_Reader["PreArt"];
                    Articulo a = new Articulo(_codigo, _nombre, _precio, BuscarFam((int)_Reader["CodFam"]));
                    _Lista.Add(a);
                }
                _Reader.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                _Conexion.Close();
            }
            return _Lista;
        }

        public static Familia BuscarFam(int pCodigo)
        {
            string _nombre;
            Familia _familia = null;

            SqlConnection _Conexion = new SqlConnection(_cnn);
            SqlCommand _Comando = new SqlCommand("Exec BuscoFamilia " + pCodigo, _Conexion);
            SqlDataReader _Reader;
            
            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();
                if (_Reader.Read())
                {
                    _nombre = (string)_Reader["NomFam"];
                    _familia = new Familia(pCodigo, _nombre);
                }
                _Reader.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                _Conexion.Close();
            }
            return _familia;
        }

        public static int EliminarFam(int pCodigo)
        {
            SqlConnection oConexion = new SqlConnection(_cnn);
            SqlCommand oComando = new SqlCommand("Delete From Familias Where CodFam = " + pCodigo, oConexion);

            int oAfectados = -1;

            try
            {
                oConexion.Open();
                oAfectados = oComando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                oConexion.Close();
            }

            return oAfectados;
        }

        public static List<Familia> ListarFam()
        {
            int _codigo;
            string _nombre;
            List<Familia> _Lista = new List<Familia>();
            SqlConnection _Conexion = new SqlConnection(_cnn);
            SqlCommand _Comando = new SqlCommand("Exec ListoFamilia", _Conexion);
            SqlDataReader _Reader;
            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();
                while (_Reader.Read())
                {
                    _codigo = (int)_Reader["CodFam"];
                    _nombre = (string)_Reader["NomFam"];
                    Familia a = new Familia(_codigo, _nombre);
                    _Lista.Add(a);
                }
                _Reader.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                _Conexion.Close();
            }
            return _Lista;
        }

    }

