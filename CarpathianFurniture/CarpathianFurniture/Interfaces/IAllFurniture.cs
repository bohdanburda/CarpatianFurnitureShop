using CarpathianFurniture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpathianFurniture.Interfaces
{
   public interface IAllFurniture
    {
        IEnumerable<Furniture> Furnitures { get; }

    //    IEnumerable<Furniture> GetFavouriteFurniture { get; }

        Furniture getObjectFurniture(int FurnitureID);
    }
}
