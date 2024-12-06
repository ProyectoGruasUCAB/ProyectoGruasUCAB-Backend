using API_GruasUCAB.Core.Infrastructure.ResponseDTO;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_GruasUCAB.Auth.Infrastructure.DTOs.ChangePassword
{
    public class ChangePasswordResponseDTO : BaseResponseDTO
    {
        [Required]
        [JsonPropertyOrder(2)]
        public bool TemporaryPassword { get; set; }
    }
}