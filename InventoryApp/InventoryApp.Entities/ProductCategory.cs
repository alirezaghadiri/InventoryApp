using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace InventoryApp.Entities
{
    public class ProductCategory
    {
        public int ProductCategoryId { get; set; }
        public int SubProductCategoryID { get; set; }
        public int InventoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Capacity { get; set; }


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

        public virtual Inventory Inventories { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<ProductParameter> ProductParameters { get; set; }

        public static EntityTypeConfiguration<ProductCategory> Map()
        {
            var map = new EntityTypeConfiguration<ProductCategory>();
            map.Property(P => P.Title).HasMaxLength(100).IsRequired();
            map.Property(P => P.Description).HasMaxLength(1000);
            map.HasRequired(P => P.Inventories).WithMany(C => C.ProductCategories).HasForeignKey(p=>p.InventoryId).WillCascadeOnDelete(false);
            map.HasOptional(C => C.DeletedUser).WithMany(U => U.DeletedProductCategory).HasForeignKey(I => I.DeletedByUserId);
            map.HasRequired(C => C.CreatedUser).WithMany(U => U.CreatedProductCategory).HasForeignKey(I => I.CreatedByUserId).WillCascadeOnDelete(false);
            map.HasOptional(C => C.ChangedUser).WithMany(U => U.ChangedProductCategory).HasForeignKey(I => I.ChangedByUserId);
            return map;
        }
    }
}
