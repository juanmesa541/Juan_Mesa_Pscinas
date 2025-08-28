using System;

namespace SistemaPiscinas
{
    public class Piscina
    {
        // Atributos básicos
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CapacidadMaxima { get; set; }
        public double Largo { get; set; }
        public double Ancho { get; set; }
        public double Profundidad { get; set; }
        public TipoAgua TipoAgua { get; set; }
        public EstadoPiscina Estado { get; set; }
        
        // Constructor
        public Piscina(int id, string nombre, int capacidad, double largo, double ancho, double profundidad, TipoAgua tipo)
        {
            Id = id;
            Nombre = nombre;
            CapacidadMaxima = capacidad;
            Largo = largo;
            Ancho = ancho;
            Profundidad = profundidad;
            TipoAgua = tipo;
            Estado = EstadoPiscina.Disponible;
        }

        // Método para calcular volumen
        public double CalcularVolumen()
        {
            return Largo * Ancho * Profundidad;
        }

        // Método para verificar si puede aceptar cierto número de personas
        public bool PuedeAceptar(int personas)
        {
            return personas <= CapacidadMaxima && Estado == EstadoPiscina.Disponible;
        }

        // Método para mostrar información
        public void MostrarInfo()
        {
            Console.WriteLine($"Piscina: {Nombre}");
            Console.WriteLine($"Capacidad: {CapacidadMaxima} personas");
            Console.WriteLine($"Dimensiones: {Largo}x{Ancho}x{Profundidad}m");
            Console.WriteLine($"Volumen: {CalcularVolumen():F1} m³");
            Console.WriteLine($"Tipo de agua: {TipoAgua}");
            Console.WriteLine($"Estado: {Estado}");
        }
    }
}
