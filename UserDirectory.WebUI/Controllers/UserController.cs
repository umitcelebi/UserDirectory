using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using UserDirectory.Data.Abstract;
using UserDirectory.Entity;

namespace UserDirectory.WebUI.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository userRepository;

        public UserController(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user,string[] Phone,IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", file.FileName);
                    using (var stream=new FileStream(path,FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    user.Image = file.FileName;
                }

                List<Phone> list = new List<Phone>();
                foreach (var item in Phone)
                {
                    list.Add(new Phone() { PhoneNumber = item });
                }

                user.Phones = list;
                userRepository.Add(user);
                userRepository.Save();

                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }
        public IActionResult Edit(int userId)
        {
            
            return View(userRepository.GetById(userId));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User user, string[] Phone,IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", file.FileName);
                    using (var stream=new FileStream(path,FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    user.Image = file.FileName;
                }
                List<Phone> list = new List<Phone>();
                foreach (var item in Phone)
                {
                    list.Add(new Phone() { PhoneNumber = item });
                }

                user.Phones = list;
                userRepository.Edit(user);

                userRepository.Save();

                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }

        public IActionResult Delete(int userId)
        {
            var user = userRepository.GetById(userId);
            if (user != null)
            {
                userRepository.Delete(user);
                userRepository.Save();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
