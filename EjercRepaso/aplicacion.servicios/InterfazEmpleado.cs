using EjercRepaso.aplicacion.entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercRepaso.aplicacion.servicios
{
    internal interface InterfazEmpleado
    {
        // metodo que registra al empleado y guarda los datos en una lista
        List<Empleado> registroEmpleado(List<Empleado>listE);

        //metodo que modifica los datos del empleado y los guarda en una lista
        List<Empleado> modificarEmpleado(List<Empleado> listE);

        //metodo que exporta los datos a un fichero
        List<Empleado> exportarFich(List<Empleado> listE);

    }
}
