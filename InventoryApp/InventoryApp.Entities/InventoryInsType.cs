using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace InventoryApp.Entities
{
    public class InventoryInsType
    {
        public int InventoryInsTypeId { get; set; }
        public string Title { get; set; }
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

        public virtual ICollection<InventoryInsHeader> InventoryInsHeaders { get; set; }


        public static EntityTypeConfiguration<InventoryInsType> Map()
        {
            var map = new EntityTypeConfiguration<InventoryInsType>();
            map.Property(I => I.Title).HasMaxLength(200).IsRequired();
            map.Property(I => I.Description).HasMaxLength(1000);
            
           
            map.HasOptional(I => I.DeletedUser).WithMany(U => U.DeletedInventoryInsType).HasForeignKey(I => I.DeletedByUserId);
            map.HasRequired(I => I.CreatedUser).WithMany(U => U.CreatedInventoryInsType).HasForeignKey(I => I.CreatedByUserId).WillCascadeOnDelete(false);
            map.HasOptional(I => I.ChangedUser).WithMany(U => U.ChangedInventoryInsType).HasForeignKey(I => I.ChangedByUserId);
            return map;
        }
    }
}
