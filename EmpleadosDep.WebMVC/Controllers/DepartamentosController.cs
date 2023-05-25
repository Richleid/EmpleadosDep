using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmpleadosDep.UAPI;
using EmpleadosDep.Modelos;

namespace EmpleadosDep.WebMVC.Controllers
{
    public class DepartamentosController : Controller
    {
        private string ApiUrl;
        private Crud<Departamento> Crud;

        public DepartamentosController(IConfiguration config)
        {
            ApiUrl = config["APIUrl"] + "/Departamentos";
            Crud = new Crud<Departamento>();
        }
        // GET: DepartamentosController
        public ActionResult Index()
        {
            var datos = Crud.Select(ApiUrl);
            return View(datos);
        }

        // GET: DepartamentosController/Details/5
        public ActionResult Details(int id)
        {
            var datos = Crud.Select_ById(ApiUrl, id.ToString());
            return View(datos);
        }

        // GET: DepartamentosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartamentosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Departamento datos)
        {
            try
            {
                Crud.Insert(ApiUrl, datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }

        // GET: DepartamentosController/Edit/5
        public ActionResult Edit(int id)
        {
            var datos = Crud.Select_ById(ApiUrl,id.ToString());
            return View(datos);
        }

        // POST: DepartamentosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Departamento datos)
        {
            try
            {
                Crud.Update(ApiUrl, id.ToString(), datos) ;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }

        // GET: DepartamentosController/Delete/5
        public ActionResult Delete(int id)
        {
            var datos = Crud.Select_ById(ApiUrl, id.ToString());
            return View(datos);
        }

        // POST: DepartamentosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Departamento datos)
        {
            try
            {
                Crud.Delete(ApiUrl, id.ToString());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }
    }
}
