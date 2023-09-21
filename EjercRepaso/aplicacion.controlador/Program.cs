using EjercRepaso.aplicacion.entidad;
using EjercRepaso.aplicacion.servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercRepaso
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //instanciamos las diferentes clases para poder hacer uso de los metodos
            ImplEmpleado intE = new ImplEmpleado();
            ImplMenu intM = new ImplMenu();
            List<Empleado> listE = new List<Empleado>();
            int opcion;
            do
            {
                intM.mostrarMenu(); //mostramos menu
                opcion = Console.ReadKey().KeyChar - '0';
                //control de errores
                while (opcion < 0 || opcion > 3)
                {
                    Console.WriteLine("\n\t\t\t**ERROR**");
                    Console.Write("\t\tIntroduce una opcion: ");
                    opcion = Console.ReadKey().KeyChar - '0';
                }
                Console.Clear();
                switch (opcion)
                {

                    case 1:

                        Console.WriteLine("\n\t\t----Registro empleado----");
                        listE = intE.registroEmpleado(listE); //nos devuelve una lista actualizada
                        break;
                    case 2:
                        Console.WriteLine("\n\t\t----Modificar empleado----");
                        listE = intE.modificarEmpleado(listE); //nos devuelve una lista actualizada
                        break;

                    case 3:
                        Console.WriteLine("\n\t\t----Exportar a fichero----");
                        intE.exportarFich(listE); //exporta la lista al fichero
                        break;


                }
                if (opcion != 0)
                {
                    Console.Write("\n\n\tPulsa una tecla para volver al menú... ");
                    Console.ReadKey();
                    Console.Clear();
                }

            } while (opcion != 0);


            Console.WriteLine("\n\tSaliendo de la aplicacion  \n\tPulse cualquier tecla para cerrar el programa");
            Console.ReadKey();
        }
    }
}
    

