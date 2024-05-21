using Microsoft.AspNetCore.Identity;
using SububanMedicalGroupSMGWebApp.Models.DomainModels;

namespace SububanMedicalGroupSMGWebApp.Models.DataLayer.Configuration
{
    public class ConfigureIdentity
    {
        public static async Task CreateAdminUserAsync(IServiceProvider provider)
        {
            var role = provider.GetRequiredService<RoleManager<IdentityRole>>();
            var User = provider.GetRequiredService<UserManager<User>>();
            string username = "admin";
            string password = "Sesame";
            string rolename = "Admin";

            if (await role.FindByNameAsync(rolename) == null)
            {
                await role.CreateAsync(new IdentityRole(rolename));
            }
            if (await User.FindByNameAsync(username) == null)
            {
                User USER = new User { UserName = username };
                var res = await User.CreateAsync(USER, password);
                if (res.Succeeded)
                {
                    await User.AddToRoleAsync(USER, rolename);
                }
            }
        }

    }
}
