using System;
using System.Data.Entity.ModelConfiguration;

namespace InventoryApp.Entities
{
    public class InventoryOutsHeader
    {
        public int InventoryOutsHeaderId { get; set; }
        public int InventoryId { get; set; }
        public int TypeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
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
        public virtual InventoryOutsType type { get; set; }
        

        public static EntityTypeConfiguration<InventoryOutsHeader> Map()
        {
            var map = new EntityTypeConfiguration<InventoryOutsHeader>();

            map.HasRequired(I => I.Inv).WithMany(C => C.InventoryOutsHeaders).HasForeignKey(p => p.InventoryId);
            map.HasRequired(I => I.type).WithMany(C => C.InventoryOutsHeaders).HasForeignKey(p => p.TypeId);
            map.HasOptional(C => C.DeletedUser).WithMany(U => U.DeletedInventoryOutsHeader).HasForeignKey(I => I.AcceptedByUserId);
            map.HasOptional(C => C.DeletedUser).WithMany(U => U.DeletedInventoryOutsHeader).HasForeignKey(I => I.DeletedByUserId);
            map.HasRequired(C => C.CreatedUser).WithMany(U => U.CreatedInventoryOutsHeader).HasForeignKey(I => I.CreatedByUserId).WillCascadeOnDelete(false);
            map.HasOptional(C => C.ChangedUser).WithMany(U => U.ChangedInventoryOutsHeader).HasForeignKey(I => I.ChangedByUserId);
            return map;
        }
    }
}
