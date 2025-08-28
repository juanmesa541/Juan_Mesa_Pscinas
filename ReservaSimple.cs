using System;

namespace SistemaPiscinas
{
    public class Reserva
    {
        // Atributos básicos
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public Piscina Piscina { get; set; }
        public DateTime Fecha { get; set; }
        public int HoraInicio { get; set; } // Hora en formato 24h (ej: 14 para las 2pm)
        public int HoraFin { get; set; }
        public int NumeroPersonas { get; set; }
        public double Precio { get; set; }
        public EstadoReserva Estado { get; set; }

        // Constructor
        public Reserva(int id, Cliente cliente, Piscina piscina, DateTime fecha, int horaInicio, int horaFin, int personas)
        {
            Id = id;
            Cliente = cliente;
            Piscina = piscina;
            Fecha = fecha;
            HoraInicio = horaInicio;
            HoraFin = horaFin;
            NumeroPersonas = personas;
            Estado = EstadoReserva.Pendiente;
            Precio = CalcularPrecio();
        }

        // Método para calcular precio
        public double CalcularPrecio()
        {
            double precioBase = 20.0; // $20 por hora
            int horas = HoraFin - HoraInicio;
            double total = precioBase * horas;

            // Descuento para menores
            if (Cliente.EsMenor())
                total = total * 0.8; // 20% descuento

            // Recargo para premium
            if (Cliente.Tipo == TipoCliente.Premium)
                total = total * 1.2; // 20% recargo

            return total;
        }

        // Método para confirmar reserva
        public bool Confirmar()
        {
            if (Piscina.PuedeAceptar(NumeroPersonas))
            {
                Estado = EstadoReserva.Confirmada;
                Piscina.Estado = EstadoPiscina.Ocupada;
                return true;
            }
            return false;
        }

        // Método para cancelar reserva
        public void Cancelar()
        {
            Estado = EstadoReserva.Cancelada;
            if (Piscina.Estado == EstadoPiscina.Ocupada)
                Piscina.Estado = EstadoPiscina.Disponible;
        }

        // Método para mostrar información
        public void MostrarInfo()
        {
            Console.WriteLine($"Reserva #{Id}");
            Console.WriteLine($"Cliente: {Cliente.NombreCompleto()}");
            Console.WriteLine($"Piscina: {Piscina.Nombre}");
            Console.WriteLine($"Fecha: {Fecha:dd/MM/yyyy}");
            Console.WriteLine($"Horario: {HoraInicio}:00 - {HoraFin}:00");
            Console.WriteLine($"Personas: {NumeroPersonas}");
            Console.WriteLine($"Precio: ${Precio:F2}");
            Console.WriteLine($"Estado: {Estado}");
        }
    }
}
