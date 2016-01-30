using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository.IRepo;
using Repository.Models;

namespace Repository.Repo
{
    public class UserRepo : IUserRepo
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return db.User.AsNoTracking();
        }

        public ApplicationUser GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> GetAllUsersWithRole(string role)
        {
            throw new NotImplementedException();
        }

        public void AddUser(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
}