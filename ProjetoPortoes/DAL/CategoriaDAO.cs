using ProjetoPortoes.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;
namespace ProjetoPortoes.DAL
{
    public class CategoriaDAO
    {
        private static Entities entities = Singleton.Instance.Entities;
        public static List<Categoria> ListarCategorias()
        {
            return entities.Categorias.ToList();
        }
        public static bool CadastrarCategoria(Categoria categoria)
        {
            try
            {
                if(BuscarCategoriaPorNome(categoria) == null)
                {
                    entities.Categorias.Add(categoria);
                    entities.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception)
            {
                return false;
            }
        }
        public static Categoria BuscarCategoriaPorNome(Categoria categoria)
        {
            return entities.Categorias.FirstOrDefault(x => x.Nome.Equals(categoria.Nome));
        }
        public static Categoria BuscarCategoriaPorId(int? id)
        {
            return entities.Categorias.Find(id);
        }
        public static bool AtualizarCategoria(Categoria categoria)
        {
            try
            {
                entities.Entry(categoria).State = EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool RemoverCategoria(Categoria categoria)
        {
            try
            {
                entities.Categorias.Remove(categoria);
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