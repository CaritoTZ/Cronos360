using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cronos360.CENT
{
    public class Proyectos
    {
        public int id_proyecto {  get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin {  get; set; }
        public string estado {  get; set; }
        public string cliente { get; set; }
        public int id_lider { get; set; }

    }
}
