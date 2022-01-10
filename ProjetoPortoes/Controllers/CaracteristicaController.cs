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
    public class CaracteristicaController : Controller
    {
        private static int? idProduto;

        public ActionResult Produtos(int? id)
        {
            idProduto = id;
            Caracteristicas caracteristicas = CaracteristicasDAO.BuscarCaracteristicasPorId(id);
            ViewBag.Caracteristicas = caracteristicas;
            return View(CaracteristicasDAO.BuscarCaracteristicasNoProduto(id));
        }

        public ActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caracteristicas caracteristicas = CaracteristicasDAO.BuscarCaracteristicasPorId(id);
            if (caracteristicas == null)
            {
                return HttpNotFound();
            }
            return View(caracteristicas);
        }

        // GET: Caracteristica
        public ActionResult Index()
        {
            return View(CaracteristicasDAO.ListarCaracteristicas());
        }

        // GET: Caracteristica/Create
        public ActionResult Create()
        {
            ViewBag.Produtos = ProdutoDAO.ListarProdutos();
            return View();
        }

        // POST: Caracteristica/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CaracteristicaId,ProdutoId,Imagem,Alimentacao,Motor,PotenciaMotor,PesoPortao,Consumo,Frequencia,RotacaoMotor,CoroaInterna," +
            "FimDeCurso,Capacitor,VelocidadeAbertura,CargaMaxima,Versoes,Fixacao,TamanhoTrilho,QuantidadeCiclosHora")]Caracteristicas caracteristicas, int? id)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(caracteristicas.Alimentacao))
                {
                    caracteristicas.Alimentacao = "Alimentação desconhecida";
                }
                if (string.IsNullOrWhiteSpace(caracteristicas.Capacitor))
                {
                    caracteristicas.Capacitor = "Capacitor desconhecido";
                }
                if (string.IsNullOrWhiteSpace(caracteristicas.CargaMaxima))
                {
                    caracteristicas.CargaMaxima = "Carga Máxima desconhecida";
                }
                if (string.IsNullOrWhiteSpace(caracteristicas.Consumo))
                {
                    caracteristicas.Consumo = "Consumo desconhecido";
                }
                if (string.IsNullOrWhiteSpace(caracteristicas.CoroaInterna))
                {
                    caracteristicas.CoroaInterna = "Coroa interna desconhecida";
                }
                if (string.IsNullOrWhiteSpace(caracteristicas.FimDeCurso))
                {
                    caracteristicas.FimDeCurso = "Fim de curso desconhecido";
                }
                if (string.IsNullOrWhiteSpace(caracteristicas.Fixacao))
                {
                    caracteristicas.Fixacao = "Fixação desconhecida";
                }
                if (string.IsNullOrWhiteSpace(caracteristicas.Frequencia))
                {
                    caracteristicas.Frequencia = "Frequência desconhecida";
                }
                if (string.IsNullOrWhiteSpace(caracteristicas.Motor))
                {
                    caracteristicas.Motor = "Motor desconhecido";
                }
                if (string.IsNullOrWhiteSpace(caracteristicas.PesoPortao))
                {
                    caracteristicas.PesoPortao = "Peso do portão desconhecido";
                }
                if (string.IsNullOrWhiteSpace(caracteristicas.PotenciaMotor))
                {
                    caracteristicas.PotenciaMotor = "Potência do motor desconhecido";
                }
                if (string.IsNullOrWhiteSpace(caracteristicas.QuantidadeCiclosHora.ToString()))
                {
                    caracteristicas.QuantidadeCiclosHora = 0;
                }
                if (string.IsNullOrWhiteSpace(caracteristicas.RotacaoMotor))
                {
                    caracteristicas.RotacaoMotor = "Rotação do motor desconhecido";
                }
                if (string.IsNullOrWhiteSpace(caracteristicas.TamanhoTrilho))
                {
                    caracteristicas.TamanhoTrilho = "Tamanho do trilho desconhecido";
                }
                if (string.IsNullOrWhiteSpace(caracteristicas.VelocidadeAbertura))
                {
                    caracteristicas.VelocidadeAbertura = "Velocidade desconhecida";
                }
                if (string.IsNullOrWhiteSpace(caracteristicas.Versoes))
                {
                    caracteristicas.Versoes = "Versão desconhecida";
                }
                caracteristicas.Produto = ProdutoDAO.BuscarProdutoPorId(id);
                ViewBag.Produto = ProdutoDAO.BuscarProdutoPorId(id);
                if (CaracteristicasDAO.CadastrarCaracteristicas(caracteristicas))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Já existe uma caracteristica nesse produto");
                }

            }

            return View(caracteristicas);
        }

        // GET: Caracteristica/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caracteristicas caracteristicas = CaracteristicasDAO.BuscarCaracteristicasPorId(id);
            if (caracteristicas == null)
            {
                return HttpNotFound();
            }
            return View(caracteristicas);
        }

        // GET: Caracteristica/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.Produtos = ProdutoDAO.ListarProdutos();
            Caracteristicas caracteristicas = CaracteristicasDAO.BuscarCaracteristicasPorId(id);
            if (caracteristicas == null)
            {
                return HttpNotFound();
            }
            return View(caracteristicas);
        }

        // POST: Caracteristica/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CaracteristicaId,ProdutoId,Imagem,Alimentacao,Motor,PotenciaMotor,PesoPortao,Consumo,Frequencia,RotacaoMotor,CoroaInterna,FimDeCurso,Capacitor,VelocidadeAbertura,CargaMaxima,Versoes,Fixacao,TamanhoTrilho,QuantidadeCiclosHora")] Caracteristicas caracteristicas)
        {
            if (ModelState.IsValid)
            {
                Caracteristicas carac = CaracteristicasDAO.BuscarCaracteristicasPorId(caracteristicas.CaracteristicaId);
                carac.ProdutoId = caracteristicas.ProdutoId;
                carac.Alimentacao = caracteristicas.Alimentacao;
                carac.Capacitor = caracteristicas.Capacitor;
                carac.CargaMaxima = caracteristicas.CargaMaxima;
                carac.Consumo = caracteristicas.Consumo;
                carac.CoroaInterna = caracteristicas.CoroaInterna;
                carac.FimDeCurso = caracteristicas.FimDeCurso;
                carac.Fixacao = caracteristicas.Fixacao;
                carac.Frequencia = caracteristicas.Frequencia;
                carac.Motor = caracteristicas.Motor;
                carac.PesoPortao = caracteristicas.PesoPortao;
                carac.PotenciaMotor = caracteristicas.PotenciaMotor;
                carac.QuantidadeCiclosHora = caracteristicas.QuantidadeCiclosHora;
                carac.RotacaoMotor = caracteristicas.RotacaoMotor;
                carac.TamanhoTrilho = caracteristicas.TamanhoTrilho;
                carac.VelocidadeAbertura = caracteristicas.VelocidadeAbertura;
                carac.Versoes = caracteristicas.Versoes;
                if (CaracteristicasDAO.AtualizarCaracteristicas(carac))
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            return View(caracteristicas);
        }

        // GET: Caracteristica/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caracteristicas caracteristicas = CaracteristicasDAO.BuscarCaracteristicasPorId(id);
            if (caracteristicas == null)
            {
                return HttpNotFound();
            }
            return View(caracteristicas);
        }

        // POST: Caracteristica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Caracteristicas caracteristicas = CaracteristicasDAO.BuscarCaracteristicasPorId(id);
            if (CaracteristicasDAO.RemoverCaracteristicas(caracteristicas))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
