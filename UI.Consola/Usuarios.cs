using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Logic;
using Business.Entities;


namespace UI.Consola
{
    public class Usuarios
    {
        Business.Logic.UsuarioLogic UsuarioNegocio;
        public Usuarios()
        {
            UsuarioNegocio = new Business.Logic.UsuarioLogic();

        }
        public void Menu()
        {
            int opc;
            do
            {
                Console.WriteLine("Ingrese opción a realizar: ");
                Console.WriteLine("1- Listado general");
                Console.WriteLine("2- Consulta");
                Console.WriteLine("3- Agregar");
                Console.WriteLine("4- Modificar");
                Console.WriteLine("5- Eliminar");
                Console.WriteLine("6- Salir");
                opc = int.Parse(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        this.ListadoGeneral();
                        break;

                    case 2:
                        this.Consultar();
                        break;

                    case 3:
                        this.Agregar();
                        break;

                    case 4:
                        this.Modificar();
                        break;

                    case 5:
                        this.Eliminar();
                        break;

                    case 6:
                        this.Salir();
                        break;

                }


            } while (opc != 6 && opc >= 1 && opc <= 5);




        }
        public void ListadoGeneral()
        {
            Console.Clear();

            foreach (Usuario usuario in UsuarioNegocio.GetAll())
            {
                MostrarDatos(usuario);
            }

        }


        public void MostrarDatos(Usuario usuario)
        {

            Console.WriteLine("Usuario: " + usuario.ID);
            Console.WriteLine("\t\tNombre: " + usuario.Nombre);
            Console.WriteLine("\t\tApellido: " + usuario.Apellido);
            Console.WriteLine("\t\tNombre de usuario: " + usuario.NombreUsuario);
            Console.WriteLine("\t\tClave: " + usuario.Clave);
            Console.WriteLine("\t\tEmail: " + usuario.Email);
            Console.WriteLine("\t\tHabilitado: " + usuario.Habilitado);

            Console.WriteLine();
        }
        public void Consultar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese el id de usuario a consultar: ");
                int id = int.Parse(Console.ReadLine());
                this.MostrarDatos(UsuarioNegocio.GetOne(id));
            }
            catch (FormatException e)
            {
                Console.WriteLine();
                Console.WriteLine("La id ingresada, debe ser un número entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("Presione una tecla para continuar");
            }


        }



        public void Modificar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese el id de usuario a consultar: ");
                int id = int.Parse(Console.ReadLine());
                Usuario user = UsuarioNegocio.GetOne(id);

                Console.WriteLine("Ingrese el nombre: ");
                user._Nombre = Console.ReadLine();
                Console.WriteLine("Ingrese el apellido: ");
                user._Apellido = Console.ReadLine();
                Console.WriteLine("Ingrese nombre de usuario: ");
                user._NombreUsuario = Console.ReadLine();
                Console.WriteLine("Ingrese clave: ");
                user._Clave = Console.ReadLine();
                Console.WriteLine("Ingrese email: ");
                user._Email = Console.ReadLine();
                Console.WriteLine("Ingrese habilitación del usuario: (1- Si/ otro- No): ");
                user._Habilitado = (Console.ReadLine() == "1");
                user.State = BusinessEntity.States.Modified;

            }
            catch (FormatException e)
            {
                Console.WriteLine();
                Console.WriteLine("La id ingresada, debe ser un número");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
            }
        }



        public void Salir()
        {
            Console.Clear();
            Console.WriteLine("Fin del programa, pulse una tecla para salir");
            Console.ReadLine();
        }


        public void Agregar()
        {
            Usuario user = new Usuario();

            Console.Clear();
            Console.WriteLine("Ingrese nombre: ");
            user._Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese apellido: ");
            user._Apellido = Console.ReadLine();
            Console.WriteLine("Ingrese nombre de usuario: ");
            user._NombreUsuario = Console.ReadLine();
            Console.WriteLine("Ingrese clave: ");
            user._Clave = Console.ReadLine();
            Console.WriteLine("Ingrese email: ");
            user._Email = Console.ReadLine();
            Console.WriteLine("Ingrese habilitación del usuario: (1- Si/ otro- No): ");
            user._Habilitado = (Console.ReadLine() == "1");
            user.State = BusinessEntity.States.New;
            UsuarioNegocio.Save(user);
            Console.Clear();
            Console.WriteLine("Número de id del usuario nuevo " + user.ID);
            Console.WriteLine("Pulse tecla para finalizar");
            Console.ReadLine();
            Console.Clear();

        }


        public void Eliminar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese el id de usuario a consultar: ");
                int id = int.Parse(Console.ReadLine());
                UsuarioNegocio.Delete(id);

            }
            catch (FormatException f)
            {
                Console.WriteLine();
                Console.WriteLine("La id ingresada, debe ser un número");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }

            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }



    }
}
