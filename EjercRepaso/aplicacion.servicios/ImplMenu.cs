using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercRepaso.aplicacion.servicios
{
    internal class ImplMenu:InterfazMenu
    {
        public void mostrarMenu()
        {
            Console.Write("\n\t\t----Menú----");
            Console.Write("\n\t\t1. Registro empleado");
            Console.Write("\n\t\t2. Modificación empleado");
            Console.Write("\n\t\t3. Exportar a fichero");
            Console.Write("\n\t\t0. Cerrar app");

        }
    }
}
