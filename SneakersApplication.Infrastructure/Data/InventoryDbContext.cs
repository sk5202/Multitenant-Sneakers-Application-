namespace SneakersApplication.Infrastructure.Data;

public class InventoryDbContext : DbContext
{
    private readonly Tenant _tenant;

    public InventoryDbContext(DbContextOptions options, ITenantResolver tenantResolver)
        : base(options)
    {
        _tenant = tenantResolver.GetCurrentTenant();

        if (_tenant.ConnectionString is { } connectionString)
            Database.SetConnectionString(connectionString);
    }

    public DbSet<Inventory> Inventory { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Inventory>().HasKey(e => e.Id);
        modelBuilder.Entity<Inventory>().Property(e => e.Name).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<Inventory>().Property(e => e.TenantId).IsRequired();

        modelBuilder.Entity<Inventory>().HasQueryFilter(e => e.TenantId == _tenant.Name);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach(var entry in ChangeTracker.Entries<EntityBase>().Where(e => e.State == EntityState.Added))
        {
            entry.Entity.TenantId = _tenant.Name;
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}