using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace InventoryApp.Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<User> Users { get; set; }

        public static EntityTypeConfiguration<Role> Map()
        {
            var map = new EntityTypeConfiguration<Role>();
            map.Property(R => R.Title).IsRequired().HasMaxLength(100);
            map.Property(R => R.Description).IsRequired().HasMaxLength(1000);
            map.Property(R => R.Title).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Ix_Title_Unique") { IsUnique = true }));
            return map;
        }

    }
}
