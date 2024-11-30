using System.ComponentModel.DataAnnotations;

public class LogoutRequestDTO
{
     [Required(ErrorMessage = "RefreshToken is required.")]
     public string RefreshToken { get; set; } = string.Empty;
}