using Cronos360.BLL;
using Cronos360.CENT;
using Cronos360.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cronos360.CP
{
    public partial class frmLogin : Form
    {
        
        private UsuariosBLL usuariosBLL = new UsuariosBLL();
        public frmLogin()
        {
            InitializeComponent();
            btnLider.Enabled = false;
            btnTeamDevs.Enabled = false;
        }
        
        
        private void btnLider_Click(object sender, EventArgs e)
        {
            frmCargaExcel frmExcel = new frmCargaExcel();
            frmExcel.Show();
            this.Hide();

            frmExcel.FormClosing += frm_closing;
            txtUsuario.Text = "";
            txtContraseña.Text= "";
        }

        
        private void btnTeamDevs_Click(object sender, EventArgs e)
        {
            frmCargaHoras frmHoras = new frmCargaHoras();
            frmHoras.Show();
            this.Hide();

            frmHoras.FormClosing += frm_closing;
            txtUsuario.Text = "";
            txtContraseña.Text = "";
        }

        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;
            int idRol = 0;

            try
            {
                UsuariosDAL usuarioDal = new UsuariosDAL();
                idRol = usuarioDal.ObtenerRolUsuario(usuario, contraseña);

                if(idRol == 1)
                {
                    btnLider.Enabled = true;
                    btnTeamDevs.Enabled = true;
                    MessageBox.Show("Bienvenido, Administrador");
                }
                else if (idRol == 2)
                {
                    btnLider.Enabled = false;
                    btnTeamDevs.Enabled = true;
                    MessageBox.Show("Bienvenido, Miembro del Equipo de Desarrollo.");
                }
                else if (idRol == 3)
                {
                    btnLider.Enabled = true;
                    btnTeamDevs.Enabled = false;
                    MessageBox.Show("Bienvenido, Líder de Equipo");
                }
                else
                    if (usuario != contraseña)
                    {
                        MessageBox.Show("Usuario y/o contraseña incorrecto. Por favor, vuelva a intentar.");
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener datos: "+ ex.Message);
            }
            
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

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.Text = ""; // Oculta el nombre
            this.ControlBox = true; // Oculta los botones de minimizar, maximizar y cerrar
            //this.FormBorderStyle = FormBorderStyle.None; // Elimina la barra de título

        }
    }
}
