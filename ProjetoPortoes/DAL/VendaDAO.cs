using ProjetoPortoes.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjetoPortoes.DAL
{
    public class VendaDAO
    {
        private static Entities entities = Singleton.Instance.Entities;
        private static ItemVenda itemVendas = new ItemVenda();
        public static List<Venda> ListarVendas()
        {
            return entities.Vendas.Include("Itens").ToList();
        }
        public static bool CadastrarVendas(Venda vendas)
        {
            try
            {
                entities.Vendas.Add(vendas);
                entities.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static Venda BuscarVendasPorId(int? id)
        {
            return entities.Vendas.Find(id);
        }
        public static List<Venda> BuscarVendaPorUsuario(int? id)
        {
            return entities.Vendas.Include("Usuario").Include("Itens").Where(x => x.Usuario.UsuarioId == id).ToList();
        }
        public static List<Venda> BuscarVendaPorUsuario2(Usuario usu)
        {
            return entities.Vendas.Include("Usuario").Include("Itens").Where(x => x.Usuario.UsuarioId == usu.UsuarioId).ToList();
        }
        public static Venda BuscarVendaPorUsuario3(Usuario usu)
        {
            return entities.Vendas.Include("Usuario").Include("Itens").FirstOrDefault(x => x.Usuario.UsuarioId == usu.UsuarioId);
        }
        public static List<Venda> BuscarVendaPorCarrinho(string id)
        {
            return entities.Vendas.Include("Usuario").Include("Itens").Where(x => x.CarrinhoId.Equals(id)).ToList();
        }
    }
}