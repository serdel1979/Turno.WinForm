using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Turnos.Formularios.Nuevo;
using Turnos.Infra;

namespace Turnos.Formularios
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();

            dataGridViewTurnos.Columns.Add("hora", "Hora");
            dataGridViewTurnos.Columns.Add("nombre", "Nombre");
            dataGridViewTurnos.Columns.Add("apellido", "Apellido");
            dataGridViewTurnos.Columns.Add("obra_social", "Obra Social");
            dataGridViewTurnos.Columns.Add("numero_obra_social", "N° Obra Social");
        }

        public int i = 0;
        private void btnAsignar_Click(object sender, EventArgs e)
        {
            FormNuevoTurno nuevoTurno = new FormNuevoTurno();
            nuevoTurno.Show();
        }

        private void FormPrincipal_Activated(object sender, EventArgs e)
        {
            VerTurnosHoy();
        }

        private void monthCalendarTurnosHoy_DateChanged(object sender, DateRangeEventArgs e)
        {
            VerTurnosHoy();
        }

        private void VerTurnosHoy()
        {
            DateTime fechaSeleccionada = monthCalendarTurnosHoy.SelectionStart; // Obtener la fecha seleccionada
            label1.Text = $"Turnos asignados para el {fechaSeleccionada.Day} del mes {fechaSeleccionada.Month} del {fechaSeleccionada.Year}";
            MostrarTurnosDelDia(fechaSeleccionada); // Llamar a la función que consulta y muestra los turnos
        }

        private void MostrarTurnosDelDia(DateTime fecha)
        {
            // Limpiar el DataGridView
            dataGridViewTurnos.Rows.Clear();

            // Llamar a la función que obtiene los turnos de la base de datos
            DataTable turnos = DatabaseHelper.ObtenerTurnosPorFecha(fecha);

            // Llenar el DataGridView con los resultados obtenidos
            foreach (DataRow row in turnos.Rows)
            {
                dataGridViewTurnos.Rows.Add(row["hora"], row["nombre"], row["apellido"], row["obra_social"], row["numero_obra_social"]);
            }
        }
    }
}
