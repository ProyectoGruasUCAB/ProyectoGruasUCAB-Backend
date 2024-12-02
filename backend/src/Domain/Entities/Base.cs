namespace backend.Domain.Entities
{
    public class Base
    {
        public Guid Id_base { get; set; }

        public DateTime CreatedAt_base { get; set; }

        public string? CreatedBy_base { get; set; }

        public DateTime? UpdatedAt_base { get; set; }

        public string? UpdatedBy_base { get; set; }
    }
}