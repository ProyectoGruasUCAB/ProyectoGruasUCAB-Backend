using System;
using System.Collections.Generic;

namespace API_GruasUCAB.Policy.Domain.Entities
{
    public class Client
    {
        public Guid Id_cliente { get; set; }
        public string Nombre_completo_cliente { get; set; } = string.Empty;
        public int Cedula_cliente { get; set; }
        public int Tlf_cliente { get; set; }
        public DateTime Fecha_nacimiento_cliente { get; set; }

    }
}