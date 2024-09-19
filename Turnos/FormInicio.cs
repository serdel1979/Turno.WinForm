using Microsoft.Data.Sqlite;
using Turnos.Formularios;
using Turnos.Infra;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Turnos
{
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            verificaUsuario();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                verificaUsuario();
            }
        }

        private void verificaUsuario()
        {
            string username = textUser.Text;
            string password = textPassword.Text;

            DatabaseHelper.VerificarCredenciales(username, password);

            bool esValido = DatabaseHelper.VerificarCredenciales(username, password);

            if (esValido)
            {

                FormPrincipal formPrincipal = new FormPrincipal();
                formPrincipal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }
    }
}
