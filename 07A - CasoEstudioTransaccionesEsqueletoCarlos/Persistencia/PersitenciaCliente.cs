using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;
using System.Data;
using System.Data.SqlClient;



namespace Persistencia
{
   internal class PersitenciaCliente:IPersistenciaCliente
    {
       public void Alta(EntidadesCompartidas.Cliente unCliente)
       {
           //throw new Exception("Hay que programar el ALta en la Persistencia");
           SqlConnection _cnn =new  SqlConnection(Conexion.MiConexion);
           SqlCommand _comando = new SqlCommand("AltaCliente", _cnn);
           _comando.CommandType = CommandType.StoredProcedure;
           _comando.Parameters.AddWithValue("@NumCli", unCliente.CodCLi);
           _comando.Parameters.AddWithValue("@NomCli", unCliente.NomCli);
           _comando.Parameters.AddWithValue("@DirCli", unCliente.DirCli);
           SqlParameter _ParmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
           _ParmRetorno.Direction = ParameterDirection.ReturnValue;
           _comando.Parameters.Add(_ParmRetorno);
           SqlTransaction _miTransaccion = null;//hay  que declarar el objeto de transaccion por fuera del try , porque lo necesito ver
           //tanto en la session del try como en la session del catch
           try
           {
               //conecto con bd
               _cnn.Open();
               //determino que voy a trabajar en una unica transaccion
               _miTransaccion = _cnn.BeginTransaction();//es como hacer un begin transaccion es como abrir una transaccion en la base de datos
               //solo que en el visual studio
               //Apartir de aca todo lo quiera hacer con la transaccion y atraves de la misma conexion tiene que defenderde este objeto transaction
               //el cual va tener que ser asignado a todos los comandos que se vallan a ejecutar sin importar que sea un executenonquery o un executeRead
               //ejecuto comando de alta del cliente en la transaccion
               _comando.Transaction = _miTransaccion;//asigna un comando de transaction, es la que permite avisarle al comando atravez de que transaccion se va a ejecutar
               _comando.ExecuteNonQuery();
               //verifico si ahy errores
               int _Codcli = Convert.ToInt32(_ParmRetorno.Value);
               if (_Codcli == -1)
                   throw new Exception("Cliente ya existente");
               else if (_Codcli == 0)
                   throw new Exception("Error no Especificado");
               //si llego aca es pq pude dar de alta al cliente
               //genero alta para sus telefonos
               foreach (EntidadesCompartidas.Telefono unTel in unCliente.LosTelefonos)
               {
                   PersitenciaTelefono.Alta(unTel, _Codcli, _miTransaccion);
               }
               //si llegue aca es pq no hubo problemas con los telefonos
               _miTransaccion.Commit();



           }
           catch(Exception ex)
           {
               _miTransaccion.Rollback();
               throw ex;
           }


       }


       public List<EntidadesCompartidas.Cliente> Listo()
       {
           SqlConnection _cnn = new SqlConnection(Conexion.MiConexion);

           SqlCommand _comando = new SqlCommand("ListoClientes", _cnn);
           _comando.CommandType = CommandType.StoredProcedure;

           List<EntidadesCompartidas.Cliente> _Lista = new List<EntidadesCompartidas.Cliente>();
           EntidadesCompartidas.Cliente _unCliente = null;

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
                       int _codigo = (int)_lector["CodCli"];
                       string _nombre = (string)_lector["NomCli"];
                       string _direccion = (string)_lector["DirCli"];
                       _unCliente = new EntidadesCompartidas.Cliente(_codigo, _nombre, _direccion);
                       Persistencia.PersitenciaTelefono.CargoTelCliente(_unCliente);

                       _Lista.Add(_unCliente);
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

           //retorno la lista de clientes
           return _Lista;
       }

       
       public EntidadesCompartidas.Cliente Busco(int CodCli)
       {
           SqlConnection _cnn = new SqlConnection(Conexion.MiConexion);

           SqlCommand _comando = new SqlCommand("BuscoCliente", _cnn);
           _comando.CommandType = CommandType.StoredProcedure;
           _comando.Parameters.AddWithValue("@CodCli", CodCli);

           EntidadesCompartidas.Cliente _unCliente = null;

           try
           {
               //me conecto
               _cnn.Open();

               //ejecuto consulta
               SqlDataReader _lector = _comando.ExecuteReader();

               //verifico si hay telefonos
               if (_lector.HasRows)
               {
                   _lector.Read();
                    int _codigo = (int)_lector["CodCli"];
                    string _nombre = (string)_lector["NomCli"];
                    string _direccion = (string)_lector["DirCli"];
                    _unCliente = new EntidadesCompartidas.Cliente(_codigo, _nombre, _direccion);
                    Persistencia.PersitenciaTelefono.CargoTelCliente(_unCliente);
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

           //retorno el cliente
           return _unCliente;
       }


       public void ModificarTelefonos(EntidadesCompartidas.Cliente unCliente)
       {
           SqlConnection _cnn = new SqlConnection(Conexion.MiConexion);
           //modificar los datos del cliente 

           //SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

           SqlCommand _comando = new SqlCommand("ClienteModificar", _cnn);
           _comando.CommandType = System.Data.CommandType.StoredProcedure;
           //_comando.Parameters.AddWithValue("@NumCli", unCliente.CodCLi);
           _comando.Parameters.AddWithValue("@NomCli", unCliente.NomCli);
           _comando.Parameters.AddWithValue("@DirCli", unCliente.DirCli);
           SqlParameter _retorno = new SqlParameter("@Retorno", System.Data.SqlDbType.Int);
           _retorno.Direction = System.Data.ParameterDirection.ReturnValue;
           _comando.Parameters.Add(_retorno);

           //try
           //{
       
           //}
           //catch (Exception ex)
           //{
           //    throw new Exception(ex.Message);
           //}
           SqlTransaction _miTransaccion=null;
           try
           {
               //conecto con bd
               _cnn.Open();
              
               //determino que voy a trabajar en una unica transaccion
               _miTransaccion = _cnn.BeginTransaction();
               //mandar a ejecutar la mod cliente
               //    _cnn.Open();
               _comando.Transaction = _miTransaccion;
               _comando.ExecuteNonQuery();
               if ((int)_retorno.Value == -1)
                   throw new Exception("El cliente no existe");
               else if ((int)_retorno.Value == -2)
                   throw new Exception("Error en Modificacion");
               //y preguntar si salio todo bien
               //elimino todos los telefonos anteriores
               PersitenciaTelefono.EliminarTelsCliente(unCliente, _miTransaccion);
               //genero alta para los telefonos nuevos
               foreach (EntidadesCompartidas.Telefono unTel in unCliente.LosTelefonos)
               {
                   PersitenciaTelefono.Alta(unTel, unCliente.CodCLi, _miTransaccion);
               }
               //si llegue aca es pq no hubo problemas con los telefonos
               _miTransaccion.Commit();
           }
           catch (Exception ex)
           {
               _miTransaccion.Rollback();
               throw ex;
 
           }
               
           //throw new Exception("Hay que programar la Modificacion de Telefonos en la Persistencia");
       }

    }
}
