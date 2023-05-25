using EmpleadosDep.Modelos;
using EmpleadosDep.UAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmpleadosDep.WebMVC.Controllers
{
    public class EmpleadosController : Controller
    {
        private string ApiUrl;
        private Crud<Empleado> Crud;
        public EmpleadosController(IConfiguration config)
        {
            ApiUrl = config["APIUrl"] + "/Empleados";
            Crud = new Crud<Empleado>();
        }
        // GET: EmpleadosController
        public ActionResult Index()
        {
            var datos = Crud.Select(ApiUrl);
            return View(datos);
        }

        // GET: EmpleadosController/Details/5
        public ActionResult Details(int id)
        {
            var datos = Crud.Select_ById(ApiUrl, id.ToString());
            return View(datos);
        }

        // GET: EmpleadosController/Create
        public ActionResult Create()
        {
            //Obtenemos la lista de departamentos para que sea usada en la vista en un combobox
            var listaDepartamentos = new Crud<Departamento>()
                .Select(ApiUrl.Replace("Empleados", "Departamentos"))
                .Select(d => new SelectListItem  //Transformamos del tipo Departamento a seleclistItem
                {
                    Value = d.DepartamentoId.ToString(), //id Departamento
                    Text = d.Nombre                      // Nombre departamento
                })
                .ToList();
            ViewBag.ListaDepartamentos = listaDepartamentos; //Pasamos la lista de departamentos a la vista
            return View();
        }

        // POST: EmpleadosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Empleado datos)
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

        // GET: EmpleadosController/Edit/5
        public ActionResult Edit(int id)
        {
            var datos = Crud.Select_ById(ApiUrl, id.ToString());
            return View(datos);
        }

        // POST: EmpleadosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Empleado datos)
        {
            try
            {
                Crud.Update(ApiUrl, id.ToString(), datos);
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
            var datos = Crud.Select_ById(ApiUrl, id.ToString());
            return View(datos);
        }

        // POST: EmpleadosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Empleado datos)
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
