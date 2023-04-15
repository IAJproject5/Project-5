using Microsoft.AspNetCore.Identity;
using Project_5.Areas.Identity.Data;
using Project_5.Controllers;
using Project_5.Data;

namespace Project_5.Helpers
{
    public class UserManagementHelper
    {
        private static Project_5Context context;

        public UserManagementHelper(Project_5Context ctx)
        {
            context = ctx;
        }

        public static List<Project_5User> getUserList()
        {
            var users = context.Users.ToList<Project_5User>();
            return users;
        }
        public static Project_5User getUserInfo(string userId)
        {
            var user = context.Users.Where(b => b.Id.Equals(userId)).FirstOrDefault();
            return user;
        }
        public static List<IdentityRole> getUserRoleList(string userId)
        {
            var roles = context.UserRoles.Where(b => b.UserId.Equals(userId)).ToList();
            List<IdentityRole> roleNames = new List<IdentityRole>();
            foreach (IdentityUserRole<string> roleToUser in roles)
            {
                roleNames.Add(context.Roles.Where(b => b.Id.Equals(roleToUser.RoleId)).FirstOrDefault());
            }
            return roleNames;
        }
        public static void createNewUser()
        {

        }
    }
}
