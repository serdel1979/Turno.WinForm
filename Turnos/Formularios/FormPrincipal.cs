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
        
        private void btnAsignar_Click(object sender, EventArgs e)
        {
            FormNuevoTurno nuevoTurno = new FormNuevoTurno();
            nuevoTurno.Show();
        }
    }
}
