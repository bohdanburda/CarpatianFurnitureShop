using CarpathianFurniture.Interfaces;
using CarpathianFurniture.Models;
using CarpathianFurniture.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CarpathianFurniture.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAllFurniture _allFurniture;



        public HomeController(ILogger<HomeController> logger, IAllFurniture iAllFurniture, ApplicationContext context)
        {
            _logger = logger;
            _allFurniture = iAllFurniture;
            _context = context;
        }

        private ApplicationContext _context;
             
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                string role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
                if (role == "admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
            }
            ViewBag.Title = "Page with furniture";
            FurnitureListViewModel obj = new FurnitureListViewModel();
            obj.AllFurniture = _allFurniture.Furnitures;
            return View(obj);
        }
        public IActionResult UserPage()
        {
            User userDb = _context.Users
                   .Include(u => u.Role)
                   .FirstOrDefault(u => u.Email == User.Identity.Name);

            //return View(User.Identity);
            return View(userDb);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Change(User userdata)
        {
            User userDb = await _context.Users
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Email == User.Identity.Name);

            if (userdata.Name != null)
            {
                userDb.Name = userdata.Name;
            }
            if (userdata.Surname != null)
            {
                userDb.Surname = userdata.Surname;
            }
            if (userdata.Address != null)
            {
                userDb.Address = userdata.Address;
            }

            if(userDb != null)
            {
                _context.Users.Update(userDb);
                _context.SaveChanges();
            }

            return RedirectToAction("UserPage");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
