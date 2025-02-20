using Cronos360.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cronos360
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCargarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                //string filePath = txtRutaArchivo.Text;

                // Llamar al método de la capa BLL
                var bll = new CargaExcelBLL();
                //bll.ProcesarCarga(filePath);

                MessageBox.Show("Archivo procesado exitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }
        }

        private void btnCargaExcel_Click(object sender, EventArgs e)
        {
            try
            {
                //string filePath = txtRutaArchivo.Text;

                // Llamar al método de la capa BLL
                var bll = new CargaExcelBLL();
                //bll.ProcesarCarga(filePath);

                MessageBox.Show("Archivo procesado exitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }
        }
    }
}
