using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using System.Data.SqlClient;


namespace Persistencia
{
   public class PersistenciaMovimiento
    {

       public static void MovimientosAlta(Movimiento pMovimiento)
       {
           SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

           SqlCommand _comando = new SqlCommand("MovimientosAlta", _cnn);
           _comando.CommandType = System.Data.CommandType.StoredProcedure;
           _comando.Parameters.AddWithValue("@NumCta", pMovimiento.UnaCuenta.NumCta);
           _comando.Parameters.AddWithValue("@MontoMov", pMovimiento.MontoMov);
           _comando.Parameters.AddWithValue("@TipoMov", pMovimiento.TipoMov);
           _comando.Parameters.AddWithValue("@SaldoCta", pMovimiento.UnaCuenta.SaldoCuenta);
           SqlParameter _retorno = new SqlParameter("@Retorno", System.Data.SqlDbType.Int);
           _retorno.Direction = System.Data.ParameterDirection.ReturnValue;
           _comando.Parameters.Add(_retorno);

           try
           {
               _cnn.Open();
               _comando.ExecuteNonQuery();
               if ((int)_retorno.Value == -1)
                   throw new Exception("No existe la cuenta");
               else if ((int)_retorno.Value == -2)
                   throw new Exception("Error en Alta Movimiento");
               else if ((int)_retorno.Value == -3)
                   throw new Exception("Error en Modificacion de saldo");
 
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

    }
}
