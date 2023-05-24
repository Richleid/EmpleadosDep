using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmpleadosDep.UAPI;
using EmpleadosDep.Modelos;

namespace EmpleadosDep.WebMVC.Controllers
{
    public class DepartamentosController : Controller
    {
        private string Url = "https://localhost:7119/api/Departamentos";
        private Crud<Departamento> Crud = new Crud<Departamento>();

        // GET: DepartamentosController
        public ActionResult Index()
        {
            var datos = Crud.Select(Url);
            return View(datos);
        }

        // GET: DepartamentosController/Details/5
        public ActionResult Details(int id)
        {
            var datos = Crud.Select_ById(Url, id.ToString());
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
                Crud.Insert(Url, datos);
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
            return View();
        }

        // POST: DepartamentosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Departamento datos)
        {
            try
            {
                Crud.Update(Url, id.ToString(), datos) ;
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
            var datos = Crud.Select_ById(Url, id.ToString());
            return View(datos);
        }

        // POST: DepartamentosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Departamento datos)
        {
            try
            {
                Crud.Delete(Url, id.ToString());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }
    }
}
