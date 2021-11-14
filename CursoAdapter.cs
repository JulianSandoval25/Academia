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
    public class CursoAdapter: Adapter
    {
        public List<Curso> GetAll()
        {
            List<Curso> cursos = new List<Curso>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdCursos = new SqlCommand("select * from cursos", this.sqlConn);

                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                while (drCursos.Read())
                {
                    Curso curso = new Curso();

                    curso.ID = (int)drCursos["id_curso"];
                    //curso.Descripcion = (string)drCursos["desc_curso"];
                    curso.AnioCalendario = (int)drCursos["anio_calendario"];
                    curso.Cupo = (int)drCursos["cupo"];
                    //curso.IDComision = (int)drCursos["id_comision"];
                    curso.IDMateria = (int)drCursos["id_materia"];
                    if (!(drCursos["id_comision"] == DBNull.Value))
                    {
                        curso.IDComision = (int)drCursos["id_comision"]; ;
                    }


                    cursos.Add(curso);
                }


                drCursos.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return cursos;
        }

        public Business.Entities.Curso GetOne(int ID)
        {
            Curso curso = new Curso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("select * from cursos where id_curso=@id", sqlConn);
                cmdCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                if (drCursos.Read())
                {
                    curso.ID = (int)drCursos["id_curso"];
                    //curso.Descripcion = (string)drCursos["desc_curso"];
                    curso.AnioCalendario = (int)drCursos["anio_calendario"];
                    curso.Cupo = (int)drCursos["cupo"];
                    //curso.IDComision = (int)drCursos["id_comision"];
                    curso.IDMateria = (int)drCursos["id_materia"];
                    if (!(drCursos["id_comision"] == DBNull.Value))
                    {
                        curso.IDComision = (int)drCursos["id_comision"]; ;
                    }

                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();

            }
            return curso;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete cursos where id_curso=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Curso curso)
        {
            if (curso.State == BusinessEntity.States.Deleted)
            {
                this.Delete(curso.ID);
            }
            else if (curso.State == BusinessEntity.States.New)
            {
                this.Insert(curso);
            }
            else if (curso.State == BusinessEntity.States.Modified)
            {
                this.Update(curso);
            }
            curso.State = BusinessEntity.States.Unmodified;
        }


        public void Update(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE cursos SET id_materia=@idmateria, id_comision=@idcomision, anio_calendario=@aniocalendario, cupo=@cupo WHERE id_curso=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.VarChar, 50).Value = curso.ID;
                cmdSave.Parameters.Add("@aniocalendario", SqlDbType.VarChar, 50).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.VarChar, 50).Value = curso.Cupo;
                cmdSave.Parameters.Add("@idmateria", SqlDbType.VarChar, 50).Value = curso.IDMateria;
                cmdSave.Parameters.Add("@idcomision", SqlDbType.VarChar, 50).Value = curso.IDComision;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO cursos(id_materia, id_comision, anio_calendario, cupo) values (@idmateria, @idcomision, @aniocalendario, @cupo) select @@identity", sqlConn);

                cmdSave.Parameters.Add("@aniocalendario", SqlDbType.VarChar, 50).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.VarChar, 50).Value = curso.Cupo;
                cmdSave.Parameters.Add("@idmateria", SqlDbType.VarChar, 50).Value = curso.IDMateria;
                cmdSave.Parameters.Add("@idcomision", SqlDbType.VarChar, 50).Value = curso.IDComision;
                curso.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }



        public List<Curso> GetAllxPlan(int id_plan, int id)
        {
            List<Curso> cursos = new List<Curso>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdCursos = new SqlCommand("select * from cursos c  inner join materias m on c.id_materia = m.id_materia inner join comisiones co on c.id_comision = co.id_comision  where m.id_plan = co.id_plan and m.id_plan = @plan and c.id_curso not in ( select id_curso from alumnos_inscripciones where id_alumno = @id )", this.sqlConn);
                cmdCursos.Parameters.Add("@plan", SqlDbType.VarChar, 50).Value= id_plan;
                cmdCursos.Parameters.Add("@id", SqlDbType.VarChar, 50).Value = id;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                while (drCursos.Read())
                {
                    Curso curso = new Curso();

                    curso.ID = (int)drCursos["id_curso"];
                    //curso.Descripcion = (string)drCursos["desc_curso"];
                    curso.AnioCalendario = (int)drCursos["anio_calendario"];
                    curso.Cupo = (int)drCursos["cupo"];
                    //curso.IDComision = (int)drCursos["id_comision"];
                    curso.IDMateria = (int)drCursos["id_materia"];
                    if (!(drCursos["id_comision"] == DBNull.Value))
                    {
                        curso.IDComision = (int)drCursos["id_comision"]; ;
                    }


                    cursos.Add(curso);
                }


                drCursos.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return cursos;
        }
    }
}

