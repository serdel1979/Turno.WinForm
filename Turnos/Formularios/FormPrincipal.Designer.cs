namespace Turnos.Formularios
{
    partial class FormPrincipal
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
            dataGridViewTurnos = new DataGridView();
            btnAsignar = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTurnos).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewTurnos
            // 
            dataGridViewTurnos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTurnos.Location = new Point(134, 254);
            dataGridViewTurnos.Name = "dataGridViewTurnos";
            dataGridViewTurnos.Size = new Size(928, 244);
            dataGridViewTurnos.TabIndex = 1;
            // 
            // btnAsignar
            // 
            btnAsignar.Location = new Point(134, 182);
            btnAsignar.Name = "btnAsignar";
            btnAsignar.Size = new Size(162, 30);
            btnAsignar.TabIndex = 2;
            btnAsignar.Text = "Nuevo";
            btnAsignar.UseVisualStyleBackColor = true;
            btnAsignar.Click += btnAsignar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(345, 190);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 3;
            label1.Text = "label1";
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1208, 602);
            Controls.Add(label1);
            Controls.Add(btnAsignar);
            Controls.Add(dataGridViewTurnos);
            Name = "FormPrincipal";
            Text = "FormPrincipal";
            Activated += FormPrincipal_Activated;
            ((System.ComponentModel.ISupportInitialize)dataGridViewTurnos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridViewTurnos;
        private Button btnAsignar;
        private Label label1;
    }
}