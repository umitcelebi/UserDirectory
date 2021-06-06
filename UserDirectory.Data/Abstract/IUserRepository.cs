using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDirectory.Entity;

namespace UserDirectory.Data.Abstract
{
    public interface IUserRepository:IRepository<User>
    {
        IQueryable<User> GetAllUser();
    }
}
