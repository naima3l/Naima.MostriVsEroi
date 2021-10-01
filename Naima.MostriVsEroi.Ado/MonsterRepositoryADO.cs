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
    public class MonsterRepositoryADO : IMonsterRepository
    {
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb;" +
                            "Initial Catalog = HeroesVsMonsters;" +
                            "Integrated Security = true;";

        public bool AddNewMonster(string name, Category category, Weapon weapon)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;

                    command.CommandText = "INSERT INTO Monster(Nome, IdCategory, IdWeapon) VALUES(@name , @cat, @weap)";
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@cat", category.idCategory);
                    command.Parameters.AddWithValue("@weap", weapon.IdWeapon);

                    command.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public Monster GetById(int monsterId)
        {
            Monster monster = new Monster();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;

                    command.CommandText = "SELECT * FROM Monster WHERE  Id = @id";
                    command.Parameters.AddWithValue("@id", monsterId);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        monster.Id = (int)reader["Id"];
                        monster.Name = (string)reader["Nome"];
                        monster.LifePoints = (int)reader["LifePoints"];
                        monster.Level = (int)reader["Livello"];
                        monster.Weapon.IdWeapon = (int)reader["IdWeapon"];
                        monster.Category.idCategory = (int)reader["IdCategory"];

                    }

                }
                return monster;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int GetLife(int monsterId)
        {
            int life = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;

                    command.CommandText = "SELECT LifePoints FROM Monster WHERE  Id = @id";
                    command.Parameters.AddWithValue("@id", monsterId);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        life = (int)reader["LifePoints"];
                    }

                }
                return life;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Monster> GetMonstersByHeroLevel(int level)
        {
            List<Monster> monsters = new List<Monster>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;

                    command.CommandText = "SELECT * FROM Monster WHERE Livello < @level";
                    command.Parameters.AddWithValue("@level", level);

                    SqlDataReader reader = command.ExecuteReader();
                    Monster monster = new Monster();

                    while (reader.Read())
                    {
                        monster.Id = (int)reader["Id"];
                        monster.Name = (string)reader["Nome"];
                        monster.LifePoints = (int)reader["LifePoints"];
                        monster.Level = (int)reader["Livello"];
                        monster.Weapon.IdWeapon = (int)reader["IdWeapon"];
                        monster.Category.idCategory = (int)reader["IdCategory"];

                        monsters.Add(monster);
                    }

                }
                return monsters;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Monster Update(Monster monster)
        {
            Monster m = new Monster();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;

                    command.CommandText = "update Monster set LifePoints = @life where Id=@id";
                    command.Parameters.AddWithValue("@id", monster.Id);
                    command.Parameters.AddWithValue("@life", monster.LifePoints);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        m.Id = (int)reader["Id"];
                        m.Name = (string)reader["Nome"];
                        m.LifePoints = (int)reader["LifePoints"];
                        m.Level = (int)reader["Livello"];
                        m.Weapon.IdWeapon = (int)reader["IdWeapon"];
                        m.Category.idCategory = (int)reader["IdCategory"];

                    }

                }
                return m;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
