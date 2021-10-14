using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace Teste.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View(Data.UsuarioData.Listar());
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(Usuario model)
        {
            try
            {
                Data.UsuarioData.Criar(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //tratar excecao
                //seja por meio de padrao de mensageria ou retornar o erro para a tela
                return Content($"Ocorreu um erro, conte o administrador: {ex.Message}" );
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            var objeto = Data.UsuarioData.Listar().Where(x => x.Id == id).FirstOrDefault();
            return View(objeto);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(Usuario model)
        {
            try
            {
                Data.UsuarioData.Atualizar(model);
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
                Data.UsuarioData.Excluir(id);
                return Json(new { Acao = "OK" });
            }
            catch(Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message);
            }
        }
    }
}
