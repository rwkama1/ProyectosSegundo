using System;
using System.Collections.Generic;
using System.Text;


using System.Configuration;
using EntidadesCOmpartidas;
using Datos;

namespace Logica
{
    public class LogicaPrestamos
    {
        public static bool Agregar(Prestamo pPrestamo)
        {
            return DatosPrestamos.Agregar(pPrestamo) > 0;
        }

        public static Prestamo Buscar(int pNumero)
        {

            return DatosPrestamos.Buscar(pNumero);
        }


        public static bool Devolver(int pNumero)
        {

            return DatosPrestamos.Devolver(pNumero) == 1;
        }


        public static List<Prestamo> ListarPrestamosVencidos()
        {
            return DatosPrestamos.ListarPrestamosVencidos(DateTime.Now);
        }

        public static List<Prestamo> ListarPrestamos()
        {
            return DatosPrestamos.ListarPrestamos();
        }


        public static List<Prestamo> ListarPrestamosNoDevueltos()
        {
            return DatosPrestamos.ListarPrestamosNoDevueltos();
        }
    }

}
