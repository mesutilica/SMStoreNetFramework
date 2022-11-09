namespace SMStore.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SMStore.Data.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true; // otomatik migrationda data kayıplarına izin ver
        }

        protected override void Seed(DatabaseContext context)
        {
            //  Seed metodu veritabanı migration işlemi gerçekleştikten sonra çalışır ve veritabanına varsayılan kayıt eklememizi sağlar.

            if (!context.AppUsers.Any()) // eğer veritabanında hiç kullanıcı yoksa
            {
                context.AppUsers.Add(
                    new Entities.AppUser()
                    {
                       CreateDate = DateTime.Now,
                       Email = "admin@smstore.com",
                       IsActive = true,
                       IsAdmin = true,
                       Name = "Admin",
                       Surname = "User",
                       Password = "123",
                       Username = "Admin"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
