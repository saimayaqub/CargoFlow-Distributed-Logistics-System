using DL.Infrastructure;
using DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DL.Repositories
{
    public class RevLogUserRepository : RepositoryBase<RevLogUser>, IRevLogUserRepository
    {
        public RevLogUserRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
        public void AssignRole(string userName, List<string> roleNames)
        {
            //var user = this.GetById(userName);
            //user.Roles.Clear();
            //foreach (string roleName in roleNames)
            //{
            //    var role = this.DataContext.Roles.Find(roleName);
            //    user.Roles.Add(role);
            //}

            //this.DataContext.Users.Attach(user);
            //this.DataContext.Entry(user).State = EntityState.Modified;
        }
    }

    public interface IRevLogUserRepository : IRepository<RevLogUser>
    {
        void AssignRole(string userName, List<string> roleName);
    }

}
