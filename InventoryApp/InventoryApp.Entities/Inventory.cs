using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace InventoryApp.Entities
{
    public class Inventory
    {
        public int InventoryId {get;set;}
        public int CorporationId { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Description { get; set; }

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

        public virtual Corporation corporation { get; set; }
        public virtual ICollection<InventoryInsHeader> InventoryInsHeaders { get; set; }
        public virtual ICollection<InventoryOutsHeader> InventoryOutsHeaders { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }

        public static EntityTypeConfiguration<Inventory> Map()
        {
            var map = new EntityTypeConfiguration<Inventory>();
            map.Property(I=>I.Title).HasMaxLength(100).IsRequired();
            map.Property(I=>I.Description).HasMaxLength(1000);
            map.Property(I=>I.Address).HasMaxLength(1000);
            map.HasRequired(I => I.corporation).WithMany(C => C.Inventories).HasForeignKey(c => c.CorporationId);    
            map.HasOptional(C => C.DeletedUser).WithMany(U => U.DeletedInventory).HasForeignKey(I => I.DeletedByUserId);
            map.HasRequired(C => C.CreatedUser).WithMany(U => U.CreatedInventory).HasForeignKey(I => I.CreatedByUserId).WillCascadeOnDelete(false);
            map.HasOptional(C => C.ChangedUser).WithMany(U => U.ChangedInventory).HasForeignKey(I => I.ChangedByUserId);
            return map;
        }
    }
}
