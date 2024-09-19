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

            //horaTurno.Format = DateTimePickerFormat.Custom;
            //horaTurno.CustomFormat = "HH:mm";
            //horaTurno.ShowUpDown = true;  // Muestra el control tipo spinner

            dataGridTurnosHoy.Columns.Add("hora", "Hora");
            dataGridTurnosHoy.Columns.Add("nombre", "Nombre");
            dataGridTurnosHoy.Columns.Add("apellido", "Apellido");

            VerTurnosHoy();

        }


        private void textDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                BuscarPaciente();
            }
        }


        private void toUpper(TextBox textBox)
        {
            textBox.Text = textBox.Text.ToUpper();
            textBox.SelectionStart = textBox.Text.Length;
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
            }
        }

        private void monthCalendarTurno_DateChanged(object sender, DateRangeEventArgs e)
        {
            VerTurnosHoy();
        }


        private void VerTurnosHoy()
        {
            DateTime fechaSeleccionada = monthCalendarTurno.SelectionStart; // Obtener la fecha seleccionada
            label7.Text = $"Turnos asignados para el {fechaSeleccionada.Day} del mes {fechaSeleccionada.Month} del {fechaSeleccionada.Year}";
            MostrarTurnosDelDia(fechaSeleccionada); // Llamar a la función que consulta y muestra los turnos

        }

        private void MostrarTurnosDelDia(DateTime fecha)
        {
            // Limpiar el DataGridView
            dataGridTurnosHoy.Rows.Clear();

            // Llamar a la función que obtiene los turnos de la base de datos
            DataTable turnos = DatabaseHelper.ObtenerTurnosPorFecha(fecha);

            // Llenar el DataGridView con los resultados obtenidos
            foreach (DataRow row in turnos.Rows)
            {
                dataGridTurnosHoy.Rows.Add(row["hora"], row["nombre"], row["apellido"]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textNombre.Text == "" || textApellido.Text == "" || textObraSocial.Text == "" || textNumOS.Text == "" || comboHora.Text == "")
            {
                MessageBox.Show("No puede guardar datos en blanco", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string dni = textDni.Text;
            var paciente = DatabaseHelper.BuscarPaciente(dni);

            // Si el paciente no existe, lo guardamos primero
            if (paciente.nombre == null)
            {
                DatabaseHelper.GuardarNuevoPaciente(dni, textNombre.Text, textApellido.Text, textObraSocial.Text, textNumOS.Text);
                paciente = DatabaseHelper.BuscarPaciente(dni); // Buscar nuevamente para obtener el ID recién creado
            }

            // Obtener la fecha y la hora seleccionada
            DateTime fechaSeleccionada = monthCalendarTurno.SelectionStart;
            // DateTime horaSeleccionada = horaTurno.Value;

            DateTime horaSeleccionada = DateTime.ParseExact(comboHora.Text, "HH:mm", null);

            // Combinar la fecha y la hora
            DateTime fechaHoraTurno = new DateTime(fechaSeleccionada.Year, fechaSeleccionada.Month, fechaSeleccionada.Day, horaSeleccionada.Hour, horaSeleccionada.Minute, 0);

            // Guardar el turno con el id del paciente y la fecha/hora seleccionada
            DatabaseHelper.GuardarTurno(paciente.id, fechaHoraTurno);

            VerTurnosHoy();

            MessageBox.Show("Turno confirmado para el paciente: " + paciente.nombre + " " + paciente.apellido, "", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }

        private void textDni_TextChanged(object sender, EventArgs e)
        {
            toUpper(sender as TextBox);
        }

        private void textNombre_TextChanged(object sender, EventArgs e)
        {
            toUpper(sender as TextBox);
        }

        private void textApellido_TextChanged(object sender, EventArgs e)
        {
            toUpper(sender as TextBox);
        }

        private void textObraSocial_TextChanged(object sender, EventArgs e)
        {
            toUpper(sender as TextBox);
        }

        private void textNumOS_TextChanged(object sender, EventArgs e)
        {
            toUpper(sender as TextBox);
        }
    }
}
