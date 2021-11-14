using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;
using System.Data;

namespace Data.Database
{
    public class AlumnoInscripcionAdapter : Adapter
    {
        public List<AlumnoInscripcion> GetAllxIdPersona(int IdPersona)
        {
            List<AlumnoInscripcion> alumnoInscripciones = new List<AlumnoInscripcion>();
            try
            {
                OpenConnection();
                SqlCommand cmdAlumnoInscripcion = new SqlCommand("select * from alumnos_inscripciones where id_alumno = @id_alumno", sqlConn);
                cmdAlumnoInscripcion.Parameters.Add("@id_alumno", SqlDbType.Int).Value = IdPersona;
                SqlDataReader drAlumnoInscripcion = cmdAlumnoInscripcion.ExecuteReader();
                while (drAlumnoInscripcion.Read())
                {
                    AlumnoInscripcion alumnoInscripcion = new AlumnoInscripcion();
                    alumnoInscripcion.ID = (int)drAlumnoInscripcion["id_inscripcion"];
                    alumnoInscripcion.IDAlumno = (int)drAlumnoInscripcion["id_alumno"];
                    alumnoInscripcion.IDCurso = (int)drAlumnoInscripcion["id_curso"];
                    if (drAlumnoInscripcion["nota"] != DBNull.Value)
                    {
                        alumnoInscripcion.Nota = (int)drAlumnoInscripcion["nota"];
                    }
                    alumnoInscripcion.Condicion = (string)drAlumnoInscripcion["condicion"];
                    alumnoInscripciones.Add(alumnoInscripcion);
                }
                drAlumnoInscripcion.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar las inscripciones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return alumnoInscripciones;
        }

        public void Inscribir(AlumnoInscripcion alum)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO alumnos_inscripciones(id_alumno, id_curso, condicion) values (@id_alumno, @id_curso, @condicion) select @@identity", sqlConn);

                cmdSave.Parameters.Add("@id_alumno", SqlDbType.VarChar, 50).Value = alum.IDAlumno;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.VarChar, 50).Value = alum.IDCurso;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = alum.Condicion;
                alum.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear Inscripcion", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }



        public List<AlumnoInscripcion> GetAllxIdCurso(int idCurso)
        {
            List<AlumnoInscripcion> alumnoInscripciones = new List<AlumnoInscripcion>();
            try
            {
                OpenConnection();
                SqlCommand cmdAlumnoInscripcion = new SqlCommand("select * from alumnos_inscripciones where id_curso = @id_curs", sqlConn);
                cmdAlumnoInscripcion.Parameters.Add("@id_curs", SqlDbType.Int).Value = idCurso;
                SqlDataReader drAlumnoInscripcion = cmdAlumnoInscripcion.ExecuteReader();
                while (drAlumnoInscripcion.Read())
                {
                    AlumnoInscripcion alumnoInscripcion = new AlumnoInscripcion();
                    alumnoInscripcion.ID = (int)drAlumnoInscripcion["id_inscripcion"];
                    alumnoInscripcion.IDAlumno = (int)drAlumnoInscripcion["id_alumno"];
                    alumnoInscripcion.IDCurso = (int)drAlumnoInscripcion["id_curso"];
                    if (drAlumnoInscripcion["nota"] != DBNull.Value)
                    {
                        alumnoInscripcion.Nota = (int)drAlumnoInscripcion["nota"];
                    }
                    alumnoInscripcion.Condicion = (string)drAlumnoInscripcion["condicion"];
                    alumnoInscripciones.Add(alumnoInscripcion);
                }
                drAlumnoInscripcion.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar las inscripciones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return alumnoInscripciones;
        }


        public void Update(Inscripciones ins)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE alumnos_inscripciones SET condicion=@condicion ,nota=@nota WHERE id_inscripcion=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = ins.ID;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = ins.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = ins.Nota;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la alumnos_inscripciones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public Inscripciones ConseguirInscripcionXid(int id)
        {
            Inscripciones ins = new Inscripciones();
            try
            {
                this.OpenConnection();
                SqlCommand cmdInscripcion = new SqlCommand("select * from alumnos_inscripciones where id_inscripcion=@id", sqlConn);
                cmdInscripcion.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataReader drInscripcion = cmdInscripcion.ExecuteReader();
                if (drInscripcion.Read())
                {
                    ins.ID = (int)drInscripcion["id_inscripcion"];
                    ins.IDCurso = (int)drInscripcion["id_curso"];
                    ins.Condicion = (string)drInscripcion["condicion"];
                    

                }
                drInscripcion.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos dela inscripcion", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();

            }
            return ins;
        }

    }
}
