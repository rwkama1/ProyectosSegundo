using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data;
using System.Data.SqlClient;



namespace Persistencia
{
   internal class PersitenciaTelefono
    {
       internal static void Alta(EntidadesCompartidas.Telefono unTelefono, int pCodCli, SqlTransaction _pTransaccion)
       {
           //throw new Exception("Hay que programar el ALta de Telefono en la Persistencia");
           SqlCommand _comando = new SqlCommand("AltaTelefono", _pTransaccion.Connection);//cuando vamos a crear el sqlcommand para dar el alta un dato dependiente
           //hay que recordar, que no podemos usar una nueva coleccion hay que usar la que ya teniamos y como nos pasan la transaccion por parametro, obtenemos el objeto de conexion
           //atravez del objeto transaction
           //adentro del try no voy a tener que conectarme porque ya estoy conectado
           //en las dependencias siempre hay que rehusar conexion y transaccion
           _comando.CommandType = CommandType.StoredProcedure;
           _comando.Parameters.AddWithValue("@CodCli", pCodCli);
           _comando.Parameters.AddWithValue("@NumTel", unTelefono.UnTelefono);
           SqlParameter _ParmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
           _comando.Parameters.Add(_ParmRetorno);
           try
           {
               //determino que debo trabajar con la misma transaccion
               _comando.Transaction = _pTransaccion;//recordar que como el comando usa la misma conexion,tambien debe ser asignado a la transaccion
               //ejecuto comando
               _comando.ExecuteNonQuery();
               //verificio si hay errores
               int retorno = Convert.ToInt32(_ParmRetorno.Value);
               if (retorno == -1)
                   throw new Exception("Cliente Invalido");
               else if (retorno == 0)
                   throw new Exception("Error no Especificado");
           }
           catch (Exception ex)
           {
               throw ex;
           }

       }


       internal static void CargoTelCliente(EntidadesCompartidas.Cliente unCliente)
       {
           SqlConnection _cnn = new SqlConnection(Conexion.MiConexion);

           SqlCommand _comando = new SqlCommand("TelefonoDeUnCliente", _cnn);
           _comando.CommandType = CommandType.StoredProcedure;
           _comando.Parameters.AddWithValue("@CodCLi", unCliente.CodCLi);

           try
           {
               //me conecto
               _cnn.Open();

               //ejecuto consulta
               SqlDataReader _lector = _comando.ExecuteReader();

               //verifico si hay telefonos
               if (_lector.HasRows)
               {
                   while (_lector.Read())
                   {
                       unCliente.AgregarTelefono((string)_lector["NumTel"]);
                   }
               }

               _lector.Close();
           }
           catch (Exception ex)
           {
               throw ex;
           }
           finally
           {
               _cnn.Close();
           }
       }


       internal static void EliminarTelsCliente(EntidadesCompartidas.Cliente unCliente, SqlTransaction _pTransaccion)
       {
           SqlCommand _comando = new SqlCommand("EliminoTelsDeCliente", _pTransaccion.Connection);
           _comando.CommandType = CommandType.StoredProcedure;
           _comando.Parameters.AddWithValue("@CodCli", unCliente.CodCLi);
           SqlParameter _ParmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
           _ParmRetorno.Direction = ParameterDirection.ReturnValue;
           _comando.Parameters.Add(_ParmRetorno);


           try
           {
               //determino que debo trabajar con la misma transaccion
               _comando.Transaction = _pTransaccion;

               //ejecuto comando
               _comando.ExecuteNonQuery();
          
           }
           catch (Exception ex)
           {
               throw ex; 
           }
       }

    }
}
