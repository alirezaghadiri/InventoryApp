using System;
using System.Data.Entity.ModelConfiguration;

namespace InventoryApp.Entities
{
    public class InventoryInsHeader
    {
        public int InventoryInsHeaderId { get; set; }
        public int InventoryId { get; set; }
        public int TypeId { get; set; }
        public DateTime Date { get; set; }

        //Accepet
        public virtual User AcceptedUser { get; set; }
        public bool Accepted { get; set; }
        public DateTime? AcceptedDate { get; set; }
        public int? AcceptedByUserId { get; set; }

        //Delete
        public virtual User DeletedUser { get; set; }
        public bool Deleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedByUserId { get; set; }

        //Created
        public virtual User CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedByUserId { get; set; }

        //Changed
        public virtual User ChangedUser { get; set; }
        public DateTime? ChangedDate { get; set; }
        public int? ChangedByUserId { get; set; }

        public virtual Inventory Inv { get; set; }
        public virtual InventoryInsType type { get; set; }
       

        public static EntityTypeConfiguration<InventoryInsHeader> Map()
        {
            var map = new EntityTypeConfiguration<InventoryInsHeader>();

            map.HasRequired(I => I.Inv).WithMany(C => C.InventoryInsHeaders).HasForeignKey(p => p.InventoryId);
            map.HasRequired(I => I.type).WithMany(C => C.InventoryInsHeaders).HasForeignKey(p => p.TypeId);
            map.HasOptional(C => C.DeletedUser).WithMany(U => U.DeletedInventoryInsHeader).HasForeignKey(I => I.AcceptedByUserId);
            map.HasOptional(C => C.DeletedUser).WithMany(U => U.DeletedInventoryInsHeader).HasForeignKey(I => I.DeletedByUserId);
            map.HasRequired(C => C.CreatedUser).WithMany(U => U.CreatedInventoryInsHeader).HasForeignKey(I => I.CreatedByUserId).WillCascadeOnDelete(false);
            map.HasOptional(C => C.ChangedUser).WithMany(U => U.ChangedInventoryInsHeader).HasForeignKey(I => I.ChangedByUserId);
            return map;
        }
    }
}
