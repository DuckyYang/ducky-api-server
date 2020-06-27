using ducky_api_server.Service.Menus;
using ducky_api_server.Service.Roles;
using ducky_api_server.Service.RoleAuths;
using ducky_api_server.Service.Servers;
using ducky_api_server.Service.Users;
using ducky_api_server.Service.Request;
using ducky_api_server.Service.Collections;
using Microsoft.Extensions.DependencyInjection;

namespace ducky_api_server.Service
{
    public class ServiceRegisteTask
    {
        public static void Resite(IServiceCollection services)
        {
            services.AddSingleton<IUsersService, UsersService>();
            services.AddSingleton<IRolesService, RolesService>();
            services.AddSingleton<IMenusService, MenusService>();
            services.AddSingleton<IRoleAuthsService, RoleAuthsService>();
            services.AddSingleton<IServersService, ServersService>();
            services.AddSingleton<IRequestService, RequestService>();
            services.AddSingleton<ICollectionsService,CollectionsService>();
        }
    }
}