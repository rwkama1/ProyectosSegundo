using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using EntidadesCOmpartidas;


namespace Datos
{
    public class DatosPrestamos
    {
        public static int Agregar(Prestamo pPrestamo)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            string oConsulta = "AgregarPrestamo";
            SqlCommand oComando = new SqlCommand(oConsulta, oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            int oAfectados = -1;
            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            oComando.Parameters.AddWithValue("@Fecha", pPrestamo.Fecha);
            oComando.Parameters.AddWithValue("@Dias", pPrestamo.Dias);
            oComando.Parameters.AddWithValue("@Nombre", pPrestamo.NombreUsuario);
            oComando.Parameters.AddWithValue("@Isbn", pPrestamo.Pub.ISBN);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
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

        public static List<Prestamo> ListarPrestamos()
        {
            int oNumero, oDias, oISBN;
            DateTime oFecha;
            string oNombre;
            bool oDevuelto;
            Publicacion oPublicacion;
            Prestamo p;
            List<Prestamo> oListaPrestamos = new List<Prestamo>();
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            string oConsulta = "Exec ListarPrestamos";
            SqlCommand oComando = new SqlCommand(oConsulta, oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                while (oReader.Read())
                {
                    oNumero = (int)oReader["Numero"];
                    oFecha = (DateTime)oReader["Fecha"];
                    oDias = (int)oReader["Dias"];
                    oDevuelto = (bool)oReader["Devuelto"];
                    oNombre = (string)oReader["Nombre"];
                    oISBN = (int)oReader["Isbn"];
                    oPublicacion = DatosPapel.Buscar(oISBN);
                    if (oPublicacion == null)
                        oPublicacion = DatosDigital.Buscar(oISBN);
                    p = new Prestamo(oNumero, oFecha, oDias, oNombre, oDevuelto, oPublicacion);
                    oListaPrestamos.Add(p);
                }
                return oListaPrestamos;
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

        public static Prestamo Buscar(int pNumero)
        {
            int oNumero = 0, oDias = 0, oISBN = 0;
            DateTime oFecha = DateTime.Now;
            string oNombre = "";
            bool oDevuelto = true;
            Publicacion oPublicacion = null;
            Prestamo p = null;
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            string oConsulta = "Exec BuscarPrestamo " + pNumero;
            SqlCommand oComando = new SqlCommand(oConsulta, oConexion);
            SqlDataReader oReader;
            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.Read())
                {
                    oNumero = (int)oReader["Numero"];
                    oFecha = (DateTime)oReader["Fecha"];
                    oDias = (int)oReader["Dias"];
                    oDevuelto = (bool)oReader["Devuelto"];
                    oNombre = (string)oReader["Nombre"];
                    oISBN = (int)oReader["Isbn"];
                    oPublicacion = DatosPapel.Buscar(oISBN);
                    if (oPublicacion == null)
                        oPublicacion = DatosDigital.Buscar(oISBN);
                    p = new Prestamo(oNumero, oFecha, oDias, oNombre, oDevuelto, oPublicacion);
                }
                return p;
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

        public static List<Prestamo> ListarPrestamosNoDevueltos()
        {
            int oNumero, oDias, oISBN;
            DateTime oFecha;
            string oNombre;
            bool oDevuelto;
            Publicacion oPublicacion;
            Prestamo p;
            List<Prestamo> oListaPrestamos = new List<Prestamo>();
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            string oConsulta = "Exec ListarPrestamosNoDevueltos ";
            SqlCommand oComando = new SqlCommand(oConsulta, oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                while (oReader.Read())
                {
                    oNumero = (int)oReader["Numero"];
                    oFecha = (DateTime)oReader["Fecha"];
                    oDias = (int)oReader["Dias"];
                    oDevuelto = (bool)oReader["Devuelto"];
                    oNombre = (string)oReader["Nombre"];
                    oISBN = (int)oReader["Isbn"];
                    oPublicacion = DatosPapel.Buscar(oISBN);
                    if (oPublicacion == null)
                        oPublicacion = DatosDigital.Buscar(oISBN);
                    p = new Prestamo(oNumero, oFecha, oDias, oNombre, oDevuelto, oPublicacion);
                    oListaPrestamos.Add(p);
                }
                return oListaPrestamos;
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

        public static List<Prestamo> ListarPrestamosVencidos(DateTime pFechaVencimiento)
        {
            int oNumero, oDias, oISBN;
            DateTime oFecha;
            string oNombre;
            bool oDevuelto;
            Publicacion oPublicacion;
            Prestamo p;
            List<Prestamo> oListaPrestamos = new List<Prestamo>();
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            string oConsulta = "Exec ListarPrestamosVencidos " + pFechaVencimiento.ToString("yyyyMMdd");
            SqlCommand oComando = new SqlCommand(oConsulta, oConexion);
            SqlDataReader oReader;
            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                while (oReader.Read())
                {
                    oNumero = (int)oReader["Numero"];
                    oFecha = (DateTime)oReader["Fecha"];
                    oDias = (int)oReader["Dias"];
                    oDevuelto = (bool)oReader["Devuelto"];
                    oNombre = (string)oReader["Nombre"];
                    oISBN = (int)oReader["Isbn"];
                    oPublicacion = DatosPapel.Buscar(oISBN);
                    if (oPublicacion == null)
                        oPublicacion = DatosDigital.Buscar(oISBN);
                    p = new Prestamo(oNumero, oFecha, oDias, oNombre, oDevuelto, oPublicacion);
                    oListaPrestamos.Add(p);
                }
                return oListaPrestamos;
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

        public static int Devolver(int pNumero)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            int oAfectados = -1;
            string oConsulta = "DevolverPrestamo";
            SqlCommand oComando = new SqlCommand(oConsulta, oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            SqlParameter oNumero = new SqlParameter("@Numero", pNumero);
            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oNumero);
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                return oAfectados;
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
    }

}
