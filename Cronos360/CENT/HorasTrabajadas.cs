using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace Cronos360.CENT
{
    public class HorasTrabajadas
    {
        public int Id_horas { get; set; }
        public int id_proyecto { get; set; }
        public int id_empleado { get; set; }
        public DateTime FechaDiaria { get; set; }
        public decimal Horas { get; set; }
        public string comentarios { get; set; }
    }
}
