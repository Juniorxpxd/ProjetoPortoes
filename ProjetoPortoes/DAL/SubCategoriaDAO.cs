using ProjetoPortoes.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjetoPortoes.DAL
{
    public class SubCategoriaDAO
    {
        private static Entities entities = Singleton.Instance.Entities;
        public static List<SubCategoria> ListarSubCategorias()
        {
            return entities.SubCategorias.Include("Categoria").Include("Produtos").ToList();
        }
        public static bool CadastrarSubCategoria(SubCategoria subcategoria)
        {
            try
            {
                if (BuscarSubCategoriaPorNome(subcategoria) == null)
                {
                    entities.SubCategorias.Add(subcategoria);
                    entities.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static SubCategoria BuscarSubCategoriaPorNome(SubCategoria subcategoria)
        {
            return entities.SubCategorias.FirstOrDefault(x => x.Nome.Equals(subcategoria.Nome));
        }
        public static SubCategoria BuscarSubCategoriaPorId(int? id)
        {
            return entities.SubCategorias.Find(id);
        }

        public static List<SubCategoria> BuscarSubCategoriasPorCategoria(int? idCategoria)
        {
            return entities.SubCategorias.Include("Categoria").Where(x => x.Categoria.CategoriaId == idCategoria).ToList();
        }

        public static bool AtualizarSubCategoria(SubCategoria subcategoria)
        {
            try
            {
                entities.Entry(subcategoria).State = EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool RemoverSubCategoria(SubCategoria subcategoria)
        {
            try
            {
                entities.SubCategorias.Remove(subcategoria);
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