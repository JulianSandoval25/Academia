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
    public class MateriaAdapter: Adapter
    {
        public List<Materia> GetAll()
        {
            List<Materia> materia = new List<Materia>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdMaterias = new SqlCommand("select * from materias", this.sqlConn);

                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

                while (drMaterias.Read())
                {
                    Materia mate = new Materia();

                    mate.ID = (int)drMaterias["id_materia"];
                    mate.Descripcion = (string)drMaterias["desc_materia"];
                    mate.HSSemanales = (int)drMaterias["hs_semanales"];
                    mate.HSTotales = (int)drMaterias["hs_totales"];
                    mate.IDPlan = (int)drMaterias["id_plan"];


                    materia.Add(mate);
                }


                drMaterias.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de materias", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return materia;
        }

        public List<Materia> GetAllxID(int ID)
        {
            List<Materia> materia = new List<Materia>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdMaterias = new SqlCommand("select * from materias where id_plan=@id", this.sqlConn);
                cmdMaterias.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

                while (drMaterias.Read())
                {
                    Materia mate = new Materia();

                    mate.ID = (int)drMaterias["id_materia"];
                    mate.Descripcion = (string)drMaterias["desc_materia"];
                    mate.HSSemanales = (int)drMaterias["hs_semanales"];
                    mate.HSTotales = (int)drMaterias["hs_totales"];
                    mate.IDPlan = (int)drMaterias["id_plan"];


                    materia.Add(mate);
                }


                drMaterias.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de materias", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return materia;
        }

        public Business.Entities.Materia GetOne(int ID)
        {
            Materia mate = new Materia();
            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("select * from materias where id_materia=@id", sqlConn);
                cmdMaterias.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();
                if (drMaterias.Read())
                {
                    mate.ID = (int)drMaterias["id_materia"];
                    mate.Descripcion = (string)drMaterias["desc_materia"];
                    mate.HSSemanales = (int)drMaterias["hs_semanales"];
                    mate.HSTotales = (int)drMaterias["hs_totales"];
                    mate.IDPlan = (int)drMaterias["id_plan"];

                }
                drMaterias.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();

            }
            return mate;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete materias where id_materia=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Materia mate)
        {
            if (mate.State == BusinessEntity.States.Deleted)
            {
                this.Delete(mate.ID);
            }
            else if (mate.State == BusinessEntity.States.New)
            {
                this.Insert(mate);
            }
            else if (mate.State == BusinessEntity.States.Modified)
            {
                this.Update(mate);
            }
            mate.State = BusinessEntity.States.Unmodified;
        }


        public void Update(Materia mate)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE materias SET desc_materia= @desc, id_plan=@id_plan, hs_semanales=@hs_s, hs_totales=@hs_t WHERE id_materia=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.VarChar, 50).Value = mate.ID;
                cmdSave.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = mate.Descripcion;
                cmdSave.Parameters.Add("@hs_s", SqlDbType.VarChar, 50).Value = mate.HSSemanales;
                cmdSave.Parameters.Add("@hs_t", SqlDbType.VarChar, 50).Value = mate.HSTotales;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.VarChar, 50).Value = mate.IDPlan;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Materia mate)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO materias(desc_materia,hs_semanales, hs_totales, id_plan) values (@desc, @hs_s, @hs_t, @id_plan) select @@identity", sqlConn);

                cmdSave.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = mate.Descripcion;
                cmdSave.Parameters.Add("@hs_s", SqlDbType.VarChar, 50).Value = mate.HSSemanales;
                cmdSave.Parameters.Add("@hs_t", SqlDbType.VarChar, 50).Value = mate.HSTotales;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.VarChar, 50).Value = mate.IDPlan;
                mate.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public List<Materia> TraerTodosPorIdPlan(int ID)
        {
            List<Materia> materias = new List<Materia>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("select * from materias where id_plan = @id", sqlConn);
                cmdMaterias.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();
                while (drMaterias.Read())
                {
                    Materia mat = new Materia();
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HSSemanales = (int)drMaterias["hs_semanales"];
                    mat.HSTotales = (int)drMaterias["hs_totales"];
                    mat.IDPlan = (int)drMaterias["id_plan"];

                    materias.Add(mat);
                }
                drMaterias.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de materias", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return materias;
        }



    }
}
