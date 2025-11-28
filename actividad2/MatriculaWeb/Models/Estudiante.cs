using System;

namespace WebMatricula.Models
{
    // La clase Estudiante hereda de la clase Persona (hereda todas sus propiedades y métodos)
    public class Estudiante : Persona
    {
        // Propiedad específica del estudiante: curso al que está matriculado
        public string Curso { get; set; }

        // Número único de matrícula generado automáticamente
        public string NumeroMatricula { get; set; }

        // Constructor por defecto (sin parámetros) - Requerido para ASP.NET MVC
        public Estudiante() { }

        // Constructor completo con todos los parámetros para inicializar un estudiante
        public Estudiante(int id, string nombres, string apellidos, string direccion, 
                         string email, int telefono, DateTime feNacimiento, DateTime feIngreso, 
                         string curso = "")  // Parámetro opcional con valor por defecto
        {
            // Propiedades heredadas de la clase Persona
            Id = id;
            Nombres = nombres;
            Apellidos = apellidos;
            Direccion = direccion;
            Email = email;
            Telefono = telefono;
            FeNacimiento = feNacimiento;
            FeIngreso = feIngreso;
            
            // Propiedades específicas de Estudiante
            Curso = curso;
            
            // Genera automáticamente el número de matrícula con formato: MAT-ID-FECHA
            // Ejemplo: MAT-1-20231215
            NumeroMatricula = $"MAT-{Id}-{DateTime.Now:yyyyMMdd}";
        }

        // Método que retorna información formateada del estudiante
        public string GetInfoEstudiante()
        {
            return $"Estudiante: {Nombres} {Apellidos} - Matrícula: {NumeroMatricula} - Curso: {Curso}";
        }
    }
}