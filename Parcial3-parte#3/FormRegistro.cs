using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Parcial3_parte_3
{
    public partial class FormRegistro : Form
    {
        private UsuarioService servicio = new UsuarioService();
        public FormRegistro()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Trim() == "" || txtNombre.Text.Trim() == "" || txtClave.Text == "")
            {
                MessageBox.Show("Completa todos los campos.");
                return;
            }

            try
            {
                // Genera el hash con BCrypt y lo guarda en la BD
                if (servicio.Registrar(txtUsuario.Text.Trim(), txtNombre.Text.Trim(), txtClave.Text))
                {
                    MessageBox.Show("Usuario registrado (contraseña guardada como hash BCrypt).");
                    Close();
                }
                else
                {
                    MessageBox.Show("Error: el usuario ya existe.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message);
            }

        }
    }
}
