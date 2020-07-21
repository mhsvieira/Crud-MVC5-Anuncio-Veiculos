using AnuncioDeVeiculo.API;
using AnuncioDeVeiculo.Contexts;
using AnuncioDeVeiculo.Models;
using AnuncioDeVeiculo.Others;
using AnuncioDeVeiculo.Util;
using AnuncioDeVeiculo.ViewModels;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;

namespace AnuncioDeVeiculo.Controllers
{
    public class AnuncioController : Controller
    {
        private EFContext context = new EFContext();

        public ActionResult Listar()
        {
            return View(context.Anuncios);
        }

        public ActionResult Incluir()
        {
            ViewBag.Marca  = new SelectList(new APIAccess().GetMarcas(), "ID", "Name");

            ViewBag.Modelo = new SelectList(new APIAccess().GetModelos(0), "ID", "Name");

            ViewBag.Versao = new SelectList(new APIAccess().GetVersoes(0), "ID", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Incluir(AnuncioViewModel anuncioViewModel)
        {
            if (ModelState.IsValid)
            {
                var utilidades = new Utilidades();

                var anuncio = utilidades.ConverteParaAnuncio(anuncioViewModel);

                context.Anuncios.Add(anuncio);

                context.SaveChanges();

                TempData["Message"] = "ANÚNCIO INCLUÍDO COM SUCESSO";

                return RedirectToAction("Listar");
            }

            return View(anuncioViewModel);
        }

        public ActionResult Detalhar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Anuncio anuncio = context.Anuncios.Find(id);

            if (anuncio == null)
            {
                return HttpNotFound();
            }

            return View(anuncio);
        }

        public ActionResult Alterar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Anuncio anuncio = context.Anuncios.Find(id);

            if (anuncio == null)
            {
                return HttpNotFound();
            }

            var utilidades = new Utilidades();

            var anuncioViewModel = utilidades.ConverteParaAnuncioViewModel(anuncio);

            ViewBag.ListaMarca = new SelectList(new APIAccess().GetMarcas(), "ID", "Name");

            ViewBag.ListaModelo = new SelectList(new APIAccess().GetModelos(anuncioViewModel.MarcaId), "ID", "Name");

            ViewBag.ListaVersao = new SelectList(new APIAccess().GetVersoes(anuncioViewModel.ModeloId), "ID", "Name");

            return View(anuncioViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alterar(AnuncioViewModel anuncioViewModel)
        {
            if (ModelState.IsValid)
            {
                var utilidades = new Utilidades();

                var anuncio = utilidades.ConverteParaAnuncio(anuncioViewModel);

                context.Entry(anuncio).State = EntityState.Modified;

                context.SaveChanges();

                TempData["Message"] = "ANÚNCIO ALTERADO COM SUCESSO";

                return RedirectToAction("Listar");
            }

            return RedirectToAction("Listar");
        }

        public ActionResult Remover(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Anuncio anuncio = context.Anuncios.Find(id);

            if (anuncio == null)
            {
                return HttpNotFound();
            }

            return View(anuncio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remover(int id)
        {
            Anuncio anuncio = context.Anuncios.Find(id);

            context.Anuncios.Remove(anuncio);

            context.SaveChanges();

            TempData["Message"] = "ANÚNCIO REMOVIDO COM SUCESSO";

            return RedirectToAction("Listar");
        }

        public JsonResult GetListaModelos(int MarcaId)
        {
            var listaModelos = new APIAccess().GetModelos(MarcaId);

            return Json(listaModelos, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetListaVersoes(int ModeloId)
        {
            var listaVersoes = new APIAccess().GetVersoes(ModeloId);

            return Json(listaVersoes, JsonRequestBehavior.AllowGet);
        }
    }
}