using Microsoft.Data.SqlClient;
using Naima.MostriVsEroi.Core.Entities;
using Naima.MostriVsEroi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naima.MostriVsEroi.Ado
{
    public class CategoryRepositoryADO : ICategoryRepository
    {
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb;" +
                                    "Initial Catalog = HeroesVsMonsters;" +
                                    "Integrated Security = true;";
        public Category GetById(int idCategory)
        {
            Category category = new Category();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;

                    command.CommandText = "SELECT * FROM Category WHERE  IdCategory = @id";
                    command.Parameters.AddWithValue("@id", idCategory);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        category.idCategory = (int)reader["IdCategory"];
                        category.Name = (string)reader["Nome"];
                        category.Discriminator = (int)reader["Discriminator"];

                    }

                }
                return category;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Category> ShowCategoriesByDiscriminator(int v)
        {
            List<Category> categories = new List<Category>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;

                    command.CommandText = "SELECT * FROM Category WHERE  Discriminator = @discr";
                    command.Parameters.AddWithValue("@discr", v);

                    SqlDataReader reader = command.ExecuteReader();

                    Category category = new Category();
                    while (reader.Read())
                    {
                        category.idCategory = (int)reader["IdCategory"];
                        category.Name = (string)reader["Nome"];
                        category.Discriminator = (int)reader["Discriminator"];
                        categories.Add(category);
                    }

                }
                return categories;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
