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
    public class UserRepositoryADO : IUserRepository
    {
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb;" +
                                    "Initial Catalog = HeroesVsMonsters;" +
                                    "Integrated Security = true;";


        public bool CheckCredentials(string nickname, string password)
        {
            User user = new User();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;

                    command.CommandText = "SELECT * FROM Utente WHERE  Nickname = @nickname AND Pass = @password";
                    command.Parameters.AddWithValue("@nickname", nickname);
                    command.Parameters.AddWithValue("@password", password);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        user.Id = (int)reader["Id"];
                        user.NickName = (string)reader["Nickname"];
                        user.Password = (string)reader["Pass"];

                    }

                }
            }
            catch(Exception e)
            {
                throw e;
            }

            if (user.NickName != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckDiscriminator(string nickname)
        {
            User user = new User();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;

                    command.CommandText = "SELECT UserDiscriminator FROM Utente WHERE  Nickname = @nickname";
                    command.Parameters.AddWithValue("@nickname", nickname);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        user.UserDiscriminator = (int)reader["UserDiscriminator"];

                    }

                }
            }
            catch(Exception e)
            {
                throw e;
            }

            if (user.UserDiscriminator == 1) //admin torna true altrimenti 0 false
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public User GetById(int id)
        {
            User user = new User();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;

                    command.CommandText = "SELECT * FROM Utente WHERE  Id = @id";
                    command.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        user.Id = (int)reader["Id"];
                        user.NickName = (string)reader["Nickname"];
                        user.Password = (string)reader["Pass"];
                        user.UserDiscriminator = (int)reader["UserDiscriminator"];

                    }

                }
            }
            catch(Exception e)
            {
                throw e;
            }

            return user;
        }

        public User GetUserByNickname(string nickname)
        {
            User user = new User();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;

                    command.CommandText = "SELECT * FROM Utente WHERE  Nickname = @nickname";
                    command.Parameters.AddWithValue("@nickname", nickname);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        user.Id = (int)reader["Id"];
                        user.NickName = (string)reader["Nickname"];
                        user.Password = (string)reader["Pass"];
                        user.UserDiscriminator = (int)reader["UserDiscriminator"];

                    }

                }
            }
            catch(Exception e)
            {
                throw e;
            }

            return user;
        }

        public bool Insert(string nickname, string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;

                    command.CommandText = "INSERT INTO Utente(Nickname, Pass, UserDiscriminator) VALUES(@nickname, @password, @discr)";
                    command.Parameters.AddWithValue("@nickname", nickname);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@discr", 0);

                    command.ExecuteNonQuery();

                }
            }
            catch(Exception e)
            {
                return false;
            }

            return true;
        }

        public User Update(User user)
        {
            User u = new User();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;

                    command.CommandText = "update Utente set UserDiscriminator = @discr where Id=@id";
                    command.Parameters.AddWithValue("@id", user.Id);
                    command.Parameters.AddWithValue("@discr", user.UserDiscriminator);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        user.Id = (int)reader["Id"];
                        user.NickName = (string)reader["Nickname"];
                        user.Password = (string)reader["Pass"];
                        user.UserDiscriminator = (int)reader["UserDiscriminator"];

                    }

                }
            }
            catch(Exception e)
            {
                throw e;
            }

            return u;
        }
    }
}
