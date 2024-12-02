namespace backend.Domain.Entities {
    public class Estado : Base
    {
        public Guid Id_estado { get; set; }
        public string Nombre_estado { get; set; }
        public string Descrip_estado { get; set; }
        public ICollection<Estado_Orden> Estado_Ordenes { get; set; }

    }


}