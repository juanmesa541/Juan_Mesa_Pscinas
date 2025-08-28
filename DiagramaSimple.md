
    ┌─────────────────────────┐
    │        PISCINA          │
    ├─────────────────────────┤
    │ + Id: int               │
    │ + Nombre: string        │
    │ + CapacidadMaxima: int  │
    │ + Largo: double         │
    │ + Ancho: double         │
    │ + Profundidad: double   │
    │ + TipoAgua: TipoAgua    │
    │ + Estado: EstadoPiscina │
    ├─────────────────────────┤
    │ + CalcularVolumen()     │
    │ + PuedeAceptar()        │
    │ + MostrarInfo()         │
    └─────────────────────────┘
              │
              │ 1
              │
              ▼ *
    ┌─────────────────────────┐              ┌─────────────────────────┐
    │        RESERVA          │              │        CLIENTE          │
    ├─────────────────────────┤              ├─────────────────────────┤
    │ + Id: int               │              │ + Id: int               │
    │ + Cliente: Cliente      │◄─────────────┤ + Nombre: string        │
    │ + Piscina: Piscina      │      1    *  │ + Apellido: string      │
    │ + Fecha: DateTime       │              │ + Email: string         │
    │ + HoraInicio: int       │              │ + Telefono: string      │
    │ + HoraFin: int          │              │ + FechaNacimiento: DateTime │
    │ + NumeroPersonas: int   │              │ + Tipo: TipoCliente     │
    │ + Precio: double        │              ├─────────────────────────┤
    │ + Estado: EstadoReserva │              │ + CalcularEdad()        │
    ├─────────────────────────┤              │ + NombreCompleto()      │
    │ + CalcularPrecio()      │              │ + EsMenor()             │
    │ + Confirmar()           │              │ + MostrarInfo()         │
    │ + Cancelar()            │              └─────────────────────────┘
    │ + MostrarInfo()         │
    └─────────────────────────┘
              ▲
              │ 1
              │
              ▼ *
    ┌─────────────────────────┐
    │     MANTENIMIENTO       │
    ├─────────────────────────┤
    │ + Id: int               │
    │ + Piscina: Piscina      │
    │ + Fecha: DateTime       │
    │ + Tipo: TipoMantenimiento │
    │ + Descripcion: string   │
    │ + Tecnico: string       │
    │ + Costo: double         │
    │ + DuracionHoras: int    │
    │ + Completado: bool      │
    ├─────────────────────────┤
    │ + CalcularCosto()       │
    │ + Iniciar()             │
    │ + Finalizar()           │
    │ + MostrarInfo()         │
    └─────────────────────────┘

Enumeraciones

TipoAgua
- Dulce
- Salada  
- Clorada

EstadoPiscina
- Disponible
- Ocupada
- Mantenimiento

EstadoReserva
- Pendiente
- Confirmada
- Cancelada

TipoCliente
- Regular
- Premium

TipoMantenimiento
- Limpieza
- Reparacion
- Revision

Relaciones

1. **Piscina → Reserva** (1:*)
   - Una piscina puede tener múltiples reservas

2. **Cliente → Reserva** (1:*)
   - Un cliente puede hacer múltiples reservas

3. **Piscina → Mantenimiento** (1:*)
   - Una piscina puede tener múltiples mantenimientos
