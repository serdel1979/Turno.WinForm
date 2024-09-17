using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Turnos.Formularios.Nuevo;

namespace Turnos.Formularios
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        public int i = 0;
        private void btnAsignar_Click(object sender, EventArgs e)
        {
            FormNuevoTurno nuevoTurno = new FormNuevoTurno();
            nuevoTurno.Show();
        }

        private void FormPrincipal_Activated(object sender, EventArgs e)
        {
            i++;
            label1.Text = $"Cargando {i}";
        }
    }
}
