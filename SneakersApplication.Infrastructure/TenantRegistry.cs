namespace SneakersApplication.Infrastructure;

public class TenantRegistry : ITenantRegistry
{
    private readonly TenantScales _tenantScales;

    public TenantRegistry(IConfiguration configuration)
    {
        _tenantScales = configuration.GetSection("TenantScales").Get<TenantScales>();

        foreach(var tenant in _tenantScales.Tenants.Where(e => string.IsNullOrEmpty(e.ConnectionString)))
        {
            tenant.ConnectionString = _tenantScales.DefaultConnection;
        }
    }

    public Tenant[] GetTenants() => _tenantScales.Tenants;

    public User[] GetUsers() => _tenantScales.Users;
}