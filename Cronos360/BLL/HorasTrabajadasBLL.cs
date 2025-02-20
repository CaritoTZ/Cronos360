using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cronos360.CENT;
using Cronos360.DAL;
using System.Data;
using DocumentFormat.OpenXml.Bibliography;
using Cronos360.Data;

namespace Cronos360.BLL
{
    class HorasTrabajadasBLL
    {
        public List<HorasTrabajadas> RegistrarHoras()
        {
            HorasTrabajadasDAL HsTrabajadasDAL = new HorasTrabajadasDAL();
            return HsTrabajadasDAL.RegistrarHsTrabajadas();
        }
        public void InsertarHoras(HorasTrabajadas horasTrabajadas)
        {
            HorasTrabajadasDAL _horasTrabajadasDAL = new HorasTrabajadasDAL();
            _horasTrabajadasDAL.AgregarHoras(horasTrabajadas);
        }

    }
}

