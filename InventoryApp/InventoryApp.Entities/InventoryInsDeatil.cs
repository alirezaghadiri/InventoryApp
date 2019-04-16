using System.Data.Entity.ModelConfiguration;

namespace InventoryApp.Entities
{
    public class InventoryInsDeatil
    {
        public int InventoryInsDeatilId { get; set; }
        public int ProductId { get; set; }
        public decimal Amount { get; set; }

        public virtual Product prodocut { get; set; }

        public static EntityTypeConfiguration<InventoryInsDeatil> Map()
        {
            var map = new EntityTypeConfiguration<InventoryInsDeatil>();
            map.HasRequired(I => I.prodocut).WithMany(C => C.InventoryInsDeatils).HasForeignKey(p => p.ProductId);
            return map;
        }
    }
}
