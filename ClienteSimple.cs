using System;

namespace SistemaPiscinas
{
    public class Cliente
    {
        // Atributos básicos
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public TipoCliente Tipo { get; set; }

        // Constructor
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

        // Método para calcular edad
        public int CalcularEdad()
        {
            int edad = DateTime.Now.Year - FechaNacimiento.Year;
            if (DateTime.Now.Month < FechaNacimiento.Month)
                edad--;
            return edad;
        }

        // Método para obtener nombre completo
        public string NombreCompleto()
        {
            return Nombre + " " + Apellido;
        }

        // Método para verificar si es menor de edad
        public bool EsMenor()
        {
            return CalcularEdad() < 18;
        }

        // Método para mostrar información
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
}
