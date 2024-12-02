namespace backend.Domain.Entities
{
public class Usuario : Base
{
    public Guid Id_usuario { get; set; }
    public string Correo_usuario { get; set; }
    public int Contrasena_usuario { get; set; }

    public Guid? Id_trabajador { get; set; }
    public Trabajador Trabajador { get; set; }

    public Guid? Id_conductor { get; set; }
    public Conductor Conductor { get; set; }

    public Guid? Id_proveedor { get; set; }
    public Proveedor Proveedor { get; set; }

    public ICollection<Usuario_Rol> Usuario_Roles { get; set; }
    
}

/*

public Usuario(Guid id_usuario, string correo_usuario, int contrasena_usuario){
    Id_usuario = id_usuario;
    Correo_usuario = correo_usuario;
    Contrasena_usuario = contrasena_usuario;
}

public Usuario () {}

//metodos

*/
}