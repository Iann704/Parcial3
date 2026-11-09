using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Parcial3_parte_3
{
    public partial class FormLogin : Form
    {
        private UsuarioService servicio = new UsuarioService();
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                string? nombre = servicio.Login(txtUsuario.Text.Trim(), txtClave.Text);

                if (nombre != null)
                    MessageBox.Show($"Acceso exitoso. Bienvenido, {nombre}.", "Login",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Login",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtClave.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message);
            }

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            new FormRegistro().ShowDialog();
        }
    }
}
