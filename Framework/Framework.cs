using ducky_api_server.Service.Users;
using ducky_api_server.Service.Roles;
using ducky_api_server.Service.Menus;
using ducky_api_server.Service.RolesAuth;
using Microsoft.Extensions.DependencyInjection;

namespace ducky_api_server.Framework
{
    public static class ServiceRegisteTask
    {
        public static void RegisteAll(this IServiceCollection services)
        {
            services.AddSingleton<IUsersService,UsersService>();
            services.AddSingleton<IRolesService,RolesService>();
            services.AddSingleton<IMenusService,MenusService>();
            services.AddSingleton<IRolesAuthService,RolesAuthService>();
        }
    }
}