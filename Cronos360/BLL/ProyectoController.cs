using Cronos360.CENT;
using Cronos360.DAL;
using Cronos360.Data;
using DocumentFormat.OpenXml.ExtendedProperties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cronos360.BLL
{
    public class ProyectoController
    {

        public List<Proyectos> ObtenerProyectos()
        {
            ProyectoDAL proyectoDAL = new ProyectoDAL();
            return proyectoDAL.ObtenerProyectosActivos();
        }
        public int InsertarProyecto(Proyectos proyecto)
        {
            ProyectoDAL _proyectoDAL = new ProyectoDAL();
            return _proyectoDAL.AgregarProyecto(proyecto);
        }

    }

}

