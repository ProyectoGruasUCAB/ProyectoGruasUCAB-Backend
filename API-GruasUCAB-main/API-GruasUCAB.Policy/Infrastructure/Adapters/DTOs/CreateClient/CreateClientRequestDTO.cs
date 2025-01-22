using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_GruasUCAB.Policy.Infrastructure.Adapters.DTOs.CreateClient
{
    public class CreateClientRequestDTO
    {
        [JsonPropertyOrder(1)]
        public Guid Id_cliente { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Name is required.")]
        [JsonPropertyOrder(2)]
        public string Nombre_completo_cliente { get; set; } = string.Empty;

        [Required(ErrorMessage = "Cedula is required.")]
        [JsonPropertyOrder(3)]
        public int Cedula_cliente { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [JsonPropertyOrder(4)]
        public int Tlf_cliente { get; set; }

        [Required(ErrorMessage = "Birth date is required.")]
        [JsonPropertyOrder(5)]
        public DateTime Fecha_nacimiento_cliente { get; set; }
    }
}