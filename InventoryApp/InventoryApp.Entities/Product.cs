using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace InventoryApp.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public int ProductCategoryId { get; set; }
        public int ProductUnitId { get; set; }
        public int Code { get; set; }
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

        public virtual ProductCategory Category { get; set; }
        public virtual ProductUnit Unit { get; set; }
        public ICollection<ProductParameterValue> ProductParameterValues { get; set; }
        public ICollection<InventoryInsDeatil> InventoryInsDeatils { get; set; }
        public ICollection<InventoryOutsDeatil> InventoryOutsDeatils { get; set; }
        public static EntityTypeConfiguration<Product> Map()
        {
            var map = new EntityTypeConfiguration<Product>();
            map.Property(P => P.Title).HasMaxLength(200).IsRequired();
            map.Property(P => P.Description).HasMaxLength(1000);
            map.Property(P => P.Code)
                .HasColumnAnnotation("Index",
                new IndexAnnotation(new IndexAttribute("Ix_Unique") { IsUnique = true }));
            map.HasRequired(P => P.Category).WithMany(Pro => Pro.Products).HasForeignKey(p => p.ProductCategoryId);
            map.HasRequired(P => P.Unit).WithMany(Pro => Pro.Products).HasForeignKey(p => p.ProductUnitId);
            map.HasOptional(C => C.DeletedUser).WithMany(U => U.DeletedProduct).HasForeignKey(P => P.DeletedByUserId);
            map.HasRequired(C => C.CreatedUser).WithMany(U => U.CreatedProduct).HasForeignKey(P => P.CreatedByUserId).WillCascadeOnDelete(false);
            map.HasOptional(C => C.ChangedUser).WithMany(U => U.ChangedProduct).HasForeignKey(P => P.ChangedByUserId);
            return map;
        }
    }
}
