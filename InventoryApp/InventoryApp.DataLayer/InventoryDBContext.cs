using InventoryApp.Entities;
using System;
using System.Data.Entity;
using System.Security.Cryptography;

namespace InventoryApp.DataLayer
{
    public class InventoryDBContext : DbContext
    {
        public InventoryDBContext()
        {
            Database.SetInitializer(new DbInitializer());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Corporation> Corporations { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<ProductUnit> ProductUnits { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<InventoryInsDeatil> InventoryInsDeatils { get; set; }
        public DbSet<InventoryInsType> InventoryInsTypes { get; set; }
        public DbSet<InventoryInsHeader> InventoryInsHeaders { get; set; }
        public DbSet<InventoryOutsDeatil> InventoryOutsDeatils { get; set; }
        public DbSet<InventoryOutsType> InventoryOutsTypes { get; set; }
        public DbSet<InventoryOutsHeader> InventoryOutsHeaders { get; set; }
        public DbSet<ProductCategory> ProductCategorys { get; set; }
        public DbSet<ProductParameter> ProductParameters { get; set; }
        public DbSet<ProductParameterValue> ProductParsmeterValues { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(User.Map());
            modelBuilder.Configurations.Add(Role.Map());
            modelBuilder.Configurations.Add(Corporation.Map());
            modelBuilder.Configurations.Add(Product.Map());
            modelBuilder.Configurations.Add(Entities.ProductUnit.Map());
            modelBuilder.Configurations.Add(ProductCategory.Map());
            modelBuilder.Configurations.Add(InventoryInsType.Map());
            modelBuilder.Configurations.Add(InventoryInsHeader.Map());
            modelBuilder.Configurations.Add(InventoryInsDeatil.Map());
            modelBuilder.Configurations.Add(InventoryOutsType.Map());
            modelBuilder.Configurations.Add(InventoryOutsHeader.Map());
            modelBuilder.Configurations.Add(InventoryOutsDeatil.Map());
            modelBuilder.Configurations.Add(ProductParameterValue.Map());
            modelBuilder.Configurations.Add(ProductParameter.Map());
            base.OnModelCreating(modelBuilder);
        }
    }

    public class DbInitializer : CreateDatabaseIfNotExists<InventoryDBContext>
    {
        protected override void Seed(InventoryDBContext context)
        {
            var password = "admin";
            var username = "admin";
            var passwordsalt = Guid.NewGuid().ToString("N");
            var saltedPassword = password + passwordsalt;
            var saltedPasswordBytes = System.Text.Encoding.UTF8.GetBytes(saltedPassword);
            var hashedPassword = Convert.ToBase64String(SHA512.Create().ComputeHash(saltedPasswordBytes));
            var _userentity = new User
            {
                Username = username,
                Password = hashedPassword,
                PasswordSalt = passwordsalt,
                RegisterDate = DateTime.Now,
                Deleted = false
            };
            var contaxt = new InventoryDBContext();
            contaxt.Users.Add(_userentity);
            contaxt.SaveChanges();

            base.Seed(context);
        }
    }
   
}
