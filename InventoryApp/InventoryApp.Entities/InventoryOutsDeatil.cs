using System.Data.Entity.ModelConfiguration;

namespace InventoryApp.Entities
{
    public class InventoryOutsDeatil
    {
        public int InventoryOutsDeatilId { get; set; }
        public int ProductId { get; set; }

        public decimal Amount { get; set; }

        public virtual Product prodocut { get; set; }

        public static EntityTypeConfiguration<InventoryOutsDeatil> Map()
        {
            var map = new EntityTypeConfiguration<InventoryOutsDeatil>();
            map.HasRequired(I => I.prodocut).WithMany(C => C.InventoryOutsDeatils).HasForeignKey(p => p.ProductId);
            return map;
        }
    }
}
