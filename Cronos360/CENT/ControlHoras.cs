using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cronos360.CENT
{
    class ControlHoras
    {
        public int id {  get; set; }
        public int id_empleado { get; set; }
        public string usuario { get; set; }
        public int trabajado { get; set; }
        public int licencias { get; set; }
        public string observaciones { get; set; }
        public int requerido_practia { get; set; }
        public int diferencia_hs { get; set; }
        public int diferencia_dias {  get; set; }
        public string estado { get; set; }
        public int dias_habiles { get; set; }
        public int horas_habiles { get; set; }
        public DateTime fecha_consulta {  get; set; }
        public Proyectos oId_proyecto { get; set; }
        public string user_identif {  get; set; }
        public DateTime periodo { get; set; }
    }
}
