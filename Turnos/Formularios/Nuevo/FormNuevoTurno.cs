using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Turnos.Infra;

namespace Turnos.Formularios.Nuevo
{
    public partial class FormNuevoTurno : Form
    {
        public FormNuevoTurno()
        {
            InitializeComponent();
        }

        private void textDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                BuscarPaciente();
            }
        }
        private void BuscarPaciente()
        {
            string dni = textDni.Text;
            var paciente = DatabaseHelper.BuscarPaciente(dni);

            if (paciente.nombre != null)
            {
                textNombre.Text = paciente.nombre;
                textApellido.Text = paciente.apellido;
                textObraSocial.Text = paciente.obraSocial;
                textNumOS.Text = paciente.numeroObraSocial;
            }
            else
            {
                textNombre.Clear();
                textApellido.Clear();
                textObraSocial.Clear();
                textNumOS.Clear();
                MessageBox.Show("Paciente no encontrado");
            }
        }



    }
}
