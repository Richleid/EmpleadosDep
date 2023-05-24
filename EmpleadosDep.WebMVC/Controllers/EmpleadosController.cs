using EmpleadosDep.Modelos;
using EmpleadosDep.UAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmpleadosDep.WebMVC.Controllers
{
    public class EmpleadosController : Controller
    {
        private Crud <Empleado> empleados = new Crud<Empleado> ();
        private string Url = "https://localhost:7119/api/Empleados";
        // GET: EmpleadosController
        public ActionResult Index()
        {
            var datos = empleados.Select(Url);
            return View(datos);
        }

        // GET: EmpleadosController/Details/5
        public ActionResult Details(int id)
        {
            var datos = empleados.Select_ById(Url, id.ToString());
            return View(datos);
        }

        // GET: EmpleadosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpleadosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Empleado datos)
        {
            try
            {
                empleados.Insert(Url, datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }

        // GET: EmpleadosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmpleadosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Empleado datos)
        {
            try
            {
                empleados.Update(Url, id.ToString(), datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }

        // GET: EmpleadosController/Delete/5
        public ActionResult Delete(int id)
        {
            var datos = empleados.Select_ById(Url,id.ToString());
            return View(datos);
        }

        // POST: EmpleadosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,Empleado datos)
        {
            try
            {
                empleados.Delete(Url, id.ToString());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }
    }
}
