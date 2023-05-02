using Microsoft.AspNetCore.Identity;
using Project_5.Areas.Identity.Data;
using Project_5.Controllers;
using Project_5.Data;
using Project_5.Models;

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
        public static List<IdentityRole> getRoles()
        {
            List<IdentityRole> roleNames = context.Roles.ToList<IdentityRole>();
            return roleNames;
        }
        public static void updateUser(Project_5User user)
        {
            var currentUser = context.Users.Where(u => u.Id.Equals(user.Id)).FirstOrDefault();
            if (currentUser == null) return;
            currentUser.UserName = user.UserName;
            currentUser.NormalizedUserName = user.UserName.ToUpper();
            currentUser.Email = user.Email;
            currentUser.NormalizedEmail = user.Email.ToUpper();
            context.Users.Update(currentUser);
            context.SaveChanges();
            return;
        }
        public static void deleteUser(string userId)
        {
            var currentUser = context.Users.Where(u => u.Id.Equals(userId)).FirstOrDefault();
            //if (currentUser == null) return;
            context.Users.Remove(currentUser);
            context.SaveChanges();
        }
        public static void setUserRoles(string userId, List<string> roleIds)
        {
            var currentUserRoles = context.UserRoles.Where(u => u.UserId.Equals(userId)).ToList();
            context.UserRoles.RemoveRange(currentUserRoles);
            context.SaveChanges();
            var newRoles = context.Roles.Where(u => roleIds.Contains(u.Id)).ToList();
            foreach (var role in newRoles)
            {
                var newUserRole = new IdentityUserRole<string> { RoleId = role.Id, UserId = userId };
                context.UserRoles.Add(newUserRole);
            }
            context.SaveChanges();
        }
    }
}
