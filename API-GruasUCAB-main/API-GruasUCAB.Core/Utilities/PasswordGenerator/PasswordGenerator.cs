namespace API_GruasUCAB.Core.Infrastructure.PasswordGenerator
{
     public static class PasswordGenerator
     {
          public static string GeneratePassword(int length = 6)
          {
               var random = new Random();
               return random.Next((int)Math.Pow(10, length - 1), (int)Math.Pow(10, length) - 1).ToString();
          }
     }
}