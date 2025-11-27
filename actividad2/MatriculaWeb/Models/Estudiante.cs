using System;

namespace WebMatricula.Models
{
    public class Estudiante : Persona
    {
        public string Curso { get; set; }
        public string NumeroMatricula { get; set; }

        public Estudiante() { }

        public Estudiante(int id, string nombres, string apellidos, string direccion, 
                         string email, int telefono, DateTime feNacimiento, DateTime feIngreso, 
                         string curso = "")
        {
            Id = id;
            Nombres = nombres;
            Apellidos = apellidos;
            Direccion = direccion;
            Email = email;
            Telefono = telefono;
            FeNacimiento = feNacimiento;
            FeIngreso = feIngreso;
            Curso = curso;
            NumeroMatricula = $"MAT-{Id}-{DateTime.Now:yyyyMMdd}";
        }

        public string GetInfoEstudiante()
        {
            return $"Estudiante: {Nombres} {Apellidos} - Matrícula: {NumeroMatricula} - Curso: {Curso}";
        }
    }
}