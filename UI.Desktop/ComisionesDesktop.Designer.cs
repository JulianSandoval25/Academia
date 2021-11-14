
namespace UI.Desktop
{
    partial class ComisionesDesktop
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
            this.tlComisionesDesktop = new System.Windows.Forms.TableLayoutPanel();
            this.lblID = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblAnioEsp = new System.Windows.Forms.Label();
            this.lblIDPlan = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtAnioEsp = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.cbIDPlan = new System.Windows.Forms.ComboBox();
            this.tlComisionesDesktop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlComisionesDesktop
            // 
            this.tlComisionesDesktop.ColumnCount = 4;
            this.tlComisionesDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlComisionesDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlComisionesDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlComisionesDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlComisionesDesktop.Controls.Add(this.lblID, 0, 0);
            this.tlComisionesDesktop.Controls.Add(this.lblDescripcion, 0, 1);
            this.tlComisionesDesktop.Controls.Add(this.lblAnioEsp, 2, 0);
            this.tlComisionesDesktop.Controls.Add(this.lblIDPlan, 2, 1);
            this.tlComisionesDesktop.Controls.Add(this.txtID, 1, 0);
            this.tlComisionesDesktop.Controls.Add(this.txtDesc, 1, 1);
            this.tlComisionesDesktop.Controls.Add(this.txtAnioEsp, 3, 0);
            this.tlComisionesDesktop.Controls.Add(this.btnAceptar, 2, 2);
            this.tlComisionesDesktop.Controls.Add(this.cbIDPlan, 3, 1);
            this.tlComisionesDesktop.Controls.Add(this.btnCancelar, 3, 2);
            this.tlComisionesDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlComisionesDesktop.Location = new System.Drawing.Point(0, 0);
            this.tlComisionesDesktop.Name = "tlComisionesDesktop";
            this.tlComisionesDesktop.RowCount = 3;
            this.tlComisionesDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlComisionesDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlComisionesDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlComisionesDesktop.Size = new System.Drawing.Size(558, 316);
            this.tlComisionesDesktop.TabIndex = 0;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(3, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 13);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(3, 143);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // lblAnioEsp
            // 
            this.lblAnioEsp.AutoSize = true;
            this.lblAnioEsp.Location = new System.Drawing.Point(281, 0);
            this.lblAnioEsp.Name = "lblAnioEsp";
            this.lblAnioEsp.Size = new System.Drawing.Size(67, 26);
            this.lblAnioEsp.TabIndex = 2;
            this.lblAnioEsp.Text = "Año Especialidad";
            // 
            // lblIDPlan
            // 
            this.lblIDPlan.AutoSize = true;
            this.lblIDPlan.Location = new System.Drawing.Point(281, 143);
            this.lblIDPlan.Name = "lblIDPlan";
            this.lblIDPlan.Size = new System.Drawing.Size(42, 13);
            this.lblIDPlan.TabIndex = 3;
            this.lblIDPlan.Text = "ID Plan";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(86, 3);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(189, 20);
            this.txtID.TabIndex = 0;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(86, 146);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(189, 20);
            this.txtDesc.TabIndex = 2;
            // 
            // txtAnioEsp
            // 
            this.txtAnioEsp.Location = new System.Drawing.Point(364, 3);
            this.txtAnioEsp.Name = "txtAnioEsp";
            this.txtAnioEsp.Size = new System.Drawing.Size(191, 20);
            this.txtAnioEsp.TabIndex = 1;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(364, 289);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(281, 289);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // cbIDPlan
            // 
            this.cbIDPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIDPlan.FormattingEnabled = true;
            this.cbIDPlan.Location = new System.Drawing.Point(364, 146);
            this.cbIDPlan.Name = "cbIDPlan";
            this.cbIDPlan.Size = new System.Drawing.Size(191, 21);
            this.cbIDPlan.TabIndex = 3;
            // 
            // ComisionesDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 316);
            this.Controls.Add(this.tlComisionesDesktop);
            this.Name = "ComisionesDesktop";
            this.Text = "ComisionesDesktop";
            this.Load += new System.EventHandler(this.ComisionesDesktop_Load);
            this.tlComisionesDesktop.ResumeLayout(false);
            this.tlComisionesDesktop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlComisionesDesktop;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblAnioEsp;
        private System.Windows.Forms.Label lblIDPlan;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtAnioEsp;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ComboBox cbIDPlan;
    }
}