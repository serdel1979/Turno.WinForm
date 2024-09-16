namespace Turnos.Formularios.Nuevo
{
    partial class FormNuevoTurno
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            monthCalendar1 = new MonthCalendar();
            textDni = new TextBox();
            textNombre = new TextBox();
            textApellido = new TextBox();
            textObraSocial = new TextBox();
            textNumOS = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(119, 53);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 0;
            // 
            // textDni
            // 
            textDni.Location = new Point(123, 260);
            textDni.Name = "textDni";
            textDni.Size = new Size(244, 23);
            textDni.TabIndex = 1;
            textDni.KeyPress += textDni_KeyPress;
            // 
            // textNombre
            // 
            textNombre.Location = new Point(123, 322);
            textNombre.Name = "textNombre";
            textNombre.Size = new Size(309, 23);
            textNombre.TabIndex = 2;
            // 
            // textApellido
            // 
            textApellido.Location = new Point(123, 382);
            textApellido.Name = "textApellido";
            textApellido.Size = new Size(337, 23);
            textApellido.TabIndex = 3;
            // 
            // textObraSocial
            // 
            textObraSocial.Location = new Point(123, 446);
            textObraSocial.Name = "textObraSocial";
            textObraSocial.Size = new Size(445, 23);
            textObraSocial.TabIndex = 4;
            // 
            // textNumOS
            // 
            textNumOS.Location = new Point(123, 508);
            textNumOS.Name = "textNumOS";
            textNumOS.Size = new Size(445, 23);
            textNumOS.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(123, 242);
            label1.Name = "label1";
            label1.Size = new Size(27, 15);
            label1.TabIndex = 6;
            label1.Text = "DNI";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(123, 304);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 7;
            label2.Text = "NOMBRE";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(123, 364);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 8;
            label3.Text = "APELLIDO";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(123, 428);
            label4.Name = "label4";
            label4.Size = new Size(81, 15);
            label4.TabIndex = 9;
            label4.Text = "OBRA SOCIAL";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(123, 490);
            label5.Name = "label5";
            label5.Size = new Size(98, 15);
            label5.TabIndex = 10;
            label5.Text = "N° OBRA SOCIAL";
            // 
            // button1
            // 
            button1.Location = new Point(671, 569);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 11;
            button1.Text = "Confirmar";
            button1.UseVisualStyleBackColor = true;
            // 
            // FormNuevoTurno
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1214, 649);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textNumOS);
            Controls.Add(textObraSocial);
            Controls.Add(textApellido);
            Controls.Add(textNombre);
            Controls.Add(textDni);
            Controls.Add(monthCalendar1);
            Name = "FormNuevoTurno";
            Text = "Nuevo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MonthCalendar monthCalendar1;
        private TextBox textDni;
        private TextBox textNombre;
        private TextBox textApellido;
        private TextBox textObraSocial;
        private TextBox textNumOS;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button button1;
    }
}