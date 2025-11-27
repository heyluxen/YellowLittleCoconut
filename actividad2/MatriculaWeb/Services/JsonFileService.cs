using System.Text.Json;
using WebMatricula.Models;

namespace WebMatricula.Services
{
    public class JsonFileService
    {
        private readonly string _filePath = "Data/matriculas.json";

        public List<Estudiante> LeerMatriculas()
        {
            if (!File.Exists(_filePath))
                return new List<Estudiante>();

            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Estudiante>>(json) ?? new List<Estudiante>();
        }

        public void GuardarMatriculas(List<Estudiante> matriculas)
        {
            var directory = Path.GetDirectoryName(_filePath);
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory!);

            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(matriculas, options);
            File.WriteAllText(_filePath, json);
        }

        public void AgregarMatricula(Estudiante estudiante)
        {
            var matriculas = LeerMatriculas();
            matriculas.Add(estudiante);
            GuardarMatriculas(matriculas);
        }
    }
}