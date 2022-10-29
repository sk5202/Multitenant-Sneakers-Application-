namespace SneakersApplication.Core.Abstractions;

public interface ITenantRegistry
{
    Tenant[] GetTenants();

    User[] GetUsers();
}