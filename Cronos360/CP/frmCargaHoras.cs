using Cronos360.BLL;
using Cronos360.CENT;
using Cronos360.DAL;
using Cronos360.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cronos360.CP
{
    public partial class frmCargaHoras : Form
    {                                               
        private ProyectoController _proyectoController = new ProyectoController();
        private HorasTrabajadasBLL _horasTrabajadasBLL = new HorasTrabajadasBLL();

        public frmCargaHoras()
        {
            try
            {
                InitializeComponent();
                CargarProyectos(); // Si hay error aquí, mostrará un mensaje
                cmbProyectos.SelectedIndexChanged += cmbProyectos_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el formulario: " + ex.Message);
            }
        }

        
        private void CargarProyectos()
        {
            List<Proyectos> proyectos = _proyectoController.ObtenerProyectos();
            cmbProyectos.DataSource = proyectos;
            cmbProyectos.ValueMember = "id_proyecto";
            cmbProyectos.DisplayMember = "nombre";

            

            if (cmbProyectos.SelectedItem != null)
            {
                Proyectos proyectoSeleccionado = (Proyectos)cmbProyectos.SelectedItem;
                txtDescripcion.Text = proyectoSeleccionado.descripcion;
                txtEstado.Text = proyectoSeleccionado.estado;
            }

        }
        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            if (cmbProyectos.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un proyecto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(numHoras.Value > 8)
            {
                MessageBox.Show("Cargue horas válidas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int horas = (int)numHoras.Value;
            Proyectos proyectoSeleccionado = (Proyectos)cmbProyectos.SelectedItem;
            string proyecto = proyectoSeleccionado.nombre;
            string descripcion = proyectoSeleccionado.descripcion;
            string estado = proyectoSeleccionado.estado;

            DateTime fechaDiaria = dtpFechaCarga.Value;
            DateTime fechaInicio = dtpFecha.Value;
            DateTime fechaFin = dptFecha2.Value;

            HorasTrabajadas horasTrabajadas = new HorasTrabajadas()
            {
                Id_horas = horas,
                FechaDiaria = fechaDiaria
            };

            // Verificar si el DataGridView tiene columnas, si no, agregarlas.
            if (dgvProyectos.Columns.Count == 0)
            {
                dgvProyectos.Columns.Add("nombre", "Nombre del Proyecto");
                dgvProyectos.Columns.Add("descripcion", "Descripción");
                dgvProyectos.Columns.Add("estado", "Estado");
                dgvProyectos.Columns.Add("horas_trabajadas", "Horas trabajadas");
                dgvProyectos.Columns.Add("fecha_diaria", "Fecha Carga");
                dgvProyectos.Columns.Add("fecha_inicio", "Fecha Inicio");
                dgvProyectos.Columns.Add("fecha_fin", "Fecha Fin");
            }

            // Agregar filas
            _horasTrabajadasBLL.RegistrarHoras();
            dgvProyectos.Rows.Add(proyectoSeleccionado.nombre, proyectoSeleccionado.descripcion, proyectoSeleccionado.estado, horas, fechaDiaria.ToShortDateString(), fechaInicio.ToShortDateString(), fechaFin.ToShortDateString());

            try
            {
                _horasTrabajadasBLL.RegistrarHoras();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al cargar el formulario: " + ex.Message);
            }
        }
        private void GuardarRegistros()
        {
            foreach (DataGridViewRow row in dgvProyectos.Rows)
            {
                if (!row.IsNewRow) // Evita filas vacías
                {
                    // Obtener valores de la fila
                    string nombreProyecto = row.Cells["nombre"].Value.ToString();
                    string descripcion = row.Cells["descripcion"].Value.ToString();
                    string estado = row.Cells["estado"].Value.ToString();
                    int horas = Convert.ToInt32(row.Cells["horas_trabajadas"].Value);
                    DateTime fechaDiaria = Convert.ToDateTime(row.Cells["fecha_diaria"].Value);
                    DateTime fechaInicio = Convert.ToDateTime(row.Cells["fecha_inicio"].Value);
                    DateTime fechaFin = Convert.ToDateTime(row.Cells["fecha_fin"].Value);

                    // Crear objeto Proyecto
                    Proyectos proyecto = new Proyectos()
                    {
                        nombre = nombreProyecto,
                        descripcion = descripcion,
                        estado = estado,
                        fecha_inicio = fechaInicio,
                        fecha_fin = fechaFin
                        
                        
                    };

                    // Guardar Proyecto en la base de datos y obtener el ID
                     int id_proyecto = _proyectoController.InsertarProyecto(proyecto);

                    // Crear objeto HorasTrabajadas
                    HorasTrabajadas horasTrabajadas = new HorasTrabajadas()
                    {
                        id_proyecto = id_proyecto,
                        Horas = horas,
                        FechaDiaria = fechaDiaria
                        
                    };

                    // Guardar HorasTrabajadas en la base de datos
                    _horasTrabajadasBLL.InsertarHoras(horasTrabajadas);
                }
            }

            MessageBox.Show("Registros guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpiar la grilla después de guardar (opcional)
            dgvProyectos.Rows.Clear();
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarRegistros();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Confirmar si el usuario realmente quiere salir
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas salir?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Cerrar la aplicación
                Application.Exit();
            }
        }
        private void Limpiar()
        {
            numHoras.Text = "";
            dtpFechaCarga.Text = "";
            dtpFecha.Text = "";
            dptFecha2.Text = "";
            cmbProyectos.SelectedIndex = 0;
        }

        private void cmbProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProyectos.SelectedItem != null)
            {
                Proyectos proyectoSeleccionado = (Proyectos)cmbProyectos.SelectedItem;
                txtDescripcion.Text = proyectoSeleccionado.descripcion;
                txtEstado.Text = proyectoSeleccionado.estado;
            }
        }

        private void frmCargaHoras_Load(object sender, EventArgs e)
        {
            this.Text = ""; // Oculta el nombre
            this.ControlBox = true; // Oculta los botones de minimizar, maximizar y cerrar
            //this.FormBorderStyle = FormBorderStyle.None; // Elimina la barra de título
        }

    }
}
