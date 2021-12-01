using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Negocio
{
    public class UsuarioNegocio
    {
        public bool Loguear(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select Id, TipoUser from USUARIOS Where usuario = @user AND pass = @pass");
                datos.setearParametro("@user", usuario.User);
                datos.setearParametro("@pass", usuario.Pass);

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["Id"];
                    usuario.TipoUsuario = (int)(datos.Lector["TipoUser"]) == 2 ? TipoUsuario.ADMIN : TipoUsuario.VENDEDOR;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Usuario> listarVendedores()
        {
            List<Usuario> listaVendedores = new List<Usuario>();

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select Id, TipoUser, Usuario from Usuarios where TipoUser = 1");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.Id = (int)datos.Lector["Id"];
                    usuario.TipoUsuario = (TipoUsuario)datos.Lector["TipoUser"];
                    usuario.User = (string)datos.Lector["Usuario"];

                    listaVendedores.Add(usuario);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return listaVendedores;
        }

        public Usuario getVendedor(int Id)
        {
            
            AccesoDatos datos = new AccesoDatos();
            Usuario usuario = new Usuario();

            try
            {
                datos.setearConsulta("Select Id, TipoUser, Usuario from Usuarios where Id = " + Id);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    
                    usuario.Id = (int)datos.Lector["Id"];
                    usuario.TipoUsuario = (TipoUsuario)datos.Lector["TipoUser"];
                    usuario.User = (string)datos.Lector["Usuario"];

                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return usuario;
        }
    }
}
