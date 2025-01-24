namespace API_GruasUCAB.Auth.Infrastructure.DTOs.DeleteUser
{
     public class DeleteUserRequestDTO : BaseRequestDTO
     {
          [Required(ErrorMessage = "Email is required.")]
          [EmailAddress(ErrorMessage = "Invalid email format.")]
          [JsonPropertyOrder(2)]
          public string EmailToDelete { get; set; } = string.Empty;
     }
}