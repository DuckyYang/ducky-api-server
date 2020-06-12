using ducky_api_server.Service.Users;
using ducky_api_server.Service.Roles;

using Microsoft.Extensions.DependencyInjection;

namespace ducky_api_server.Framework
{
    public static class ServiceRegisteTask
    {
        public static void RegisteAll(this IServiceCollection services)
        {
            services.AddSingleton<IUsersService,UsersService>();
            services.AddSingleton<IRolesService,RolesService>();
        }
    }
}