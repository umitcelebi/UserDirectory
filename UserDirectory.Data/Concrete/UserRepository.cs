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

        public override IQueryable<User> GetAll()
        {
            return context.Set<User>().Include(p => p.Phones);
        }

        public override User GetById(int id)
        {
            return context.Set<User>().Where(u => u.UserId == id).Include(p => p.Phones).SingleOrDefault();
        }

        public override void Edit(User entity)
        {
            var user = context.Set<User>().SingleOrDefault(u => u.UserId == entity.UserId);
            if (user != null)
            {
                user.Name = entity.Name;
                user.Surname = entity.Surname;
                user.Email = entity.Email;
                user.Birthday = entity.Birthday;
                user.Phones = entity.Phones;
                user.Image = entity.Image;
                user.Location = entity.Location;
            }
        }
    }
}
