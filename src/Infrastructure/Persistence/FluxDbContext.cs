using Flux.Domain.Entities.Customers;
using Flux.Domain.Entities.Merchants;
using Flux.Domain.Entities.Payments;
using Flux.Domain.Entities.Transactions;
using Flux.Domain.Entities.WebhookEvent;
using Microsoft.EntityFrameworkCore;

namespace Flux.Infrastructure.Persistence
{
    public partial class FluxDbContext : DbContext
    {
        public FluxDbContext(DbContextOptions<FluxDbContext> options)
            : base(options) { }

        // Dbsets represent tables in the database
        // Each Dbset<> = 1 table
        public DbSet<Merchant> Merchants => Set<Merchant>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Payment> Payments => Set<Payment>();
        public DbSet<Transaction> Transactions => Set<Transaction>();
        public DbSet<WebhookEvent> WebhookEvents => Set<WebhookEvent>();

        //This method configures how entities are mapped to database tables
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply all configurations fromt the configurations folder
            // This looks for all classes that implement IEntityTypeConfiguration<T>
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FluxDbContext).Assembly);
        }

        // This method is called to save changes to the database asynchronously
        public override async Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default
        )
        {
            // Here you can add logic before saving changes, like setting audit fields
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
