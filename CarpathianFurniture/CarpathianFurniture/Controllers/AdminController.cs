using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarpathianFurniture.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using CarpathianFurniture.ViewModels;
using CarpathianFurniture.Interfaces;
using Microsoft.Extensions.Logging;

namespace CarpathianFurniture.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationContext db;
        private readonly IAllFurniture _allFurniture;

        public AdminController(ApplicationContext context, IAllFurniture iAllFurniture)
        {
            _allFurniture = iAllFurniture;
            db = context;
                       
        }



        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            //return View(await db.Furnitures.ToListAsync());
            return View();
          
        }
        [Authorize(Roles = "admin")]
        public IActionResult ViewCatalog()
        {
            //return View(await db.Furnitures.ToListAsync());
            FurnitureListViewModel obj = new FurnitureListViewModel();
            obj.AllFurniture = _allFurniture.Furnitures;
            return View(obj);
        }

        [Authorize(Roles = "admin")]
        public IActionResult DeleteItem(int item)
        {
            Furniture itemDb = db.Furnitures
                      .FirstOrDefault(u => u.FurnitureId == item);

            if (itemDb != null)
            {
                db.Furnitures.Remove(itemDb);
                db.SaveChanges();
            }

            FurnitureListViewModel obj = new FurnitureListViewModel();
            obj.AllFurniture = _allFurniture.Furnitures;

            return View("ViewCatalog", obj);
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(IFormFile file, Furniture furniture)
        {
            string name;
            name = file.FileName;
            using (var fileStream = new FileStream(Path.Combine("wwwroot/images/", name), FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(fileStream);
            }
            furniture.ImagePath = "/images/" + name;
            db.Furnitures.Add(furniture);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
