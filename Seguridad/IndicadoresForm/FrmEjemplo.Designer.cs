namespace IndicadoresForm
{
    partial class FrmEjemplo
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
            this.dwvEjemplo = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.Funcionario_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Funcionario_nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNombre = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dwvEjemplo)).BeginInit();
            this.SuspendLayout();
            // 
            // dwvEjemplo
            // 
            this.dwvEjemplo.AllowUserToAddRows = false;
            this.dwvEjemplo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dwvEjemplo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Funcionario_id,
            this.Funcionario_nome});
            this.dwvEjemplo.Location = new System.Drawing.Point(35, 143);
            this.dwvEjemplo.Name = "dwvEjemplo";
            this.dwvEjemplo.Size = new System.Drawing.Size(501, 208);
            this.dwvEjemplo.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(375, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Funcionario_id
            // 
            this.Funcionario_id.DataPropertyName = "Funcionario_id";
            this.Funcionario_id.HeaderText = "Cod";
            this.Funcionario_id.Name = "Funcionario_id";
            // 
            // Funcionario_nome
            // 
            this.Funcionario_nome.DataPropertyName = "Funcionario_nome";
            this.Funcionario_nome.HeaderText = "Nombres";
            this.Funcionario_nome.Name = "Funcionario_nome";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(188, 58);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // FrmEjemplo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 387);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dwvEjemplo);
            this.Name = "FrmEjemplo";
            this.Text = "FrmEjemplo";
            ((System.ComponentModel.ISupportInitialize)(this.dwvEjemplo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dwvEjemplo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Funcionario_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Funcionario_nome;
        private System.Windows.Forms.TextBox txtNombre;
    }
}