using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class PersonaAdapter : Adapter
    {
        public List<Persona> GetAll()
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("select * from personas", sqlConn);
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                while (drPersonas.Read())
                {
                    Persona per = new Persona();
                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.Legajo = (int)drPersonas["legajo"];
                    switch ((int)drPersonas["tipo_persona"])
                    {
                        case 1:
                            per.TipoPersona = Persona.Tipo.Alumno;
                            break;
                        case 2:
                            per.TipoPersona = Persona.Tipo.Profesor;
                            break;
                        case 3:
                            per.TipoPersona = Persona.Tipo.Administrativo;
                            break;
                    }
                    per.IDPlan = (int)drPersonas["id_plan"];

                    personas.Add(per);
                }
                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de personas", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return personas;
        }


        public Persona GetOne(int ID)
        {
            Persona persona = new Persona();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("select * from personas where id_persona = @id", sqlConn);
                cmdPersonas.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                if (drPersonas.Read())
                {
                    persona.ID = (int)drPersonas["id_persona"];
                    persona.Nombre = (string)drPersonas["nombre"];
                    persona.Apellido = (string)drPersonas["apellido"];
                    //persona.Direccion = (string)drPersonas["direccion"];
                    persona.Email = (string)drPersonas["email"];
                    //persona.Telefono = (string)drPersonas["telefono"];
                    persona.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    persona.Legajo = (int)drPersonas["legajo"];
                    switch ((int)drPersonas["tipo_persona"])
                    {
                        case 1:
                            persona.TipoPersona = Persona.Tipo.Alumno;
                            break;
                        case 2:
                            persona.TipoPersona = Persona.Tipo.Profesor;
                            break;
                        case 3:
                            persona.TipoPersona = Persona.Tipo.Administrativo;
                            break;
                    }
                    if (!(drPersonas["id_plan"]==DBNull.Value))
                    {
                        persona.IDPlan = (int)drPersonas["id_plan"];
                    }
                    //persona.IDPlan = (int)drPersonas["id_plan"];
                }
                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar los datos de la persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return persona;
        }


        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("" +
                    "delete alumnos_inscripciones where id_alumno = @id; " +
                    "delete usuarios where id_persona = @id; " +
                    "delete personas where id_persona = @id;", sqlConn);
                cmdPersonas.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdPersonas.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(Persona persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdActualizar = new SqlCommand(
                    "update personas set nombre = @nombre, apellido = @apellido, " +
                    "email = @email, " +
                    "fecha_nac = @fecha_nac, legajo = @legajo, tipo_persona = @tipo_persona, " +
                    "id_plan = @id_plan WHERE id_persona = @id", sqlConn);

                cmdActualizar.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
                cmdActualizar.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdActualizar.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                //cmdActualizar.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdActualizar.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                //cmdActualizar.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                if (persona.FechaNacimiento == null)
                {
                    cmdActualizar.Parameters.Add("@fecha_nac", SqlDbType.Date).Value = DateTime.Now;
                }
                else
                {
                    cmdActualizar.Parameters.Add("@fecha_nac", SqlDbType.Date).Value = persona.FechaNacimiento;
                }
                cmdActualizar.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                int tipo = 0;
                switch (persona.TipoPersona)
                {
                    case Persona.Tipo.Alumno:
                        tipo = 1;
                        break;
                    case Persona.Tipo.Profesor:
                        tipo = 2;
                        break;
                    case Persona.Tipo.Administrativo:
                        tipo = 3;
                        break;
                }
                cmdActualizar.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = tipo;
                if (!(persona.IDPlan == 0))
                {
                    cmdActualizar.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IDPlan;

                }
                else
                {
                    cmdActualizar.Parameters.Add("@id_plan", SqlDbType.Int).Value = DBNull.Value;
                }

                cmdActualizar.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Persona persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdAgregar = new SqlCommand(
                    "insert into personas(nombre, apellido, email, fecha_nac, legajo, tipo_persona, id_plan) " +
                    "values(@nombre, @apellido, @email, @fecha_nac, @legajo, @tipo_persona, @id_plan) " +
                    "select @@identity", sqlConn);

                cmdAgregar.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdAgregar.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                //cmdAgregar.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdAgregar.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                //cmdAgregar.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdAgregar.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdAgregar.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                int tipo = 0;
                switch (persona.TipoPersona)
                {
                    case Persona.Tipo.Alumno:
                        tipo = 1;
                        break;
                    case Persona.Tipo.Profesor:
                        tipo = 2;
                        break;
                    case Persona.Tipo.Administrativo:
                        tipo = 3;
                        break;
                }
                cmdAgregar.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = tipo;
                if (!(persona.IDPlan==0))
                {
                    cmdAgregar.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IDPlan;

                }
                else
                {
                    cmdAgregar.Parameters.Add("@id_plan", SqlDbType.Int).Value = DBNull.Value;
                }
                //cmdAgregar.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IDPlan;

                //Obtengo el ID que asignó la BD automáticamente
                persona.ID = Decimal.ToInt32((decimal)cmdAgregar.ExecuteScalar());

            }
            catch (Exception Ex)
            {
               Exception ExcepcionManejada = new Exception("Error al crear la persona", Ex);
               throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }



    }
}
