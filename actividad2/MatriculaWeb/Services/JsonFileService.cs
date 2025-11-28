using System.Text.Json;
using WebMatricula.Models;

namespace WebMatricula.Services
{
    // Servicio para manejar operaciones con archivos JSON de estudiantes
    public class JsonFileService
    {
        private readonly string _filePath = "Data/matriculas.json";

        // Lee todas las matrículas del archivo JSON
        public List<Estudiante> LeerMatriculas()
        {
            // Si el archivo no existe, retorna lista vacía
            if (!File.Exists(_filePath))
                return new List<Estudiante>();

            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Estudiante>>(json) ?? new List<Estudiante>();
        }

        // Guarda la lista completa de estudiantes en JSON
        public void GuardarMatriculas(List<Estudiante> matriculas)
        {
            // Crea el directorio si no existe
            var directory = Path.GetDirectoryName(_filePath);
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory!);

            // Serializa con formato legible
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(matriculas, options);
            File.WriteAllText(_filePath, json);
        }

        // Agrega un nuevo estudiante al archivo
        public void AgregarMatricula(Estudiante estudiante)
        {
            var matriculas = LeerMatriculas();
            matriculas.Add(estudiante);
            GuardarMatriculas(matriculas);
        }
    }
}