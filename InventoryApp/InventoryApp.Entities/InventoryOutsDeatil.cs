using System.Data.Entity.ModelConfiguration;

namespace InventoryApp.Entities
{
    public class InventoryOutsDeatil
    {
        public int InventoryOutsHeaderId { get; set; }
        public int ProductId { get; set; }

        public decimal Amount { get; set; }

        public virtual Product prodocut { get; set; }
        public virtual InventoryOutsHeader inventoryOutsHeader { get; set; }

        public static EntityTypeConfiguration<InventoryOutsDeatil> Map()
        {
            var map = new EntityTypeConfiguration<InventoryOutsDeatil>();
            map.HasKey(P => new { P.ProductId, P.InventoryOutsHeaderId });
            map.HasRequired(I => I.inventoryOutsHeader).WithMany(C => C.InventoryOutsDeatiles).HasForeignKey(p => p.InventoryOutsHeaderId);
            map.HasRequired(I => I.prodocut).WithMany(C => C.InventoryOutsDeatils).HasForeignKey(p => p.ProductId);
            return map;
        }
    }
}
