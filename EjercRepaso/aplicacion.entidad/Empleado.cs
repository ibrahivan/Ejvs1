using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercRepaso.aplicacion.entidad
{
    internal class Empleado
    {
        //Atributos
        string nombre, apellido, dNI, titulacion;
        int dia, mes, anyo,nSS, nCuenta, nEmpleado;

        //Constructor vacio
        public Empleado()
        {
        }

        //Constructor
        public Empleado(string nombre, string apellido, string dNI, string titulacion, int dia, int mes, int anyo, int nSS, int nCuenta, int nEmpleado)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dNI = dNI;
            this.titulacion = titulacion;
            this.dia = dia;
            this.mes = mes;
            this.anyo = anyo;
            this.nSS = nSS;
            this.nCuenta = nCuenta;
            this.nEmpleado = nEmpleado;
        }

        //Getters y setters

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string DNI { get => dNI; set => dNI = value; }
        public string Titulacion { get => titulacion; set => titulacion = value; }
        public int Dia { get => dia; set => dia = value; }
        public int Mes { get => mes; set => mes = value; }
        public int Anyo { get => anyo; set => anyo = value; }
        public int NSS { get => nSS; set => nSS = value; }
        public int NCuenta { get => nCuenta; set => nCuenta = value; }
        public int NEmpleado { get => nEmpleado; set => nEmpleado = value; }

        


        

    }
}
