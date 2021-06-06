using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserDirectory.Data.Abstract;

namespace UserDirectory.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository repository;
        public HomeController(IUserRepository _repository)
        {
            repository=_repository;
        }

        public IActionResult Index()
        {
            return View(repository.GetAllUser());
        }
    }
}
