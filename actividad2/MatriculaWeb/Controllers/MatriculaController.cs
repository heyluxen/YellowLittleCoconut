using Microsoft.AspNetCore.Mvc;
using WebMatricula.Models;
using WebMatricula.Services;

namespace WebMatricula.Controllers
{
    public class MatriculaController : Controller
    {
        // Servicio para manejar operaciones con archivos JSON
        private readonly JsonFileService _jsonService;

        // Constructor con inyección de dependencia del servicio
        public MatriculaController(JsonFileService jsonService)
        {
            _jsonService = jsonService;
        }

        // Acción para mostrar la lista de todas las matrículas
        public IActionResult Index()
        {
            // Obtener todas las matrículas del servicio JSON
            var matriculas = _jsonService.LeerMatriculas();
            // Pasar la lista de matrículas a la vista
            return View(matriculas);
        }

        // Acción GET para mostrar el formulario de creación de matrícula
        public IActionResult Create()
        {
            // Retorna una vista vacía con el formulario
            return View();
        }

        // Acción POST para procesar el formulario de creación
        [HttpPost]
        public IActionResult Create(Estudiante estudiante)
        {
            // Validar si los datos del modelo son válidos
            if (ModelState.IsValid)
            {
                // Obtener todas las matrículas existentes
                var matriculas = _jsonService.LeerMatriculas();
                
                // Generar ID automático: 
                // Si hay matrículas existentes, toma el ID máximo y le suma 1
                // Si no hay matrículas, asigna ID = 1
                estudiante.Id = matriculas.Count > 0 ? matriculas.Max(e => e.Id) + 1 : 1;
                
                // Asignar fecha y hora actual del sistema
                estudiante.FeIngreso = DateTime.Now;
                
                // Generar número de matrícula único con formato: MAT-ID-FECHA
                estudiante.NumeroMatricula = $"MAT-{estudiante.Id}-{DateTime.Now:yyyyMMdd}";

                // Guardar la nueva matrícula en el archivo JSON
                _jsonService.AgregarMatricula(estudiante);
                
                // Mostrar mensaje de éxito (se usa TempData para persistir entre redirecciones)
                TempData["Mensaje"] = "Matrícula registrada exitosamente!";
                
                // Redirigir al listado de matrículas
                return RedirectToAction("Index");
            }
            
            // Si el modelo no es válido, volver a mostrar el formulario con los errores
            return View(estudiante);
        }
    }
}