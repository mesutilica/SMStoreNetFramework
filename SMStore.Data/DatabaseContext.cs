using SMStore.Entities;
using System.Data.Entity;

namespace SMStore.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Slider> Sliders { get; set; }
    }
}
/*
 * .Netframework de migration oluşturmak için Package manage console ekranından Smstore.data projesini seçerek enable-migrations komutunu çalıştırıyoruz.
 * Sonraki geliştirmelerde add-migration migrationismi komutunu yazıp enter diyerek yeni eklemeleri migration olarak kaydedebiliriz.
 * Migration işleminden sonra update-database komutunu girip enter diyerek işlemi tamamlıyoruz.
 */