using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
            this.dgvUsuarios.AutoGenerateColumns = false;
        }
        public void Listar()
        {
            UsuarioLogic ul = new UsuarioLogic();
            PersonaLogic pl = new PersonaLogic();
            List<UsuariosPersonas> lup = new List<UsuariosPersonas>();
            foreach(Usuario u in ul.GetAll())
            {
                UsuariosPersonas up = new UsuariosPersonas();
                up.ID = u.ID;
                up.Nombre = u.Nombre;
                up.Apellido = u.Apellido;
                up.NombreUsuario = u.NombreUsuario;
                // up.TipoPersona = pl.GetOne(u.IDPersona).TipoPersona.ToString();
                //up.Tipo = int.Parse(pl.GetOne(u.IDPersona).TipoPersona);
                switch (pl.GetOne(u.IDPersona).TipoPersona)
                {
                    case Persona.Tipo.Alumno:
                        up.TipoPersona = UsuariosPersonas.Tipo.Alumno;
                        break;
                    case Persona.Tipo.Profesor:
                        up.TipoPersona = UsuariosPersonas.Tipo.Profesor;
                        break;
                    case Persona.Tipo.Administrativo:
                        up.TipoPersona = UsuariosPersonas.Tipo.Administrativo;
                        break;
                }
                up.Legajo = pl.GetOne(u.IDPersona).Legajo;
                up.Habilitado = u.Habilitado;
                up.FechaNacimiento = pl.GetOne(u.IDPersona).FechaNacimiento;
                up.Email = u.Email;

                lup.Add(up);


            }
            this.dgvUsuarios.DataSource = lup;
            //this.dgvUsuarios.DataSource = ul.GetAll();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            UsuarioDesktop formUsuario = new UsuarioDesktop(ApplicationForm.ModoForm.Alta);
            formUsuario.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            
            int id = ((UsuariosPersonas)dgvUsuarios.CurrentRow.DataBoundItem).ID;
            
            UsuarioDesktop formUsuario = new UsuarioDesktop(id ,ApplicationForm.ModoForm.Modificacion);
            formUsuario.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int id = ((UsuariosPersonas)dgvUsuarios.CurrentRow.DataBoundItem).ID;

            UsuarioDesktop formUsuario = new UsuarioDesktop(id, ApplicationForm.ModoForm.Baja);
            formUsuario.ShowDialog();
            this.Listar();
        }
    }
}
