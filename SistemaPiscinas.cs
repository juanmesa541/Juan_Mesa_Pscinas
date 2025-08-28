using System;

namespace SistemaPiscinas
{
    // Enumeraciones básicas
    public enum TipoAgua { Dulce, Salada, Clorada }
    public enum EstadoPiscina { Disponible, Ocupada, Mantenimiento }
    public enum EstadoReserva { Pendiente, Confirmada, Cancelada }
    public enum TipoCliente { Regular, Premium }
    public enum TipoMantenimiento { Limpieza, Reparacion, Revision }

    // Clase Piscina
    public class Piscina
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CapacidadMaxima { get; set; }
        public double Largo { get; set; }
        public double Ancho { get; set; }
        public double Profundidad { get; set; }
        public TipoAgua TipoAgua { get; set; }
        public EstadoPiscina Estado { get; set; }
        
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

        public double CalcularVolumen()
        {
            return Largo * Ancho * Profundidad;
        }

        public bool PuedeAceptar(int personas)
        {
            return personas <= CapacidadMaxima && Estado == EstadoPiscina.Disponible;
        }

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

    // Clase Cliente
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public TipoCliente Tipo { get; set; }

        public Cliente(int id, string nombre, string apellido, string email, string telefono, DateTime fechaNacimiento)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Telefono = telefono;
            FechaNacimiento = fechaNacimiento;
            Tipo = TipoCliente.Regular;
        }

        public int CalcularEdad()
        {
            int edad = DateTime.Now.Year - FechaNacimiento.Year;
            if (DateTime.Now.Month < FechaNacimiento.Month)
                edad--;
            return edad;
        }

        public string NombreCompleto()
        {
            return Nombre + " " + Apellido;
        }

        public bool EsMenor()
        {
            return CalcularEdad() < 18;
        }

        public void MostrarInfo()
        {
            Console.WriteLine($"Cliente: {NombreCompleto()}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Teléfono: {Telefono}");
            Console.WriteLine($"Edad: {CalcularEdad()} años");
            Console.WriteLine($"Tipo: {Tipo}");
            Console.WriteLine($"Menor de edad: {(EsMenor() ? "Sí" : "No")}");
        }
    }

    // Clase Reserva
    public class Reserva
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public Piscina Piscina { get; set; }
        public DateTime Fecha { get; set; }
        public int HoraInicio { get; set; }
        public int HoraFin { get; set; }
        public int NumeroPersonas { get; set; }
        public double Precio { get; set; }
        public EstadoReserva Estado { get; set; }

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

        public double CalcularPrecio()
        {
            double precioBase = 20.0;
            int horas = HoraFin - HoraInicio;
            double total = precioBase * horas;

            if (Cliente.EsMenor())
                total = total * 0.8;

            if (Cliente.Tipo == TipoCliente.Premium)
                total = total * 1.2;

            return total;
        }

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

        public void Cancelar()
        {
            Estado = EstadoReserva.Cancelada;
            if (Piscina.Estado == EstadoPiscina.Ocupada)
                Piscina.Estado = EstadoPiscina.Disponible;
        }

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

    // Clase Mantenimiento
    public class Mantenimiento
    {
        public int Id { get; set; }
        public Piscina Piscina { get; set; }
        public DateTime Fecha { get; set; }
        public TipoMantenimiento Tipo { get; set; }
        public string Descripcion { get; set; }
        public string Tecnico { get; set; }
        public double Costo { get; set; }
        public int DuracionHoras { get; set; }
        public bool Completado { get; set; }

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

        public double CalcularCosto()
        {
            double costoHora = 40.0;
            double costoTotal = costoHora * DuracionHoras;

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

        public void Iniciar()
        {
            Piscina.Estado = EstadoPiscina.Mantenimiento;
            Console.WriteLine($"Mantenimiento iniciado en {Piscina.Nombre}");
        }

        public void Finalizar()
        {
            Completado = true;
            Piscina.Estado = EstadoPiscina.Disponible;
            Console.WriteLine($"Mantenimiento completado en {Piscina.Nombre}");
        }

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

    // Programa principal
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SISTEMA DE PISCINAS ===");
            Console.WriteLine();

            // Crear piscinas
            Console.WriteLine("1. CREANDO PISCINAS:");
            Piscina piscina1 = new Piscina(1, "Piscina Grande", 40, 25, 12, 2, TipoAgua.Clorada);
            Piscina piscina2 = new Piscina(2, "Piscina Pequeña", 20, 15, 8, 1.5, TipoAgua.Dulce);
            
            piscina1.MostrarInfo();
            Console.WriteLine();
            piscina2.MostrarInfo();
            Console.WriteLine();

            // Crear clientes
            Console.WriteLine("2. CREANDO CLIENTES:");
            Cliente cliente1 = new Cliente(1, "Juan", "Pérez", "juan@email.com", "123456789", new DateTime(1995, 3, 15));
            Cliente cliente2 = new Cliente(2, "Ana", "García", "ana@email.com", "987654321", new DateTime(2008, 7, 20));
            cliente1.Tipo = TipoCliente.Premium;
            
            cliente1.MostrarInfo();
            Console.WriteLine();
            cliente2.MostrarInfo();
            Console.WriteLine();

            // Crear reservas
            Console.WriteLine("3. CREANDO RESERVAS:");
            Reserva reserva1 = new Reserva(1, cliente1, piscina1, DateTime.Now.AddDays(1), 10, 12, 5);
            Reserva reserva2 = new Reserva(2, cliente2, piscina2, DateTime.Now.AddDays(2), 14, 16, 3);
            
            reserva1.MostrarInfo();
            Console.WriteLine();
            reserva2.MostrarInfo();
            Console.WriteLine();

            // Confirmar reservas
            Console.WriteLine("4. CONFIRMANDO RESERVAS:");
            if (reserva1.Confirmar())
                Console.WriteLine("Reserva 1 confirmada exitosamente");
            else
                Console.WriteLine("No se pudo confirmar la reserva 1");

            if (reserva2.Confirmar())
                Console.WriteLine("Reserva 2 confirmada exitosamente");
            else
                Console.WriteLine("No se pudo confirmar la reserva 2");
            Console.WriteLine();

            // Crear mantenimientos
            Console.WriteLine("5. PROGRAMANDO MANTENIMIENTOS:");
            Mantenimiento mant1 = new Mantenimiento(1, piscina1, DateTime.Now.AddDays(7), 
                                                   TipoMantenimiento.Limpieza, 
                                                   "Limpieza general", "Carlos López", 3);
            
            Mantenimiento mant2 = new Mantenimiento(2, piscina2, DateTime.Now.AddDays(5), 
                                                   TipoMantenimiento.Revision, 
                                                   "Revisión de equipos", "María Rodríguez", 2);
            
            mant1.MostrarInfo();
            Console.WriteLine();
            mant2.MostrarInfo();
            Console.WriteLine();

            // Simular mantenimiento
            Console.WriteLine("6. EJECUTANDO MANTENIMIENTO:");
            mant1.Iniciar();
            mant1.Finalizar();
            Console.WriteLine();

            // Resumen final
            Console.WriteLine("7. RESUMEN:");
            Console.WriteLine($"Total piscinas: 2");
            Console.WriteLine($"Total clientes: 2");
            Console.WriteLine($"Total reservas: 2");
            Console.WriteLine($"Ingresos por reservas: ${reserva1.Precio + reserva2.Precio:F2}");
            Console.WriteLine($"Costo mantenimientos: ${mant1.Costo + mant2.Costo:F2}");

            Console.WriteLine();
            Console.WriteLine("Presiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
