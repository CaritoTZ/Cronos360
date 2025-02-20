using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cronos360.CENT
{
    internal class Empleados
    {
        public int idEmpleado {  get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public string documento { get; set; }
        public int nro_legajo { get; set; }
        public int horas_requeridas { get; set; }
        public int horas_trabajadas { get; set; }
        public string usuario_sist { get; set; }
        public string estado { get; set; }
        public int id_proyecto { get; set; }
        public int idRol {  get; set; }

    }
}
