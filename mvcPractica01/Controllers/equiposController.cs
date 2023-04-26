using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using mvcPractica01.Models;

namespace mvcPractica01.Controllers
{
    public class equiposController : Controller
    {
        private readonly equiposContext _equiposContext;

        public equiposController(equiposContext equiposContext) 
        {
            _equiposContext = equiposContext;
        }
        public IActionResult Index()
        {
            var listaDeMarcas=(from m in _equiposContext.marcas select m).ToList();

            ViewData["listadoDeMarcas"] = new SelectList(listaDeMarcas, "id_marcas", "nombre_marca");

            var listadoDeEquipos=(from e in _equiposContext.equipos join m in _equiposContext.marcas on e.marca_id equals m.id_marcas
                                  select new
                                  {
                                      nombre= e.nombre,
                                      descripcion= e.descripcion,
                                      marca_id= e.marca_id,
                                      marca_nombre=m.nombre_marca
                                  }).ToList();
            ViewData["listadoDeEquipos"] = listadoDeEquipos;

            var listaDeEstados = (from eq in _equiposContext.estados_equipo select eq).ToList();
            ViewData["listaDeEstados"] = new SelectList(listaDeEstados, "id_estados_equipo", "descripcion");
            
            
            var listaDeTipoEquipo = (from teq in _equiposContext.tipo_equipo select teq).ToList();
            ViewData["listaDeTipoEquipo"] = new SelectList(listaDeTipoEquipo, "id_tipo_equipo", "descripcion");
            return View();
        }

        public IActionResult CrearEquipos(equipos nuevoEquipo ) 
        {
            _equiposContext.Add(nuevoEquipo);
            _equiposContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
