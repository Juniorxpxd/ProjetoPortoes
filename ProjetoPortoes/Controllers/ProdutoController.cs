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
    public class ProdutoController : Controller
    {
        private static int? idSubCategoria;
        private static int? idCaracteristica;

        public ActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = ProdutoDAO.BuscarProdutoPorId(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        public ActionResult Produtos(int id)
        {
            Produto prod = new Produto();
            Caracteristicas carac = new Caracteristicas();
            carac.ProdutoId = id;
            carac = CaracteristicasDAO.BuscarProdutoNaCaracteristica(carac);
            //Caracteristicas caracteristicas = CaracteristicasDAO.BuscarCaracteristicasPorId(id);
            //idCaracteristica = id;
            ViewBag.Caracteristicas = carac;
            return View(ProdutoDAO.BuscarProdutosPorSubCategoria(id));
        }

        // GET: Produto
        public ActionResult Index(int? id)
        {
            idSubCategoria = id;
            ViewBag.SubCategoria = SubCategoriaDAO.BuscarSubCategoriaPorId(id);
            return View(ProdutoDAO.ListarProdutos());
        }

        // GET: Produto/Create
        public ActionResult Create(int? id)
        {
            ViewBag.SubCategorias = SubCategoriaDAO.ListarSubCategorias();
            return View();
        }

        // POST: Produto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file, [Bind(Include = "ProdutoId,SubCategoriaId,Nome,Descricao,Preco,Quantidade,Imagem")]Produto produto, int? id)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string pic = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/Imagens/"), pic);
                    SubCategoria subcat = new SubCategoria();
                    idSubCategoria = id;
                    file.SaveAs(path);
                    produto.Imagem = pic.ToString();
                    ViewBag.SubCategoria = SubCategoriaDAO.BuscarSubCategoriaPorId(id);
                    produto.SubCategoria = SubCategoriaDAO.BuscarSubCategoriaPorId(id);
                    if (ProdutoDAO.CadastrarProduto(produto))
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Já existe um produto com o mesmo nome");
                    }
                }

            }
            return View(produto);
        }

        // GET: Produto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = ProdutoDAO.BuscarProdutoPorId(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.SubCategorias = SubCategoriaDAO.ListarSubCategorias();
            Produto produto = ProdutoDAO.BuscarProdutoPorId(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase file, [Bind(Include = "ProdutoId,SubCategoriaId,Nome,Descricao,Preco,Quantidade,Imagem")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Imagens/"), pic);
                Produto prod = ProdutoDAO.BuscarProdutoPorId(produto.ProdutoId);
                file.SaveAs(path);
                prod.Nome = produto.Nome;
                prod.Imagem = pic.ToString();
                prod.SubCategoriaId = produto.SubCategoriaId;
                prod.Descricao = produto.Descricao;
                prod.Preco = produto.Preco;
                prod.Quantidade = produto.Quantidade;
                if (ProdutoDAO.AtualizarProduto(prod))
                {
                    return RedirectToAction("Index");
                }
            }
            return View(produto);
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = ProdutoDAO.BuscarProdutoPorId(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = ProdutoDAO.BuscarProdutoPorId(id);
            if (ProdutoDAO.RemoverProduto(produto))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
