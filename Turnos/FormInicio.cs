using Microsoft.Data.Sqlite;
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

            string username = textUser.Text;
            string password = textPassword.Text;

            DatabaseHelper.VerificarCredenciales(username, password);

            bool esValido = DatabaseHelper.VerificarCredenciales(username, password);

            if (esValido)
            {
                MessageBox.Show("Inicio de sesión exitoso");
                // Abrir el formulario principal
                //   FormPrincipal formPrincipal = new FormPrincipal();
                //   formPrincipal.Show();
                //   this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
