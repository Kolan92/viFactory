using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;

namespace Repository.IRepo
{
    public interface IUserRepo
    {
        IEnumerable<ApplicationUser> GetAllUsers();
        ApplicationUser GetUserById(int id);
        IEnumerable<ApplicationUser> GetAllUsersWithRole(string role);
        void AddUser(ApplicationUser user);
        void RemoveUser(int id);
        void UpdateUser(ApplicationUser user);
    }
}
