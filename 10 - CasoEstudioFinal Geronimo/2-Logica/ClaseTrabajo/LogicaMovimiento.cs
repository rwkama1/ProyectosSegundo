using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaMovimiento:ILogicaMovimiento
    {
        //Singleton
        private static LogicaMovimiento _instancia = null;
        private LogicaMovimiento() { }
        public static LogicaMovimiento GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaMovimiento();
            return _instancia;
        }

        //operaciones
        public void MovimientoAlta(Movimiento pMovimiento) //Hay que recordar que tenemos dos tipos de reglas en nuestro sistema
            //1: LA REGLA SOBRE EL DATO que por ejemplo puede ser uqe una factura debe tener obligatoriamente lineas o por ejemplo que el monto de un movimiento bancario tiene que ser un monto positivo
            //2: REGLA SOBRE LAS ACCIONES, lo que se denomina la logica del negocio, por ejemplo que una factura tiene qu everficiar que todos sus articulos tengan stock para vender
        {
            //Verificacion de retiro en cuenta corriente por el minimo
            if ((pMovimiento.UnaCuenta is CuentaCorriente) && (pMovimiento.TipoMov=="R"))
            {
                double _cuenta = pMovimiento.UnaCuenta.SaldoCuenta - pMovimiento.MontoMov;
                if (_cuenta < ((CuentaCorriente)pMovimiento.UnaCuenta).MinimoCta)
                    throw new Exception("El retiro supera el monto minimo de la cuenta");
            }

            //Verificacion en cualer tipo de moviento para caja de ahorro. Solo gratis 25 movs por mes
            if (pMovimiento.UnaCuenta is CuentaCAhorro) 
            {
                if (((CuentaCAhorro)pMovimiento.UnaCuenta).MovsCta >=25)
                    throw new Exception("Supera la cantidad d Movimientos Gratis");
            }

            FabricaPersistencia.GetPersitenciaMovimiento().Alta(pMovimiento);
        }

        public List<EntidadesCompartidas.Movimiento> ListarTodosLosMovimientos()
        {
            return (Persistencia.FabricaPersistencia.GetPersitenciaMovimiento().ListarTodosLosMovimientos());
        }

    }
}
