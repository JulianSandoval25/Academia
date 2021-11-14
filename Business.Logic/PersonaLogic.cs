using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class PersonaLogic
    {
        public PersonaAdapter DatosPersona { get; set; }

       

        public PersonaLogic()
        {
            DatosPersona = new PersonaAdapter();
        }

        public Persona GetOne(int ID)
        {
            try
            {
                
                return DatosPersona.GetOne(ID);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public List<Persona> GetAll()
        {
            return DatosPersona.GetAll();
        }

        public void Save(Persona persona)
        {
            if (persona.State == BusinessEntity.States.Deleted)
            {
                this.Delete(persona.ID);
            }
            else if (persona.State == BusinessEntity.States.New)
            {
                this.Insert(persona);
            }
            else if (persona.State == BusinessEntity.States.Modified)
            {
                this.Update(persona);
            }
        }

        public void Delete(int ID)
        {
            DatosPersona.Delete(ID);
        }

        public void Insert(Persona persona)
        {
            DatosPersona.Insert(persona);
        }

        public void Update(Persona persona)
        {
            DatosPersona.Update(persona);
        }
    }
}
