using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using EntidadesCOmpartidas;

namespace Datos
{
    public class DatosDigital
    {
        public static int Agregar(Digital pDigital)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            string oConsulta = "AgregarPublicacionDigital";
            SqlCommand oComando = new SqlCommand(oConsulta, oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oIsbn = new SqlParameter("@Isbn", pDigital.ISBN);
            SqlParameter oTitulo = new SqlParameter("@Titulo", pDigital.Titulo);
            SqlParameter oFormato = new SqlParameter("@Formato", pDigital.Formato);
            SqlParameter oProtegida = new SqlParameter("@Protegida", pDigital.Protegida);
            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            int oAfectados = -1;

            oComando.Parameters.Add(oIsbn);
            oComando.Parameters.Add(oTitulo);
            oComando.Parameters.Add(oFormato);
            oComando.Parameters.Add(oProtegida);
            oComando.Parameters.Add(oRetorno);

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

        public static Digital Buscar(int pIsbn)
        {
            int oIsbn;
            string oTitulo, oFormato;
            bool oProtegida;
            Digital p = null;
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            string oConsulta = "Exec BuscarPublicacionDigital " + pIsbn;
            SqlCommand oComando = new SqlCommand(oConsulta, oConexion);

            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.Read())
                {
                    oIsbn = (int)oReader["Isbn"];
                    oTitulo = (string)oReader["Titulo"];
                    oFormato = (string)oReader["Formato"];
                    oProtegida = (bool)oReader["Protegida"];
                    p = new Digital(oIsbn, oTitulo, oFormato, oProtegida);
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

        public static List<Publicacion> ListarPublicacionesDigital()
        {
            int oIsbn;
            Boolean oProtegida;
            string oTitulo, oFormato;
            List<Publicacion> oListaPublicaciones = new List<Publicacion>();
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            string oConsulta = "Exec ListarPublicacionesDigital";
            SqlCommand oComando = new SqlCommand(oConsulta, oConexion);
            SqlDataReader oReader;
            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                while (oReader.Read())
                {
                    oIsbn = (int)oReader["Isbn"];
                    oTitulo = (string)oReader["Titulo"];
                    oFormato = (string)oReader["Formato"];
                    oProtegida = (bool)oReader["Protegida"];
                    Digital p = new Digital(oIsbn, oTitulo, oFormato, oProtegida);
                    oListaPublicaciones.Add(p);
                }
                return oListaPublicaciones;
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
