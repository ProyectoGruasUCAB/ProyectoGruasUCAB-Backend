namespace backend.Domain.Entities {
    public class Rol : Base
    {
        public Guid Id_rol { get; set; }
        public string Nombre_rol { get; set; }
        public string Descrip_rol { get; set; }

        public ICollection<Usuario_Rol> Usuario_Roles { get; set; }
    }


}