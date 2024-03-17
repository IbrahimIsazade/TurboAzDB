namespace TurboAzDB.Models.Entities
{
    public class Brand
    {
        public int Id { get; private set; }
        public string Name { get; set; }

        public int CreatedBy { get; set; } = 1;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public int DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public Brand(string name)
        {
            this.Name = name;
        }
    }
}
