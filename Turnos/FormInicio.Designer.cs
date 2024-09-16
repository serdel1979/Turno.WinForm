namespace Turnos
{
    partial class FormInicio
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnIngresar = new Button();
            btnSalir = new Button();
            textUser = new TextBox();
            textPassword = new TextBox();
            SuspendLayout();
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(150, 208);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(222, 23);
            btnIngresar.TabIndex = 0;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(150, 250);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(222, 23);
            btnSalir.TabIndex = 1;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // textUser
            // 
            textUser.Location = new Point(150, 73);
            textUser.Name = "textUser";
            textUser.Size = new Size(222, 23);
            textUser.TabIndex = 2;
            // 
            // textPassword
            // 
            textPassword.Location = new Point(150, 129);
            textPassword.Name = "textPassword";
            textPassword.PasswordChar = '*';
            textPassword.Size = new Size(222, 23);
            textPassword.TabIndex = 3;
            // 
            // FormInicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(527, 333);
            Controls.Add(textPassword);
            Controls.Add(textUser);
            Controls.Add(btnSalir);
            Controls.Add(btnIngresar);
            MaximizeBox = false;
            Name = "FormInicio";
            Text = "Inicio";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnIngresar;
        private Button btnSalir;
        private TextBox textUser;
        private TextBox textPassword;
    }
}
