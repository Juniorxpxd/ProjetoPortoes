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
    public class VendaController : Controller
    {
        private static int? idVenda;
        private static int? idUsuario;

        public ActionResult FinalizarCompra()
        {
            Usuario usu = new Usuario();
            if (Request.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Inicio","SubCategoria");
        }

        // GET: Venda
        public ActionResult Index()
        {
            return View(VendaDAO.ListarVendas());
        }

        // GET: Venda/Create
        public ActionResult Create(Venda venda)
        {
            Usuario usu = new Usuario();
            ItemVenda itemv = new ItemVenda();
            if (Request.IsAuthenticated)
            {
                usu.Login = HttpContext.User.Identity.Name;
            }
            venda.Usuario = UsuarioDAO.BuscarUsuarioPorLogin(usu);
            venda.DataDaVenda = DateTime.Now;
            venda.Itens = ItemVendaDAO.RetornarItensDoCarrinho();
            venda.CarrinhoId = ItemVendaDAO.RetornarCarrinhoId();
            VendaDAO.CadastrarVendas(venda);
            ItemVendaDAO.ZerarCarrinho();
            return RedirectToAction("FinalizarCompra");
        }
        public ActionResult Usuario(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = VendaDAO.BuscarVendasPorId(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }
    }
}
