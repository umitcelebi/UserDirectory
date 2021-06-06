using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserDirectory.Data.Abstract;
using UserDirectory.Entity;

namespace UserDirectory.Data.Concrete
{
    public class UserRepository:Repository<User>,IUserRepository
    {
        private DbContext context;
        public UserRepository(DbContext _dbContext) : base(_dbContext)
        {
            context = _dbContext;
        }

        public IQueryable<User> GetAllUser()
        {
            return context.Set<User>().Include(p => p.Phones);
        }
    }
}
