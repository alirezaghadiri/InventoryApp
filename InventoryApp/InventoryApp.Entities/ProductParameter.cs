using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace InventoryApp.Entities
{
    public class ProductParameter
    {
        public int ProductParameterId { get; set; }
        public int ProductCategoryId { get; set; }
        public string Key { get; set; }
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

        public virtual  ProductCategory Category { get; set; }
        public ICollection<ProductParameterValue> ProductParameterValues { get; set; }
        public static EntityTypeConfiguration<ProductParameter> Map()
        {
            var map = new EntityTypeConfiguration<ProductParameter>();
            map.Property(P => P.Title).HasMaxLength(200).IsRequired();
            map.Property(P => P.Description).HasMaxLength(1000);
            map.Property(P => P.Key).HasMaxLength(100);

            map.HasRequired(P => P.Category).WithMany(PC => PC.ProductParameters).HasForeignKey(p => p.ProductCategoryId);
            map.HasOptional(C => C.DeletedUser).WithMany(U => U.DeletedProductParameter).HasForeignKey(I => I.DeletedByUserId);
            map.HasRequired(C => C.CreatedUser).WithMany(U => U.CreatedProductParameter).HasForeignKey(I => I.CreatedByUserId).WillCascadeOnDelete(false);
            map.HasOptional(C => C.ChangedUser).WithMany(U => U.ChangedProductParameter).HasForeignKey(I => I.ChangedByUserId);
            return map;
        }
    }
}
