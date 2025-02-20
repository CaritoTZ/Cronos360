using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cronos360.CENT
{
    public class Permiso
    {
        public int idPermiso {  get; set; }
        public int idRol {  get; set; }
        public string MenuDescripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
