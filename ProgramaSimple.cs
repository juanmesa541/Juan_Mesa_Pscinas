using System;

namespace SistemaPiscinas
{
    class ProgramaSimple
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
