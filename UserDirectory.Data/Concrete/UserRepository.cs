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
        public UserRepository(DbContext _dbContext) : base(_dbContext)
        {
        }
    }
}
