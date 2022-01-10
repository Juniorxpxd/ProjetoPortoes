using ProjetoPortoes.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ProjetoPortoes.DAL
{
    public class UsuarioDAO
    {
        private static Entities entities = Singleton.Instance.Entities;
        public static List<Usuario> ListarUsuarios()
        {
            return entities.Usuarios.ToList();
        }
        public static bool CadastrarUsuario(Usuario usuario)
        {
            try
            {
                entities.Usuarios.Add(usuario);
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static Usuario BuscarUsuarioPorLoginESenha(Usuario usuario)
        {
            return entities.Usuarios.FirstOrDefault(x => x.Login.Equals(usuario.Login) && x.Senha.Equals(usuario.Senha));
        }
        public static Usuario BuscarUsuarioPorLogin(Usuario usuario)
        {
            return entities.Usuarios.FirstOrDefault(x => x.Login.Equals(usuario.Login));
        }
        public static Usuario BuscarUsuarioPorId(int? id)
        {
            return entities.Usuarios.Find(id);
        }
        public static bool EstaLogado()
        {
            if (HttpContext.Current.Session["Login"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool AtualizarUsuario(Usuario usuario)
        {
            try
            {
                entities.Entry(usuario).State = EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool RemoverUsuario(Usuario usuario)
        {
            try
            {
                entities.Usuarios.Remove(usuario);
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}