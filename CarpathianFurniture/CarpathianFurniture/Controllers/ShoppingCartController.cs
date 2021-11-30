using CarpathianFurniture.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace CarpathianFurniture.Controllers
{
    public class ShoppingCartController : Controller
    {
        private ApplicationContext _context;
        public ShoppingCartController(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            User userDb = await _context.Users
                    .Include(u => u.Role).Include(shop => shop.ShoppingCart)
                    .FirstOrDefaultAsync(u => u.Email == User.Identity.Name);
            var data = userDb.ShoppingCart;
            return View(data);
        }
        public IActionResult AddItemToCart(int item, string user) 
        {
            User userDb = _context.Users
                    .Include(u => u.Role)
                    .FirstOrDefault(u => u.Email == user);
            Furniture itemDb = _context.Furnitures
                    .FirstOrDefault(u => u.FurnitureId == item);
            if (userDb != null && itemDb != null)
            {
                userDb.ShoppingCart.Add(itemDb);
                _context.Users.Update(userDb);
                _context.SaveChanges();
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return View();
        }

        public IActionResult ReturnToShop() 
        {
            return RedirectToAction("Index");
        }

        public IActionResult DeleteItem(int item, string user)
        {
            User userDb = _context.Users
                    .Include(u => u.Role)
                    .FirstOrDefault(u => u.Email == user);
            Furniture itemDb = _context.Furnitures
                    .FirstOrDefault(u => u.FurnitureId == item);
            if (userDb != null && itemDb != null)
            {
                userDb.ShoppingCart.Remove(itemDb);
                _context.Users.Update(userDb);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Buy(string user) 
        {
            User userDb = _context.Users
                   .Include(u => u.Role).Include(shop => shop.ShoppingCart)
                   .FirstOrDefault(u => u.Email == user);
            if (userDb != null)
            {
                userDb.ShoppingCart.Clear();
                _context.Users.Update(userDb);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
