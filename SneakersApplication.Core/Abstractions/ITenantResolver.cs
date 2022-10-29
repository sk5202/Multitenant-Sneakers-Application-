namespace SneakersApplication.Core.Abstractions;

public interface ITenantResolver
{
    Tenant GetCurrentTenant();
}