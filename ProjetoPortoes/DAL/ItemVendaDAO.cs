using ProjetoPortoes.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ProjetoPortoes.DAL
{
    public class ItemVendaDAO
    {
        private static Entities entities = Singleton.Instance.Entities;
        private static ItemVenda itemVendas = new ItemVenda();
        public static List<ItemVenda> ListarItemVendas()
        {
            return entities.ItemVendas.ToList();
        }
        public static bool AdicionarItemVendas(int? idProduto)
        {
            itemVendas = BuscarProdutoNoCarrinho(idProduto);
            if (itemVendas == null)
            {
                #region
                itemVendas = new ItemVenda();
                itemVendas.Produto = ProdutoDAO.BuscarProdutoPorId(idProduto);
                itemVendas.ProdutoId = Convert.ToInt32(idProduto);
                itemVendas.Preco = itemVendas.Produto.Preco;
                itemVendas.Quantidade = 1;
                itemVendas.DataDaAdicao = DateTime.Now;
                itemVendas.CarrinhoId = RetornarCarrinhoId();
                try
                {
                    entities.ItemVendas.Add(itemVendas);
                    entities.SaveChanges();
                    return false;
                }
                catch (Exception)
                {
                    return true;
                }
                #endregion
            }
            else
            {
                itemVendas.Quantidade++;
                entities.SaveChanges();
                return true;
            }
        }
        public static ItemVenda BuscarItemVendasPorNome(ItemVenda itemVendas)
        {
            return entities.ItemVendas.FirstOrDefault(x => x.Produto.Nome.Equals(itemVendas.Produto.Nome));
        }
        public static ItemVenda BuscarItemVendasPorId(int? id)
        {
            return entities.ItemVendas.Find(id);
        }
        public static bool AtualizarItemVendas(ItemVenda itemVendas)
        {
            try
            {
                entities.Entry(itemVendas).State = EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool RemoverItemVendas(int? idProduto)
        {
            itemVendas = BuscarProdutoNoCarrinho(idProduto);
            if (itemVendas.Quantidade == 1)
            {
                try
                {
                    entities.ItemVendas.Remove(itemVendas);
                    entities.SaveChanges();
                    return false;
                }
                catch (Exception)
                {
                    return true;
                }
            }
            else
            {
                itemVendas.Quantidade--;
                entities.SaveChanges();
                return true;
            }
        }
        public static string RetornarCarrinhoId()
        {
            if (HttpContext.Current.Session["CarrinhoId"] == null)
            {
                Guid guid = Guid.NewGuid();
                HttpContext.Current.Session["CarrinhoId"] = guid.ToString();
            }
            return HttpContext.Current.Session["CarrinhoId"].ToString();
        }

        public static ItemVenda BuscarProdutoNoCarrinho(int? idProduto)
        {
            string idCarrinho = RetornarCarrinhoId();

            return entities.ItemVendas.FirstOrDefault(x => x.ProdutoId == idProduto && x.CarrinhoId.Equals(idCarrinho));
        }

        public static List<ItemVenda> RetornarItensDoCarrinho()
        {
            string idCarrinho = RetornarCarrinhoId();

            return entities.ItemVendas.Include("Produto").Include("Produto.SubCategoria").Where(x => x.CarrinhoId.Equals(idCarrinho)).ToList();
        }

        public static ItemVenda RetornarItensDoCarrinho2(string idCarrinho)
        {
            return entities.ItemVendas.Include("Produto").Include("Produto.SubCategoria").FirstOrDefault(x => x.CarrinhoId.Equals(idCarrinho));
        }

        public static double RetornarValorTotalDoCarrinho()
        {
            return RetornarItensDoCarrinho().Sum(x => x.Preco * x.Quantidade);
        }

        public static int RetornarQuantidadeDoCarrinho()
        {
            return RetornarItensDoCarrinho().Sum(x => x.Quantidade);
        }
        public static void ZerarCarrinho()
        {
            HttpContext.Current.Session["CarrinhoId"] = null;
        }
    }
}