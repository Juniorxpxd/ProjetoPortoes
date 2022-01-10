using ProjetoPortoes.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjetoPortoes.DAL
{
    public class AdministradorDAO
    {
        private static Entities entities = Singleton.Instance.Entities;
        public static List<Administrador> ListarAdministradores()
        {
            return entities.Administradores.ToList();
        }
        public static bool CadastrarAdministradores(Administrador administradores)
        {
            try
            {

                entities.Administradores.Add(administradores);
                entities.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public static Administrador BuscarAdministradorPorLoginESenha(Administrador adm)
        {
            return entities.Administradores.FirstOrDefault(x => x.Login.Equals(adm.Login) && x.Senha.Equals(adm.Senha));
        }
        public static Administrador BuscarAdministradorPorLogin(Administrador adm)
        {
            return entities.Administradores.FirstOrDefault(x => x.Login.Equals(adm.Login));
        }
        public static Administrador BuscarAdministradoresPorNome(Administrador administradores)
        {
            return entities.Administradores.FirstOrDefault(x => x.Nome.Equals(administradores.Nome));
        }
        public static Administrador BuscarAdministradoresPorId(int? id)
        {
            return entities.Administradores.Find(id);
        }
        public static bool AtualizarAdministradores(Administrador administradores)
        {
            try
            {
                entities.Entry(administradores).State = EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool RemoverAdministradores(Administrador administradores)
        {
            try
            {
                entities.Administradores.Remove(administradores);
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