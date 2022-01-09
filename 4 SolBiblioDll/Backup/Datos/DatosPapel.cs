using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using EntidadesCOmpartidas;

namespace Datos
{
    public class DatosPapel
    {
        public static int Agregar(Papel pPapel)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            string oConsulta = "AgregarPublicacionPapel";
            SqlCommand oComando = new SqlCommand(oConsulta, oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            SqlParameter oIsbn = new SqlParameter("@Isbn", pPapel.ISBN);
            SqlParameter oTitulo = new SqlParameter("@Titulo", pPapel.Titulo);
            SqlParameter oPeso = new SqlParameter("@Peso", pPapel.Peso);
            int oAfectados = -1;
            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oIsbn);
            oComando.Parameters.Add(oTitulo);
            oComando.Parameters.Add(oPeso);
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


        public static List<Publicacion> ListarPublicacionesPapel()
        {
            int oIsbn, oPeso;
            string oTitulo;
            Papel p;
            List<Publicacion> oListaPublicaciones = new List<Publicacion>();
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            string oConsulta = "Exec ListarPublicacionesPapel";
            SqlCommand oComando = new SqlCommand(oConsulta, oConexion);
            SqlDataReader oReader;
            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                while (oReader.Read())
                {
                    oIsbn = (int)oReader["Isbn"];
                    oPeso = (int)oReader["Peso"];
                    oTitulo = (string)oReader["Titulo"];
                    p = new Papel(oIsbn, oTitulo, oPeso);
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

        public static Papel Buscar(int pIsbn)
        {
            int oIsbn, oPeso;
            string oTitulo;

            Papel p = null;
            List<Papel> oListaPublicaciones = new List<Papel>();
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            string oConsulta = "Exec BuscarPublicacionPapel " + pIsbn;
            SqlCommand oComando = new SqlCommand(oConsulta, oConexion);
            SqlDataReader oReader;
            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.Read())
                {
                    oIsbn = (int)oReader["Isbn"];
                    oPeso = (int)oReader["Peso"];
                    oTitulo = (string)oReader["Titulo"];
                    p = new Papel(oIsbn, oTitulo, oPeso);
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
    }

}
