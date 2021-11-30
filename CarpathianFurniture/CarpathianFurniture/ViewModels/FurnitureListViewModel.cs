using CarpathianFurniture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpathianFurniture.ViewModels
{
    public class FurnitureListViewModel
    {
        public IEnumerable<Furniture> AllFurniture { get; set; }
    }
}
