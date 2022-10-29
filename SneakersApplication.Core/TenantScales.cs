namespace SneakersApplication.Core;

public class TenantScales
{
    public string? DefaultConnection { get; set; }

    public Tenant[] Tenants { get; set; } = Array.Empty<Tenant>();

    public User[] Users { get; set; } = Array.Empty<User>();
}