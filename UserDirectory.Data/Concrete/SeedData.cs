using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UserDirectory.Entity;

namespace UserDirectory.Data.Concrete
{
    public static class SeedData
    {
        public static void CreateSeed(IApplicationBuilder app)
        {
            ApplicationContext context = app.ApplicationServices.GetRequiredService<ApplicationContext>();

            context.Database.Migrate();


            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User()
                    {
                        Name = "Ümit",
                        Surname = "Çelebi",
                        Email = "umitclebi@gmail.com",
                        Birthday = DateTime.Now.AddYears(-24),
                        Image = "01.jpg",
                        Location = "İstanbul"
                    },
                    new User()
                    {
                        Name = "Muhammed",
                        Surname = "Yılmaz",
                        Email = "mey@gmail.com",
                        Birthday = DateTime.Now.AddYears(-23),
                        Image = "02.jpg",
                        Location = "Giresun"
                    },
                    new User()
                    {
                        Name = "Enes",
                        Surname = "Kandaz",
                        Email = "eneskandaz@gmail.com",
                        Birthday = DateTime.Now.AddYears(-25),
                        Image = "03.jpg",
                        Location = "Tekirdağ"
                    },
                    new User()
                    {
                        Name = "Taylan",
                        Surname = "Karaca",
                        Email = "taylankaraca@gmail.com",
                        Birthday = DateTime.Now.AddYears(-24),
                        Image = "04.jpg",
                        Location = "İstanbul"
                    },
                    new User()
                    {
                        Name = "Orhan",
                        Surname = "Eymur",
                        Email = "orhneymr@gmail.com",
                        Birthday = DateTime.Now.AddYears(-23),
                        Image = "05.jpg",
                        Location = "Tokat"
                    }
                    );
                context.SaveChanges();
            }


            if (!context.Phones.Any())
            {
                context.Phones.AddRange(
                    new Phone()
                    {
                        PhoneNumber = "05344444444",
                        UserId = 1
                    },
                    new Phone()
                    {
                        PhoneNumber = "05455555555",
                        UserId = 1
                    },
                    new Phone()
                    {
                        PhoneNumber = "05399999999",
                        UserId = 2
                    },
                    new Phone()
                    {
                        PhoneNumber = "05327777777",
                        UserId = 2
                    },
                    new Phone()
                    {
                        PhoneNumber = "05316666666",
                        UserId = 3
                    },
                    new Phone()
                    {
                        PhoneNumber = "05302000000",
                        UserId = 4
                    },
                    new Phone()
                    {
                        PhoneNumber = "05333333333",
                        UserId = 5
                    }
                    );
                context.SaveChanges();
            }


        }
    }
}
