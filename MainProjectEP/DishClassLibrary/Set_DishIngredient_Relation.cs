using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DishClassLibrary.temp.test
{
    public class Set_DishIngredient_Relation
    {
        public int id { get; set; }
        public int DishId { get; set; }
        public int IngredientId { get; set; }
        public string Weight { get; set; }
    }
}
