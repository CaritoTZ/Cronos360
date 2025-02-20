using System;

namespace Cronos360.DAL
{
    public class Registro
    {
        public string EmpleadoId { get; internal set; }
        public int HorasTrabajadas { get; internal set; }
        public DateTime Fecha { get; internal set; }
    }
    //public class Proyecto
    //{
    //    public int ProyectoId { get; set; } // Identificador único del proyecto.
    //    public string Nombre { get; set; } // Nombre del proyecto.
    //    public DateTime FechaInicio { get; set; } // Fecha de inicio del proyecto.
    //    public DateTime FechaFin { get; set; } // Fecha de finalización estimada del proyecto.
    //    public string Estado { get; set; } // Estado actual del proyecto (Activo, Cerrado, etc.).

    //    // Constructor opcional para inicializar el objeto.
    //    //public Proyecto() { }

    //    //public Proyecto(int proyectoId, string nombre, DateTime fechaInicio, DateTime fechaFin, string estado)
    //    //{
    //    //    ProyectoId = proyectoId;
    //    //    Nombre = nombre;
    //    //    FechaInicio = fechaInicio;
    //    //    FechaFin = fechaFin;
    //    //    Estado = estado;
    //    //}
    //}
}