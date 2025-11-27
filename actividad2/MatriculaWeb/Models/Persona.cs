using System;

namespace WebMatricula.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }
        public DateTime FeNacimiento { get; set; }
        public DateTime FeIngreso { get; set; }
    }
}