
namespace UI.Desktop
{
    partial class Menu
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
            this.btnSalir = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.actividadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMPlanes = new System.Windows.Forms.ToolStripMenuItem();
            this.materiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMEspecialidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMComisionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMCursoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteCursosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportePlanesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alumnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inscripcionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.docenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(500, 325);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actividadesToolStripMenuItem,
            this.alumnoToolStripMenuItem,
            this.docenteToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(587, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // actividadesToolStripMenuItem
            // 
            this.actividadesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMUsuariosToolStripMenuItem,
            this.aBMPlanes,
            this.aBMEspecialidadesToolStripMenuItem,
            this.aBMComisionesToolStripMenuItem,
            this.aBMCursoToolStripMenuItem,
            this.reporteCursosToolStripMenuItem,
            this.reportePlanesToolStripMenuItem});
            this.actividadesToolStripMenuItem.Name = "actividadesToolStripMenuItem";
            this.actividadesToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.actividadesToolStripMenuItem.Text = "Administrador";
            // 
            // aBMUsuariosToolStripMenuItem
            // 
            this.aBMUsuariosToolStripMenuItem.Name = "aBMUsuariosToolStripMenuItem";
            this.aBMUsuariosToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.aBMUsuariosToolStripMenuItem.Text = "Usuarios";
            this.aBMUsuariosToolStripMenuItem.Click += new System.EventHandler(this.aBMUsuariosToolStripMenuItem_Click);
            // 
            // aBMPlanes
            // 
            this.aBMPlanes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.materiaToolStripMenuItem});
            this.aBMPlanes.Name = "aBMPlanes";
            this.aBMPlanes.Size = new System.Drawing.Size(154, 22);
            this.aBMPlanes.Text = "Planes";
            this.aBMPlanes.Click += new System.EventHandler(this.aBMToolStripMenuItem_Click);
            // 
            // materiaToolStripMenuItem
            // 
            this.materiaToolStripMenuItem.Name = "materiaToolStripMenuItem";
            this.materiaToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.materiaToolStripMenuItem.Text = "Materia";
            this.materiaToolStripMenuItem.Click += new System.EventHandler(this.materiaToolStripMenuItem_Click);
            // 
            // aBMEspecialidadesToolStripMenuItem
            // 
            this.aBMEspecialidadesToolStripMenuItem.Name = "aBMEspecialidadesToolStripMenuItem";
            this.aBMEspecialidadesToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.aBMEspecialidadesToolStripMenuItem.Text = "Especialidades";
            this.aBMEspecialidadesToolStripMenuItem.Click += new System.EventHandler(this.aBMEspecialidadesToolStripMenuItem_Click);
            // 
            // aBMComisionesToolStripMenuItem
            // 
            this.aBMComisionesToolStripMenuItem.Name = "aBMComisionesToolStripMenuItem";
            this.aBMComisionesToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.aBMComisionesToolStripMenuItem.Text = "Comisiones";
            this.aBMComisionesToolStripMenuItem.Click += new System.EventHandler(this.aBMComisionesToolStripMenuItem_Click);
            // 
            // aBMCursoToolStripMenuItem
            // 
            this.aBMCursoToolStripMenuItem.Name = "aBMCursoToolStripMenuItem";
            this.aBMCursoToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.aBMCursoToolStripMenuItem.Text = "Curso";
            this.aBMCursoToolStripMenuItem.Click += new System.EventHandler(this.aBMCursoToolStripMenuItem_Click);
            // 
            // reporteCursosToolStripMenuItem
            // 
            this.reporteCursosToolStripMenuItem.Name = "reporteCursosToolStripMenuItem";
            this.reporteCursosToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.reporteCursosToolStripMenuItem.Text = "Reporte Cursos";
            this.reporteCursosToolStripMenuItem.Click += new System.EventHandler(this.reporteCursosToolStripMenuItem_Click);
            // 
            // reportePlanesToolStripMenuItem
            // 
            this.reportePlanesToolStripMenuItem.Name = "reportePlanesToolStripMenuItem";
            this.reportePlanesToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.reportePlanesToolStripMenuItem.Text = "Reporte Planes";
            this.reportePlanesToolStripMenuItem.Click += new System.EventHandler(this.reportePlanesToolStripMenuItem_Click);
            // 
            // alumnoToolStripMenuItem
            // 
            this.alumnoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inscripcionToolStripMenuItem});
            this.alumnoToolStripMenuItem.Name = "alumnoToolStripMenuItem";
            this.alumnoToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.alumnoToolStripMenuItem.Text = "Alumno";
            // 
            // inscripcionToolStripMenuItem
            // 
            this.inscripcionToolStripMenuItem.Name = "inscripcionToolStripMenuItem";
            this.inscripcionToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.inscripcionToolStripMenuItem.Text = "Inscripcion";
            this.inscripcionToolStripMenuItem.Click += new System.EventHandler(this.inscripcionToolStripMenuItem_Click);
            // 
            // docenteToolStripMenuItem
            // 
            this.docenteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calificarToolStripMenuItem});
            this.docenteToolStripMenuItem.Name = "docenteToolStripMenuItem";
            this.docenteToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.docenteToolStripMenuItem.Text = "Docente";
            // 
            // calificarToolStripMenuItem
            // 
            this.calificarToolStripMenuItem.Name = "calificarToolStripMenuItem";
            this.calificarToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.calificarToolStripMenuItem.Text = "Calificar";
            this.calificarToolStripMenuItem.Click += new System.EventHandler(this.calificarToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "label2";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 360);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem actividadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMPlanes;
        private System.Windows.Forms.ToolStripMenuItem aBMEspecialidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem materiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMComisionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alumnoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inscripcionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMCursoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem docenteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteCursosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportePlanesToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}