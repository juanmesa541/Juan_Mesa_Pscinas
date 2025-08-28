using System;

namespace SistemaPiscinas
{
    // Tipos de agua para las piscinas
    public enum TipoAgua
    {
        Dulce,
        Salada,
        Clorada
    }

    // Estados de la piscina
    public enum EstadoPiscina
    {
        Disponible,
        Ocupada,
        Mantenimiento
    }

    // Estados de las reservas
    public enum EstadoReserva
    {
        Pendiente,
        Confirmada,
        Cancelada
    }

    // Tipos de clientes
    public enum TipoCliente
    {
        Regular,
        Premium
    }

    // Tipos de mantenimiento
    public enum TipoMantenimiento
    {
        Limpieza,
        Reparacion,
        Revision
    }
}
