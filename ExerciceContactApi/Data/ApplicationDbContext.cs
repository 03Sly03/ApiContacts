using ExerciceContactApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciceContactApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            int lastIndex = 0;
            var contacts = new List<Contact>()
            {
                new Contact() { Id = ++lastIndex, Firstname = "Babouche", Lastname = "Mig", Birthdate = new DateTime(2002, 02, 15), Avatar = "https://sm.ign.com/ign_fr/cover/a/avatar-gen/avatar-generations_bssq.jpg", Gender = "M"},
                new Contact() { Id = ++lastIndex, Firstname = "King", Lastname = "Kong", Birthdate = new DateTime(2002, 02, 12), Avatar = "https://media.gqmagazine.fr/photos/63c9247a35fc113fac34f877/16:9/w_1280,c_limit/maxresdefault.jpg", Gender = "M"}
            };

            modelBuilder.Entity<Contact>().HasData(contacts);
        }
    }
}
