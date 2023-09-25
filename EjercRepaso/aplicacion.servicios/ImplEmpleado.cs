using EjercRepaso.aplicacion.entidad;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
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
            Console.Write("\n\tIntroduzca el nombre del empleado: ");
            e.Nombre=Console.ReadLine();
            Console.Write("\n\tIntroduzca los apellidos del empleado: ");
            e.Apellido=Console.ReadLine();  
            Console.Write("\n\tIntroduzca el DNI del empleado: ");
            e.DNI = Console.ReadLine();
            e.Anyo = CapturaEntero("\n\tIntroduzca el año de nacimiento del empleado", 1940, 2023);
            e.Mes = CapturaEntero("\n\tIntroduzca el mes de nacimiento del empleado", 1, 12);
            if (e.Mes == 4 || e.Mes == 6 || e.Mes == 9 || e.Mes == 11)
                e.Dia = CapturaEntero("\n\tIntroduzca el dia de nacimiento del empleado", 1, 30);
            else if (e.Mes == 2)
                e.Dia = CapturaEntero("\n\tIntroduzca el dia de nacimiento del empleado", 1, 28);
            else
                e.Dia = CapturaEntero("\n\tIntroduzca el dia de nacimiento del empleado", 1, 31); ;
            Console.Write("\n\tIntroduzca la titulacion del empleado: ");
            e.Titulacion = Console.ReadLine();
            e.NSS = CapturaEntero("\n\tIntroduzca el numero de seguridad social del empleado", 1, 10000000);
            e.NCuenta = CapturaEntero("\n\tIntroduzca el numero de cuenta del empleado", 1, 1000000); 
            //Genero el id
            e.Id = generarId();
            //Añado el empleado a la lista
            listE.Add(e);
            Console.Clear();
            Console.WriteLine("\n\tEmpleado registrado con exito su nº identificatorio es: " + e.Id);
            return listE;
        }

        

        public List<Empleado> modificarEmpleado(List<Empleado> listE)
        {
            Empleado e= new Empleado();
            //Mostramos los empleados
            mostrarEmpleados(listE);
            //Preguntamos que empleado y que dato desea cambiar
            bool p = PreguntaSiNo("\tDesea modificar algun empleado");
            
            while (p==true)
            {
                Console.Write("\n\t¿Que empleado desea modificar? seleccionar por id: ");
                int id = Convert.ToInt32(Console.ReadLine());
                bool existe = false;
                for (int i = 0; i < listE.Count; i++)
                {
                    if (id == listE[i].Id)
                    {
                        Console.WriteLine("Has seleccionado el empleado: " + listE[i].Nombre);
                        Console.Clear();
                        
                        mostrarOpciones();
                        int opcion = CapturaEntero("\n\n\t¿Que dato desea cambiar?", 0, 9);
                        Console.Clear();
                        switch (opcion)
                        {
                            
                            case 1:
                                Console.WriteLine("\n\tIntroduzca nuevo nombre: ");
                                listE[i].Nombre = Console.ReadLine();
                                break;
                            case 2:
                                Console.Write("\n\tIntroduzca nuevos apellidos: ");
                                listE[i].Apellido = Console.ReadLine();
                                break;
                            case 3:
                                Console.Write("\n\tIntroduzca nuevo DNI: ");
                                listE[i].DNI = Console.ReadLine();
                                break;
                            case 4:
                                listE[i].Anyo = CapturaEntero("\n\tIntroduzca nuevo año: ", 1940, 2023);
                                break;
                            case 5:
                                listE[i].Mes = CapturaEntero("\n\tIntroduzca nuevo mes: ", 1, 12);
                                break;
                            case 6:
                                if (e.Mes == 4 || e.Mes == 6 || e.Mes == 9 || e.Mes == 11)
                                    listE[i].Dia = CapturaEntero("\n\tIntroduzca nuevo dia: ", 1, 30);
                                
                                else if (e.Mes == 2)
                                    listE[i].Dia = CapturaEntero("\n\tIntroduzca nuevo dia: ", 1, 28);
                                
                                else
                                    listE[i].Dia = CapturaEntero("\n\tIntroduzca nuevo dia: ", 1, 31);
                                break;
                            case 7:
                                Console.Write("\n\tIntroduzca nueva titulación: ");
                                listE[i].Titulacion = Console.ReadLine();
                                break;
                            case 8:                                
                                listE[i].NSS = CapturaEntero("\n\tIntroduzca nuevo nº ss: ", 1, 10000000);
                                break;
                            case 9:
                                listE[i].NCuenta = CapturaEntero("\n\tIntroduzca nuevo nº de cuenta: ", 1, 1000000);
                                break;
                            case 0:
                                break;


                        
                        }
                        existe = true;
                        break;

                    }

                }
                if(!existe)
                    Console.WriteLine("\n\t**Empleado no existe**");
                p = PreguntaSiNo("\t¿Desea modificar algun dato?");
            }
            
            

            return listE;
        }


        public void exportarFich(List<Empleado> listE)
        {
            int opcion = CapturaEntero("Desea exportar un empleado (Opción 1) o todos los empleados (Opción 2)", 1, 2);
           
                Console.Clear();
                switch (opcion)
                {
                    case 1:

                        mostrarEmpleados(listE);
                        Console.Write("\n\t¿Que empleado desea exportar al fichero? seleccionar por id: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        bool existe = false;
                        for (int j = 0; j < listE.Count; j++)
                        {
                            if (id == listE[j].Id)
                             {
                                StreamWriter sw = File.CreateText(@"C:\\zDatosPruebas\\empleados.txt");
                                sw.WriteLine("\n\t\t Id empleado || Nombre  ||  Apellidos  ||    DNI    || Fecha nacimiento  || Titulacion ");
                                sw.WriteLine("\n\t\t      {0} {1,12} {2,13} {3,12} {4,9}/{5}/{6} {7,19} ", listE[j].Id, listE[j].Nombre, listE[j].Apellido, listE[j].DNI, listE[j].Dia, listE[j].Mes, listE[j].Anyo, listE[j].Titulacion);
                                sw.Close();
                                Console.WriteLine("\tEmpleado " + listE[j].Nombre + " exportado correctamente.");
                                existe = true;
                                break;
                            }
                       
                        }
                        if(!existe)
                        Console.WriteLine("\n\t**Empleado no existe**");

                    break;
                    case 2:
                        StreamWriter sw1 = File.CreateText(@"C:\\zDatosPruebas\\empleados.txt");
                        sw1.WriteLine("\n\t\t Id empleado || Nombre  ||  Apellidos  ||    DNI    || Fecha nacimiento  || Titulacion ");
                        for (int k = 0; k < listE.Count; k++)
                        {
                            sw1.WriteLine("\n\t\t      {0} {1,12} {2,13} {3,12} {4,9}/{5}/{6} {7,19} ", listE[k].Id, listE[k].Nombre, listE[k].Apellido, listE[k].DNI, listE[k].Dia, listE[k].Mes, listE[k].Anyo, listE[k].Titulacion);
                        }
                        sw1.Close();
                        Console.WriteLine("Todos los empleados exportados correctamente.");
                        break;


                }
                
            
            
        }



        //CapturaEntero para los errores de solo introducir numeros
        public int CapturaEntero(string mensaje, int min, int max)
        {
            int valor = 0;
            bool esCorrecto = false;
            do
            {
                Console.Write("{0} ({1}..{2}): ", mensaje, min, max);
                esCorrecto = Int32.TryParse(Console.ReadLine(), out valor);//el usuario escribe algo y pulsa INTRO
                if (!esCorrecto || valor < min || valor > max)
                {
                    Console.WriteLine(" \t** NO VALIDO. ({0} a {1})  ** ", min, max);
                    Console.Beep(400, 400);
                }
            }
            while (!esCorrecto || valor < min || valor > max);

            return valor;
        }

        public int generarId()
        {
            // Crear una instancia de la clase Random
            Random random = new Random();

            // Generar un número aleatorio como ID
            int id = random.Next(1, 100); // Esto generará un número entre 1 y 101

            return id;

        }

        public  bool PreguntaSiNo(string p)
        {
            bool respuesta = false;
            char tecla;
            bool error = false;
            // Hacemos la pregunta
            do
            {
                error = false;
                Console.Write("\n\n{0} (s=Sí; n=No): ", p);
                // Capturamos la respuesta (una pulsación)
                tecla = (Console.ReadKey()).KeyChar;
                if (tecla == 's' || tecla == 'S')
                    respuesta = true;
                else if (tecla == 'n' || tecla == 'N')
                    respuesta = false;
                else
                {
                    Console.Write("\n\n\t** Error: por favor, responde s o n **");
                    error = true;
                }
            } while (error);
            return respuesta;
        }

        public void mostrarOpciones()
        {
            
            Console.Write("\n\t\t1. Nombre.");
            Console.Write("\n\t\t2. Apellidos.");
            Console.Write("\n\t\t3. DNI.");
            Console.Write("\n\t\t4. Dia nacimiento.");
            Console.Write("\n\t\t5. Mes nacimiento.");
            Console.Write("\n\t\t6. Año nacimiento.");
            Console.Write("\n\t\t7. Titulación .");
            Console.Write("\n\t\t8. Número SS.");
            Console.Write("\n\t\t9. Número de cuenta.");
            Console.Write("\n\t\t0. Salir.");

        }

        public void mostrarEmpleados(List<Empleado>listE)
        {
            Console.WriteLine("\n\t\t Id empleado || Nombre  ||  Apellidos  ||    DNI    || Fecha nacimiento  || Titulacion  ||  Nº Seg Social  || Nº Cuenta  ");
            for (int i = 0; i < listE.Count; i++)
            {
                Console.WriteLine("\n\t\t      {0} {1,12} {2,13} {3,12} {4,9}/{5}/{6} {7,19} {8,15} {9,15}", listE[i].Id, listE[i].Nombre, listE[i].Apellido, listE[i].DNI, listE[i].Dia, listE[i].Mes, listE[i].Anyo, listE[i].Titulacion, listE[i].NSS, listE[i].NCuenta);

            }
        }
    }
}
