using ProjetoPortoes.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjetoPortoes.DAL
{
    public class ProdutoDAO
    {
        private static Entities entities = Singleton.Instance.Entities;
        private static int? idCaract;
        public static List<Produto> ListarProdutos()
        {
            return entities.Produtos.Include("SubCategoria").ToList();
        }
        public static bool CadastrarProduto(Produto produto)
        {
            try
            {
                if (BuscarProdutoPorNome(produto) == null)
                {
                    //produto.CaracteristicasId = Convert.ToInt32(idCaract);
                    entities.Produtos.Add(produto);
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
        public static Produto BuscarProdutoPorNome(Produto produto)
        {
            return entities.Produtos.FirstOrDefault(x => x.Nome.Equals(produto.Nome));
        }
        public static Produto BuscarProdutoPorId(int? id)
        {
            return entities.Produtos.Find(id);
        }
        public static List<Produto> BuscarProdutosPorSubCategoria(int? idSubCategoria)
        {
            return entities.Produtos.Include("SubCategoria").Where(x => x.SubCategoria.SubCategoriaId == idSubCategoria).ToList();
        }
        public static bool AtualizarProduto(Produto produto)
        {
            try
            {
                entities.Entry(produto).State = EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool RemoverProduto(Produto produto)
        {
            try
            {
                entities.Produtos.Remove(produto);
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