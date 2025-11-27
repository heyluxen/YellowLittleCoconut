using Microsoft.AspNetCore.Mvc;
using WebMatricula.Models;
using WebMatricula.Services;

namespace WebMatricula.Controllers
{
    public class MatriculaController : Controller
    {
        private readonly JsonFileService _jsonService;

        public MatriculaController(JsonFileService jsonService)
        {
            _jsonService = jsonService;
        }

        public IActionResult Index()
        {
            var matriculas = _jsonService.LeerMatriculas();
            return View(matriculas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                // Generar ID automático
                var matriculas = _jsonService.LeerMatriculas();
                estudiante.Id = matriculas.Count > 0 ? matriculas.Max(e => e.Id) + 1 : 1;
                estudiante.FeIngreso = DateTime.Now;
                estudiante.NumeroMatricula = $"MAT-{estudiante.Id}-{DateTime.Now:yyyyMMdd}";

                _jsonService.AgregarMatricula(estudiante);
                
                TempData["Mensaje"] = "Matrícula registrada exitosamente!";
                return RedirectToAction("Index");
            }
            return View(estudiante);
        }
    }
}