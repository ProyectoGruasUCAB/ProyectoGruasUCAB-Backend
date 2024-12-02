namespace backend.Domain.Entities {
    public class Usuario_Rol
    {
        public Guid Id_usuario { get; set; }
        public Usuario Usuario { get; set; }
        public Guid Id_rol { get; set; }
        public Rol Rol { get; set; }
    }


}