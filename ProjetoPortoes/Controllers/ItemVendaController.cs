using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoPortoes.Models;
using ProjetoPortoes.DAL;
using System.Web.Security;

namespace ProjetoPortoes.Controllers
{
    public class ItemVendaController : Controller
    {
        private static int? idProduto;

        public ActionResult RemoverDoCarrinho(int? id)
        {
            idProduto = id;
            ItemVendaDAO.RemoverItemVendas(id);
            return RedirectToAction("CarrinhoCompras","ItemVenda");
        }

        public ActionResult Checkout(int? id)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Create", "Usuario");
            }
            ItemVenda itemVenda = new ItemVenda();
            itemVenda.Produto = ProdutoDAO.BuscarProdutoPorId(idProduto);
            if (itemVenda.Produto == null)
            {
                return RedirectToAction("Inicio","SubCategoria");
            }
            return View(ItemVendaDAO.RetornarItensDoCarrinho());
        }

        public ActionResult CarrinhoCompras(int? id)
        {
            ViewBag.Total = ItemVendaDAO.RetornarValorTotalDoCarrinho().ToString("C2");
            return View(ItemVendaDAO.RetornarItensDoCarrinho());
        }

        // GET: ItemVenda
        public ActionResult Index()
        {
            return View(ItemVendaDAO.ListarItemVendas());
        }

        // GET: ItemVenda/Create
        public ActionResult Create(int? id)
        {
            idProduto = id;
            ItemVendaDAO.AdicionarItemVendas(id);
            return View("CarrinhoCompras");
        }

        // GET: ItemVenda/Edit/5
    }
}
