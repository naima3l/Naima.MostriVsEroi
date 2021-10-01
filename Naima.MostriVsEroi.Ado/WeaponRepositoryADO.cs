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
    public class WeaponRepositoryADO : IWeaponRepository
    {
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb;" +
                                    "Initial Catalog = HeroesVsMonsters;" +
                                    "Integrated Security = true;";
        public Weapon GetById(int idWeapon)
        {
            Weapon weapon = new Weapon();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;

                    command.CommandText = "SELECT * FROM Weapon WHERE  IdWeapon = @id";
                    command.Parameters.AddWithValue("@id", idWeapon);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        weapon.IdCategory = (int)reader["IdCategory"];
                        weapon.Name = (string)reader["Nome"];
                        weapon.DamagePoints = (int)reader["DamagePoints"];

                    }

                }
                return weapon;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Weapon> ShowWeaponsByCategory(int idCategory)
        {
            List<Weapon> weapons = new List<Weapon>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;

                    command.CommandText = "SELECT * FROM Weapon WHERE  IdCategory = @id";
                    command.Parameters.AddWithValue("@id", idCategory);

                    SqlDataReader reader = command.ExecuteReader();

                    Weapon weapon = new Weapon();
                    while (reader.Read())
                    {
                        weapon.IdCategory = (int)reader["IdCategory"];
                        weapon.Name = (string)reader["Nome"];
                        weapon.DamagePoints = (int)reader["DamagePoints"];

                        weapons.Add(weapon);
                    }

                }
                return weapons;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
