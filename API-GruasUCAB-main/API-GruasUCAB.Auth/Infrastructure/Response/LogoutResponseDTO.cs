using System.ComponentModel.DataAnnotations;

public class LogoutResponseDTO
{
     [Required]
     public string Message { get; set; } = string.Empty;
}