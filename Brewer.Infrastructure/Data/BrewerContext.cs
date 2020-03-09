using Brewer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Brewer.Infrastructure.Data
{
    public class BrewerContext : DbContext
    {
        public BrewerContext(DbContextOptions<BrewerContext> options)
            : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Beer> Beers { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<Phone> Phones { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<SaleItem> SaleItems { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserGroup> UserGroups { get; set; }
    }
}