using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DishClassLibrary.temp.test;

namespace BL
{
    public class BLclass
    {
        DAL dal = new DAL();

        public void SetBooks(Set_Books book)
        {
            dal.SetBooks(book);
        }

        public void SetType(Get_or_Set_types type)
        {
            dal.SetTypes(type);
        }

        public void SetDish(Set_Dish dish)
        {
            dal.SetDishes(dish);
        }

        public Set_Dish GetSingleDish(int id)
        {
            return dal.GetSingleDish(id);
        }

        public List<DishWithTypes> GetDishesWithTypesList()
        {
           return dal.GetDishesWithTypesList();
        }

        public List<Get_or_Set_types> GetTypes()
        {
            return dal.GetTypes();
        }

        public void SetRelation(Set_DishIngredient_Relation relation)
        {
            dal.SetRelation(relation);
        }

        public void SetIngredient(Set_Ingredients ingredient)
        {
            dal.SetIngredient(ingredient);
        }

        public List<Get_Ingredients_with_dishes> GetRelations(int id)
        {
            return dal.GetRelation(id);
        }

        public void UpdateDish(Set_Dish dish)
        {
            dal.UpdateDish(dish);
        }

        public void DeleteDish(int id)
        {
            dal.DeleteDishAndRelation(id);
        }

        public List<Get_Ingredients> GetIngredients()
        {
            return dal.GetIngredients();
        }

        public List<Get_Ingredients> GetIngredientsByName(string name)
        {
            return dal.GetIngredientsByName(name);
        }

        public List<DishWithTypes> GetDishesByName(string name)
        {
            return dal.GetDishesByName(name);
        }

        public List<DishWithTypes> GetDishesByTypes(string type)
        {
            return dal.GetDishesByType(type);
        }
    }
}
