using System.Data.Entity.ModelConfiguration;

namespace InventoryApp.Entities
{
    public class InventoryInsDeatil
    {
        public int InventoryInsHeaderId { get; set; }
        public int ProductId { get; set; }
        public decimal Amount { get; set; }

        public virtual Product prodocut { get; set; }
        public virtual InventoryInsHeader inventoryInsHeader { get; set; }

        public static EntityTypeConfiguration<InventoryInsDeatil> Map()
        {
            var map = new EntityTypeConfiguration<InventoryInsDeatil>();
            map.HasKey(P => new { P.ProductId, P.InventoryInsHeaderId });
            map.HasRequired(I => I.prodocut).WithMany(C => C.InventoryInsDeatils).HasForeignKey(p => p.ProductId);
            map.HasRequired(I => I.inventoryInsHeader).WithMany(C => C.InventoryInsDeatiles).HasForeignKey(p => p.InventoryInsHeaderId);
            return map;
        }
    }
}
