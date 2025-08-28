using System;

namespace SistemaPiscinas
{
    public class Mantenimiento
    {
        // Atributos básicos
        public int Id { get; set; }
        public Piscina Piscina { get; set; }
        public DateTime Fecha { get; set; }
        public TipoMantenimiento Tipo { get; set; }
        public string Descripcion { get; set; }
        public string Tecnico { get; set; }
        public double Costo { get; set; }
        public int DuracionHoras { get; set; }
        public bool Completado { get; set; }

        // Constructor
        public Mantenimiento(int id, Piscina piscina, DateTime fecha, TipoMantenimiento tipo, string descripcion, string tecnico, int duracion)
        {
            Id = id;
            Piscina = piscina;
            Fecha = fecha;
            Tipo = tipo;
            Descripcion = descripcion;
            Tecnico = tecnico;
            DuracionHoras = duracion;
            Completado = false;
            Costo = CalcularCosto();
        }

        // Método para calcular costo
        public double CalcularCosto()
        {
            double costoHora = 40.0; // $40 por hora
            double costoTotal = costoHora * DuracionHoras;

            // Costo adicional según tipo
            switch (Tipo)
            {
                case TipoMantenimiento.Limpieza:
                    costoTotal += 50;
                    break;
                case TipoMantenimiento.Reparacion:
                    costoTotal += 150;
                    break;
                case TipoMantenimiento.Revision:
                    costoTotal += 30;
                    break;
            }

            return costoTotal;
        }

        // Método para iniciar mantenimiento
        public void Iniciar()
        {
            Piscina.Estado = EstadoPiscina.Mantenimiento;
            Console.WriteLine($"Mantenimiento iniciado en {Piscina.Nombre}");
        }

        // Método para finalizar mantenimiento
        public void Finalizar()
        {
            Completado = true;
            Piscina.Estado = EstadoPiscina.Disponible;
            Console.WriteLine($"Mantenimiento completado en {Piscina.Nombre}");
        }

        // Método para mostrar información
        public void MostrarInfo()
        {
            Console.WriteLine($"Mantenimiento #{Id}");
            Console.WriteLine($"Piscina: {Piscina.Nombre}");
            Console.WriteLine($"Tipo: {Tipo}");
            Console.WriteLine($"Descripción: {Descripcion}");
            Console.WriteLine($"Técnico: {Tecnico}");
            Console.WriteLine($"Fecha: {Fecha:dd/MM/yyyy}");
            Console.WriteLine($"Duración: {DuracionHoras} horas");
            Console.WriteLine($"Costo: ${Costo:F2}");
            Console.WriteLine($"Estado: {(Completado ? "Completado" : "Pendiente")}");
        }
    }
}
