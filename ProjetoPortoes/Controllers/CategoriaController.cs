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
using System.IO;

namespace ProjetoPortoes.Controllers
{

    //[Authorize]
    public class CategoriaController : Controller
    {

        // GET: Categoria
        public ActionResult Index()
        {
            return View(CategoriaDAO.ListarCategorias());
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoriaId,Nome,Descricao")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                if (CategoriaDAO.CadastrarCategoria(categoria))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Já existe uma categoria com o mesmo nome");
                }     
            }
            return View(categoria);
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = CategoriaDAO.BuscarCategoriaPorId(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = CategoriaDAO.BuscarCategoriaPorId(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categoria/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoriaId,Nome,Descricao")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                Categoria catAux = CategoriaDAO.BuscarCategoriaPorId(categoria.CategoriaId);
                catAux.Nome = categoria.Nome;
                catAux.Descricao = categoria.Descricao;
                if (CategoriaDAO.AtualizarCategoria(catAux))
                {
                    return RedirectToAction("Index");
                }
            }
            return View(categoria);
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = CategoriaDAO.BuscarCategoriaPorId(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Categoria categoria = CategoriaDAO.BuscarCategoriaPorId(id);
            if (CategoriaDAO.RemoverCategoria(categoria))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}