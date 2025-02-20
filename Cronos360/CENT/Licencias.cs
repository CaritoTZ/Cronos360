using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cronos360.CENT
{
    class Licencias
    {
        public int id_licencia {  get; set; }
        public DateTime fehca_inicio { get; set; }
        public DateTime fecha_fin {  get; set; }
        public string motivo { get; set; }
        public Empleados oid_empleado { get; set; }

    }
}
