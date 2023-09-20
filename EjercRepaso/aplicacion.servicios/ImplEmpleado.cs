using EjercRepaso.aplicacion.entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EjercRepaso.aplicacion.servicios
{
    internal class ImplEmpleado : InterfazEmpleado
    {

        public List<Empleado> registroEmpleado(List<Empleado> listE)
        {
            Empleado e = new Empleado();

            //Capturo todos los datos
            Console.WriteLine("\n\tIntroduzca el nombre del empleado: ");
            e.Nombre=Console.ReadLine();
            Console.WriteLine("\n\tIntroduzca los apellidos del empleado: ");
            e.Apellido=Console.ReadLine();  
            Console.WriteLine("\n\tIntroduzca el DNI del empleado: ");
            e.DNI = Console.ReadLine();
            e.Anyo = CapturaEntero("\n\tIntroduzca el año de nacimiento del empleado: ", 1940, 2023);
            e.Mes = CapturaEntero("\n\tIntroduzca el mes de nacimiento del empleado: ", 1, 12);
            if (e.Mes == 4 || e.Mes == 6 || e.Mes == 9 || e.Mes == 11)
                e.Dia = CapturaEntero("\n\tIntroduzca el dia de nacimiento del empleado: ", 1, 30);
            else if (e.Mes == 2)
                e.Dia = CapturaEntero("\n\tIntroduzca el dia de nacimiento del empleado: ", 1, 28);
            else
                e.Dia = CapturaEntero("\n\tIntroduzca el dia de nacimiento del empleado: ", 1, 31); ;
            Console.WriteLine("\n\tIntroduzca la titulacion del empleado: ");
            e.Titulacion = Console.ReadLine();
            e.NSS = CapturaEntero("\n\tIntroduzca numero de seguridad social del empleado: ", 1, 10000000);
            e.Anyo = CapturaEntero("\n\tIntroduzcanumero de cuenta del empleado: ", 1, 1000000);

            return listE;
        }

        public List<Empleado> exportarFich(List<Empleado> listE)
        {
            throw new NotImplementedException();
        }

        public List<Empleado> modificarEmpleado(List<Empleado> listE)
        {
            throw new NotImplementedException();
        }

        //CapturaEntero para los errores de solo introducir numeros
        public static int CapturaEntero(string mensaje, int min, int max)
        {
            int valor = 0;
            bool esCorrecto = false;
            do
            {
                Console.Write("{0} ({1}..{2}): ", mensaje, min, max);
                esCorrecto = Int32.TryParse(Console.ReadLine(), out valor);//el usuario escribe algo y pulsa INTRO
                if (!esCorrecto || valor < min || valor > max)
                {
                    Console.WriteLine(" ** NO VALIDO. ({0} a {1})  ** Pulsa Intro", min, max);
                    Console.Beep(400, 400);
                }
            }
            while (!esCorrecto || valor < min || valor > max);

            return valor;
        }


    }
}
