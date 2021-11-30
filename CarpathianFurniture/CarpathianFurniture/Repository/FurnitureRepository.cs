using CarpathianFurniture.Interfaces;
using CarpathianFurniture.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpathianFurniture.Repository
{
    public class FurnitureRepository : IAllFurniture
    {
        private readonly ApplicationContext AppContext;

        public FurnitureRepository(ApplicationContext AppContext)
        {
            this.AppContext = AppContext;
        }
        public IEnumerable<Furniture> Furnitures => AppContext.Furnitures;
        public Furniture getObjectFurniture(int Furnitureid) => AppContext.Furnitures.FirstOrDefault(p => p.FurnitureId == Furnitureid);


    }
}
