using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DishClassLibrary;
using DishClassLibrary.temp.test;

namespace DataAccessLayer
{
    public class DAL//:IDataAccess
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; Initial Catalog = DishDB; Integrated Security=True;";

        public void SetBooks(Set_Books book)
        {
            string sqlexpression = "book_insert";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlexpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter BookIdParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = book.Id
                };
                command.Parameters.Add(BookIdParam);

                SqlParameter BookNameParam = new SqlParameter
                {
                    ParameterName = "@book",
                    Value = book.BookName
                };
                command.Parameters.Add(BookNameParam);
                command.ExecuteNonQuery();

                try
                {
                    command.ExecuteNonQuery();
                }
                catch
                {

                }
                connection.Close();
            }
        }

        public List<Get_or_Set_types> GetTypes()
        {
            List<DishClassLibrary.temp.test.Get_or_Set_types> list = new List<DishClassLibrary.temp.test.Get_or_Set_types>();
            string sqlexpression = "type_get";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlexpression, connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Get_or_Set_types type = new Get_or_Set_types();
                    type.Id = reader.GetInt32(0);
                    type.Type = reader.GetString(1);
                    type.Info = reader.GetString(2);
                    list.Add(type);
                }
                reader.Close();
            }
            return list;
        }

        public void SetTypes(Get_or_Set_types type)
        {
            string sqlexpression = "type_insert";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlexpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter IdParam = new SqlParameter
                {
                    ParameterName ="@id",
                    Value=type.Id
                };
                command.Parameters.Add(IdParam);

                /*SqlParameter TypeIdParam = new SqlParameter
                {

                };
                command.Parameters.Add(TypeIdParam);*/

                SqlParameter TypeNameParam = new SqlParameter
                {
                    ParameterName = "@type",
                    Value = type.Type
                };
                command.Parameters.Add(TypeNameParam);

                SqlParameter InfoParam = new SqlParameter
                {
                    ParameterName = "@info",
                    Value = type.Info
                };
                command.Parameters.Add(InfoParam);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch
                {

                }
                connection.Close();

            }
        }

        public void SetDishes(Set_Dish dish)
        {
            string sqlexpression = "dish_insert";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlexpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter IdParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = dish.Id
                };
                command.Parameters.Add(IdParam);

                SqlParameter DishNameParam = new SqlParameter
                {
                    ParameterName = "@dish",
                    Value = dish.Dish
                };
                command.Parameters.Add(DishNameParam);

                SqlParameter BookIdParam = new SqlParameter
                {
                    ParameterName = "@bookid",
                    Value = dish.BookId
                };
                command.Parameters.Add(BookIdParam);

                SqlParameter TypeIdParam = new SqlParameter
                {
                    ParameterName = "@typeid",
                    Value = dish.TypeId
                };
                command.Parameters.Add(TypeIdParam);

                SqlParameter TimeParam = new SqlParameter
                {
                    ParameterName = "@time",
                    Value = dish.Time
                };
                command.Parameters.Add(TimeParam);

                SqlParameter ExampleParam = new SqlParameter
                {
                    ParameterName = "@example",
                    Value = dish.Example
                };
                command.Parameters.Add(ExampleParam);

                SqlParameter AboutParam = new SqlParameter
                {
                    ParameterName = "@about",
                    Value = dish.About
                };
                command.Parameters.Add(AboutParam);

                SqlParameter HowToCraftParam = new SqlParameter
                {
                    ParameterName = "@howtocraft",
                    Value = dish.HowToCraft
                };
                command.Parameters.Add(HowToCraftParam);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch
                {

                }
            }
        }

        public Set_Dish GetSingleDish(int id)
        {
            string sqlexpression = "dish_get_single";
            Set_Dish dish = new Set_Dish();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlexpression, connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dish.Id = reader.GetInt32(0);
                    dish.Dish = reader.GetString(1);
                    dish.BookId = reader.GetInt32(2);
                    dish.TypeId = reader.GetInt32(3);
                    dish.Time = reader.GetInt32(4);
                    dish.Temperature = reader.GetInt32(5);
                    dish.Example = (byte[])reader.GetValue(6);
                    dish.About = reader.GetString(7);
                    dish.HowToCraft = reader.GetString(8);
                }
                reader.Close();
            }
            return dish;
        }

        public void UpdateDish(Set_Dish dish)
        {
            string sqlexpression = "dish_update";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlexpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter IdParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = dish.Id
                };
                command.Parameters.Add(IdParam);

                SqlParameter DishNameParam = new SqlParameter
                {
                    ParameterName = "@dish",
                    Value = dish.Dish
                };
                command.Parameters.Add(DishNameParam);

                SqlParameter BookIdParam = new SqlParameter
                {
                    ParameterName = "@bookid",
                    Value = dish.BookId
                };
                command.Parameters.Add(BookIdParam);

                SqlParameter TypeIdParam = new SqlParameter
                {
                    ParameterName = "@typeid",
                    Value = dish.TypeId
                };
                command.Parameters.Add(TypeIdParam);

                SqlParameter TimeParam = new SqlParameter
                {
                    ParameterName = "@time",
                    Value = dish.Time
                };
                command.Parameters.Add(TimeParam);

                SqlParameter ExampleParam = new SqlParameter
                {
                    ParameterName = "@example",
                    Value = dish.Example
                };
                command.Parameters.Add(ExampleParam);

                SqlParameter AboutParam = new SqlParameter
                {
                    ParameterName = "@about",
                    Value = dish.About
                };
                command.Parameters.Add(AboutParam);

                SqlParameter HowToCraftParam = new SqlParameter
                {
                    ParameterName = "@howtocraft",
                    Value = dish.HowToCraft
                };
                command.Parameters.Add(HowToCraftParam);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch
                {

                }
            }

        }

        public void DeleteDishAndRelation(int id)
        {
            string sqlexpression = "dish_delete";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlexpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter IdParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                command.Parameters.Add(IdParam);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch
                {

                }
            }
        }

        public List<DishWithTypes> GetDishesWithTypesList()
        {
            List<DishWithTypes> list = new List<DishWithTypes>(); 
            string sqlexpression = "dish_get";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlexpression, connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DishWithTypes dish = new DishWithTypes();
                    dish.Id = reader.GetInt32(0);
                    dish.Dish = reader.GetString(1);
                    dish.BookId = reader.GetInt32(2);
                    dish.Time = reader.GetInt32(3);
                    dish.Temperature = reader.GetInt32(4);
                    dish.Example = (byte[])reader.GetValue(5);
                    dish.About = reader.GetString(6);
                    dish.HowToCraft = reader.GetString(7);
                    dish.TypeName = reader.GetString(8);//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    list.Add(dish);
                }              
                reader.Close();
            }
            return list;
        }

        public void SetIngredient(Set_Ingredients ingredient)
        {
            string sqlexpression = "ingredients_insert";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlexpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter IngredientIdParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = ingredient.Id
                };
                command.Parameters.Add(IngredientIdParam);

                SqlParameter IngredientNameParam = new SqlParameter
                {
                    ParameterName = "@ingredient",
                    Value = ingredient.Ingredient
                };
                command.Parameters.Add(IngredientNameParam);

                SqlParameter InfoParam = new SqlParameter
                {
                    ParameterName = "@info",
                    Value = ingredient.Info
                };
                command.Parameters.Add(InfoParam);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch
                {

                }
            }
        }

        public void DeleteIngredientRelation(Get_Ingredients ingredient)
        {
            string sqlexpression = "ingredient_delete";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlexpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter IdParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = ingredient.Id
                };
                command.Parameters.Add(IdParam);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch
                {

                }
            }

        }

        public void SetRelation(Set_DishIngredient_Relation relation)
        {
            string sqlexpression = "dishes_addrelationtoingredient";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlexpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter IdParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = relation.id
                };
                command.Parameters.Add(IdParam);

                SqlParameter DishIdParam = new SqlParameter
                {
                    ParameterName = "@dishid",
                    Value = relation.DishId
                };
                command.Parameters.Add(DishIdParam);

                SqlParameter IngredientIdParam = new SqlParameter
                {
                    ParameterName = "@ingredientid",
                    Value = relation.IngredientId
                };
                command.Parameters.Add(IngredientIdParam);

                SqlParameter WeightParam = new SqlParameter
                {
                    ParameterName = "@weight",
                    Value = relation.Weight

                };
                command.Parameters.Add(WeightParam);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch
                {

                }
            }
        }

        public List<Get_Ingredients> GetIngredients()
        {
            List<DishClassLibrary.temp.test.Get_Ingredients> list = new List<DishClassLibrary.temp.test.Get_Ingredients>();
            string sqlexpression = "ingredient_get";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlexpression, connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DishClassLibrary.temp.test.Get_Ingredients ingredient = new DishClassLibrary.temp.test.Get_Ingredients();
                    ingredient.Id = reader.GetInt32(0);
                    ingredient.Ingredient = reader.GetString(1);
                    ingredient.Info = reader.GetString(2);
                    list.Add(ingredient);
                }
                reader.Close();
            }
            return list;
        }

        public List<Get_Ingredients_with_dishes> GetRelation(int id)
            {
                List<DishClassLibrary.temp.test.Get_Ingredients_with_dishes> list = new List<DishClassLibrary.temp.test.Get_Ingredients_with_dishes>();
                string sqlexpression = "ingredients_getfromdish";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlexpression, connection);
                    // указываем, что команда представляет хранимую процедуру
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter DishIdParam = new SqlParameter
                    {
                        ParameterName = "@dishid",
                        Value = id
                    };
                    command.Parameters.Add(DishIdParam);
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        DishClassLibrary.temp.test.Get_Ingredients_with_dishes relation = new DishClassLibrary.temp.test.Get_Ingredients_with_dishes();
                        relation.Id = reader.GetInt32(0);
                        relation.DishId = reader.GetInt32(1);
                        relation.Ingredient = reader.GetString(2);
                        relation.Info = reader.GetString(3);
                        list.Add(relation);
                    }
                    reader.Close();
                }
                return list;
            }

        public List<DishWithTypes> GetDishesByName(string name)
        {
            List<DishWithTypes> list = new List<DishWithTypes>();
            string sqlexpression = "DishSelect";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlexpression, connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter NameParameter = new SqlParameter
                {
                    ParameterName = "@dishname",
                    Value = name
                };
                command.Parameters.Add(NameParameter);

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DishWithTypes dish = new DishWithTypes();
                    dish.Id = reader.GetInt32(0);
                    dish.Dish = reader.GetString(1);
                    dish.BookId = reader.GetInt32(2);
                    dish.Time = reader.GetInt32(3);
                    dish.Temperature = reader.GetInt32(4);
                    dish.Example = (byte[])reader.GetValue(5);
                    dish.About = reader.GetString(6);
                    dish.HowToCraft = reader.GetString(7);
                    dish.TypeName = reader.GetString(8);//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    list.Add(dish);
                }
                reader.Close();
            }
            return list;
        }

        public List<DishWithTypes> GetDishesByType(string type)
        {
            List<DishWithTypes> list = new List<DishWithTypes>();
            string sqlexpression = "TypeSelect";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlexpression, connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter NameParameter = new SqlParameter
                {
                    ParameterName = "@typetname",
                    Value = type
                };
                command.Parameters.Add(NameParameter);

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DishWithTypes dish = new DishWithTypes();
                    dish.Id = reader.GetInt32(0);
                    dish.Dish = reader.GetString(1);
                    dish.BookId = reader.GetInt32(2);
                    dish.Time = reader.GetInt32(3);
                    dish.Temperature = reader.GetInt32(4);
                    dish.Example = (byte[])reader.GetValue(5);
                    dish.About = reader.GetString(6);
                    dish.HowToCraft = reader.GetString(7);
                    dish.TypeName = reader.GetString(8);//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    list.Add(dish);
                }
                reader.Close();
            }
            return list;
        }

        public List<Get_Ingredients> GetIngredientsByName(string name)
        {
            List<DishClassLibrary.temp.test.Get_Ingredients> list = new List<DishClassLibrary.temp.test.Get_Ingredients>();
            string sqlexpression = "IngredientSelect";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlexpression, connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter NameParameter = new SqlParameter
                {
                    ParameterName = "@ingredientname",
                    Value = name
                };
                command.Parameters.Add(NameParameter);

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DishClassLibrary.temp.test.Get_Ingredients ingredient = new DishClassLibrary.temp.test.Get_Ingredients();
                    ingredient.Id = reader.GetInt32(0);
                    ingredient.Ingredient = reader.GetString(1);
                    ingredient.Info = reader.GetString(2);
                    list.Add(ingredient);
                }
                reader.Close();
            }
            return list;
        }

    }

}