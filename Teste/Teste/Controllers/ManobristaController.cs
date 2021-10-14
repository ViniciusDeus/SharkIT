using Data;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Teste.Controllers
{
    public class ManobristaController : Controller
    {
        // GET: Carro
        public ActionResult Index()
        {
            return View(ManobristaData.Listar());
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(Manobrista model)
        {
            try
            {
                ManobristaData.Criar(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //tratar excecao
                //seja por meio de padrao de mensageria ou retornar o erro para a tela
                return Content($"Ocorreu um erro, conte o administrador: {ex.Message}");
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            var objeto = ManobristaData.Listar().Where(x => x.idManobrista == id).FirstOrDefault();
            return View(objeto);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(Manobrista model)
        {
            try
            {
                ManobristaData.Atualizar(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //tratar excecao
                //seja por meio de padrao de mensageria ou retornar o erro para a tela
                return Content($"Ocorreu um erro, conte o administrador: {ex.Message}");
            }
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                ManobristaData.Excluir(id);
                return Json(new { Acao = "OK" });
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message);
            }

        }
    }
}