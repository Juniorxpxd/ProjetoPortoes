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

namespace ProjetoPortoes.Controllers
{
    public class SubCategoriaController : Controller
    {
        private static int? idCategoria;
        // GET: SubCategoria

        public ActionResult SubCategorias(int? id)
        {
            idCategoria = id;
            return View(SubCategoriaDAO.BuscarSubCategoriasPorCategoria(id));
        }
        public ActionResult Inicio(int? id)
        {
            idCategoria = id;
            ViewBag.Categoria = CategoriaDAO.BuscarCategoriaPorId(id);
            return View(SubCategoriaDAO.ListarSubCategorias());
        }

        public ActionResult Index(int? id)
        {
            idCategoria = id;
            ViewBag.Categoria = CategoriaDAO.BuscarCategoriaPorId(id);
            return View(SubCategoriaDAO.ListarSubCategorias());
        }

        // GET: SubCategoria/Create
        public ActionResult Create()
        {
            ViewBag.Categorias = CategoriaDAO.ListarCategorias();
            return View();
        }

        // POST: SubCategoria/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file, [Bind(Include = "SubCategoriaId,CategoriaId,Nome,Descricao,Imagem")]SubCategoria subCategoria, int? id)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string pic = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/Imagens/"), pic);
                    file.SaveAs(path);
                    idCategoria = id;
                    subCategoria.Imagem = pic.ToString();  
                    subCategoria.Categoria = CategoriaDAO.BuscarCategoriaPorId(id);
                    if (SubCategoriaDAO.CadastrarSubCategoria(subCategoria))
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Já existe uma subcategoria com o mesmo nome");
                    }
                }
            }
            return View(subCategoria);
        }
        // GET: SubCategoria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategoria subCategoria = SubCategoriaDAO.BuscarSubCategoriaPorId(id);
            if (subCategoria == null)
            {
                return HttpNotFound();
            }
            return View(subCategoria);
        }

        // GET: SubCategoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.Categorias = CategoriaDAO.ListarCategorias();
            SubCategoria subCategoria = SubCategoriaDAO.BuscarSubCategoriaPorId(id);
            if (subCategoria == null)
            {
                return HttpNotFound();
            }
            return View(subCategoria);
        }

        // POST: SubCategoria/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase file, [Bind(Include = "SubCategoriaId,CategoriaId,Nome,Descricao,Imagem")] SubCategoria subCategoria)
        {
            if (ModelState.IsValid)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Imagens/"), pic);
                SubCategoria subCat = SubCategoriaDAO.BuscarSubCategoriaPorId(subCategoria.SubCategoriaId);
                file.SaveAs(path);
                subCat.Nome = subCategoria.Nome;
                subCat.Descricao = subCategoria.Descricao;
                subCat.CategoriaId = subCategoria.CategoriaId;
                subCat.Imagem = pic.ToString();
                if (SubCategoriaDAO.AtualizarSubCategoria(subCat))
                {
                    return RedirectToAction("Index");
                }
            }
            return View(subCategoria);
        }

        // GET: SubCategoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategoria subCategoria = SubCategoriaDAO.BuscarSubCategoriaPorId(id);
            if (subCategoria == null)
            {
                return HttpNotFound();
            }
            return View(subCategoria);
        }

        // POST: SubCategoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubCategoria subcategoria = SubCategoriaDAO.BuscarSubCategoriaPorId(id);
            if (SubCategoriaDAO.RemoverSubCategoria(subcategoria))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
