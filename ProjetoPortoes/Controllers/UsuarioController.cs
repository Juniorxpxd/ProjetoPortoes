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
    public class UsuarioController : Controller
    {

        public ActionResult Usuario()
        {
            Usuario usu = new Usuario();
            Venda venda = new Venda();
            ItemVenda itemv = new ItemVenda();
            if (Request.IsAuthenticated)
            {
                usu.Login = HttpContext.User.Identity.Name;
            }
            usu = UsuarioDAO.BuscarUsuarioPorLogin(usu);
            venda.Usuario = UsuarioDAO.BuscarUsuarioPorLogin(usu);
            if (venda.Usuario == usu)
            {
                venda = VendaDAO.BuscarVendaPorUsuario3(usu);
                itemv = ItemVendaDAO.RetornarItensDoCarrinho2(venda.CarrinhoId);
                if (venda.CarrinhoId == itemv.CarrinhoId)
                {
                    ViewBag.ItemVenda = itemv;
                    ViewBag.Venda = venda;
                    return View(UsuarioDAO.BuscarUsuarioPorLogin(usu));
                }
            }
            return View(UsuarioDAO.ListarUsuarios());
        }

        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UsuarioId,Nome,Login,Senha,ConfSenha,Telefone,Estado,Cidade,Endereco,Complemento,Numero,CEP,CPF")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                UsuarioDAO.CadastrarUsuario(usuario);
                return RedirectToAction("Login");
            }
            return View(usuario);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = UsuarioDAO.BuscarUsuarioPorId(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = UsuarioDAO.BuscarUsuarioPorId(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UsuarioId,Nome,Login,Senha,Telefone,Estado,Cidade,Endereco,Complemento,Numero,CEP,CPF")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                Usuario usu = UsuarioDAO.BuscarUsuarioPorId(usuario.UsuarioId);
                usu.Nome = usuario.Nome;
                usu.CEP = usu.CEP;
                usu.Cidade = usuario.Cidade;
                usu.Complemento = usuario.Complemento;
                usu.ConfSenha = usuario.ConfSenha;
                usu.CPF = usuario.CPF;
                usu.Endereco = usuario.Endereco;
                usu.Estado = usuario.Estado;
                usu.Login = usuario.Login;
                usu.Numero = usuario.Numero;
                usu.Senha = usuario.Senha;
                usu.Telefone = usuario.Telefone;
                if (UsuarioDAO.AtualizarUsuario(usu))
                {
                    return RedirectToAction("Index");
                }
            }
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = UsuarioDAO.BuscarUsuarioPorId(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = UsuarioDAO.BuscarUsuarioPorId(id);
            if (UsuarioDAO.RemoverUsuario(usuario))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login([Bind(Include = "Login,Senha")]Usuario usuario, bool chkConectado)
        {
            if (UsuarioDAO.BuscarUsuarioPorLoginESenha(usuario) != null)
            {
                // Autenticar
                FormsAuthentication.SetAuthCookie(usuario.Login, chkConectado);
                return RedirectToAction("Inicio", "SubCategoria");
            }
            else
            {
                ModelState.AddModelError("", "E-mail ou senha não coincidem!");
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Inicio", "SubCategoria");
        }
    }
}
