using System;

namespace WebMatricula.Models
{
    // Clase base que representa a una persona en el sistema
    public class Persona
    {
        public int Id { get; set; }                     // Identificador único
        public string Nombres { get; set; }            // Nombres de la persona
        public string Apellidos { get; set; }          // Apellidos de la persona  
        public string Direccion { get; set; }          // Dirección de residencia
        public string Email { get; set; }              // Correo electrónico
        public int Telefono { get; set; }              // Número de teléfono
        public DateTime FeNacimiento { get; set; }     // Fecha de nacimiento
        public DateTime FeIngreso { get; set; }        // Fecha de ingreso al sistema
    }
}