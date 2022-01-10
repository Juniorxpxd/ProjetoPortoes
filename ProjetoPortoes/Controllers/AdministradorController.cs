using System.IO.Packaging;

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

    public class AdministradorController : Controller
    {
        [Authorize(Users = "juninho@hotmail.com")]
        // GET: Administrador
        public ActionResult Index()
        {
            return View(AdministradorDAO.ListarAdministradores());
        }
        [Authorize(Users = "juninho@hotmail.com")]
        // GET: Administrador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrador administrador = AdministradorDAO.BuscarAdministradoresPorId(id);
            if (administrador == null)
            {
                return HttpNotFound();
            }
            return View(administrador);
        }
        [Authorize(Users = "juninho@hotmail.com")]
        // GET: Administrador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Users = "juninho@hotmail.com")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdmId,Nome,Login,Senha")] Administrador administrador)
        {
            if (ModelState.IsValid)
            {
                if (AdministradorDAO.CadastrarAdministradores(administrador))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Já existe um administrador com o mesmo nome");
                }
            }

            return View(administrador);
        }
        [Authorize(Users = "juninho@hotmail.com")]
        // GET: Administrador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrador administrador = AdministradorDAO.BuscarAdministradoresPorId(id);
            if (administrador == null)
            {
                return HttpNotFound();
            }
            return View(administrador);
        }

        // POST: Administrador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Users = "juninho@hotmail.com")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdmId,Nome,Login,Senha")] Administrador administrador)
        {
            if (ModelState.IsValid)
            {
                Administrador adm = AdministradorDAO.BuscarAdministradoresPorId(administrador.AdmId);
                adm.Login = administrador.Login;
                adm.Nome = administrador.Nome;
                adm.Senha = administrador.Senha;
                if (AdministradorDAO.AtualizarAdministradores(adm))
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            return View(administrador);
        }

        // GET: Administrador/Delete/5
        [Authorize(Users = "juninho@hotmail.com")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrador administrador = AdministradorDAO.BuscarAdministradoresPorId(id);
            if (administrador == null)
            {
                return HttpNotFound();
            }
            return View(administrador);
        }

        // POST: Administrador/Delete/5
        [Authorize(Users = "juninho@hotmail.com")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Administrador administrador = AdministradorDAO.BuscarAdministradoresPorId(id);
            if (AdministradorDAO.RemoverAdministradores(administrador))
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
        public ActionResult Login([Bind(Include = "Login,Senha")]Administrador adm, bool chkConectado)
        {
            if (AdministradorDAO.BuscarAdministradorPorLoginESenha(adm) != null)
            {
                // Autenticar
                FormsAuthentication.SetAuthCookie(adm.Login, chkConectado);
                return RedirectToAction("Inicio", "SubCategoria");
            }
            else
            {
                ModelState.AddModelError("", "E-mail ou senha não coincidem!");
                return View();
            }
        }
    }
}
