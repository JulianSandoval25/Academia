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
    public class DocenteCursoAdapter : Adapter
    {
        public List<DocenteCurso> TraerTodosxIdDoc(int doc)
        {
            List<DocenteCurso> docentescursos = new List<DocenteCurso>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdDocenteCurso = new SqlCommand("select * from docentes_cursos where id_docente=@id", this.sqlConn);
                cmdDocenteCurso.Parameters.Add("@id", SqlDbType.Int).Value = doc;

                SqlDataReader drDocenteCurso = cmdDocenteCurso.ExecuteReader();

                while (drDocenteCurso.Read())
                {
                    DocenteCurso docentecurso = new DocenteCurso();

                    docentecurso.ID = (int)drDocenteCurso["id_dictado"];
                    docentecurso.IDCurso = (int)drDocenteCurso["id_curso"];
                    docentecurso.IDDocente = (int)drDocenteCurso["id_docente"];
                    switch ((int)drDocenteCurso["cargo"])
                    {
                        case 1:
                            docentecurso.Cargo = DocenteCurso.TiposCargos.Titular;
                            break;
                        case 2:
                            docentecurso.Cargo = DocenteCurso.TiposCargos.Ayudante;
                            break;
                    }


                    docentescursos.Add(docentecurso);
                }


                drDocenteCurso.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de comisiones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return docentescursos;
        }
        
    }
}
