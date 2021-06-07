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
    public class UserRepository : Repository<User>, IUserRepository
    {
        private DbContext context;
        public UserRepository(DbContext _dbContext) : base(_dbContext)
        {
            context = _dbContext;
        }

        public override IQueryable<User> GetAll()
        {
            List<User> list = context.Set<User>().Include(p => p.Phones).ToList();
            int size = list.Count();
            User user;
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    if (list[i].Name.CompareTo(list[j].Name)>0 )
                    {
                        user = list[i];
                        list[i] = list[j];
                        list[j] = user;
                    }
                    else if(list[i].Name.CompareTo(list[j].Name) == 0 && list[i].Surname.CompareTo(list[j].Surname)>0)
                    {
                        user = list[i];
                        list[i] = list[j];
                        list[j] = user;
                    }
                }
            }

            return list.AsQueryable();
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
