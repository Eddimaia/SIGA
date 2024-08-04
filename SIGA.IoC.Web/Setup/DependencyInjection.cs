using Blazored.LocalStorage;
using Microsoft.Extensions.DependencyInjection;
using SIGA.Application.Handles.Interfaces;
using SIGA.IoC.Web.Handles;

namespace SIGA.IoC.Web.Setup;
public static class DependencyInjection
{
    public static IServiceCollection AddIoCHandles(this IServiceCollection services)
    {
        services.AddTransient<IAccountHandler, AccountHandler>();
        services.AddTransient<ILogoutHandler, AccountHandler>();
        services.AddTransient<IProjectHandler, ProjectHandler>();
        services.AddBlazoredLocalStorage();

        return services;
    }

}
