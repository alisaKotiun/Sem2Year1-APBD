using Animals.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Animals.Services
{
    public interface IDatabaseService
    {
        IEnumerable<Animal> GetAnimals(string orderBy);
        string CreateAnimal(Animal animal);
        string UpdateAnimal(string id, Animal animal);
        string DeleteAnimal(string id);
    }
    public class MockDatebaseService : IDatabaseService
    {
        private IConfiguration _configuration;

        public MockDatebaseService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<Animal> GetAnimals(string orderBy)
        {
            var res = new List<Animal>();
            using (SqlConnection connection = new(_configuration.GetConnectionString("ProductionDb")))
            {
                using (SqlCommand command = new())
                {
                    command.Connection = connection;
                    //Parameters.AddWithValue didn't work here for me(
                    command.CommandText = GetAnimalsString(orderBy);

                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        var animal = new Animal
                        {
                            Id = (int)dr["IdAnimal"],
                            Name = dr["Name"].ToString(),
                            Description = dr["Description"].ToString(),
                            Category = dr["Category"].ToString(),
                            Area = dr["Area"].ToString()
                        };
                        res.Add(animal);
                    }
                }
            }
            return res;
        }

        public string CreateAnimal(Animal animal)
        {
            using (SqlConnection connection = new(_configuration.GetConnectionString("ProductionDb")))
            {
                using (SqlCommand command = new())
                {
                    command.Connection = connection;

                    command.CommandText = "INSERT INTO ANIMAL (Name, Description, Category, Area) VALUES(@name, @desc, @category, @area)";
                    command.Parameters.AddWithValue("@name", animal.Name);
                    command.Parameters.AddWithValue("@desc", animal.Description);
                    command.Parameters.AddWithValue("@category", animal.Category);
                    command.Parameters.AddWithValue("@area", animal.Area);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return "Animal was added";
        }

        public string UpdateAnimal(string id, Animal animal)
        {
            int n;
            using (SqlConnection connection = new(_configuration.GetConnectionString("ProductionDb")))
            {
                using (SqlCommand command = new())
                {
                    command.Connection = connection;

                    command.CommandText = "UPDATE ANIMAL SET Name=@name, Description=@desc, Category=@category, Area=@area WHERE IdAnimal=@id";
                    command.Parameters.AddWithValue("@name", animal.Name);
                    command.Parameters.AddWithValue("@desc", animal.Description);
                    command.Parameters.AddWithValue("@category", animal.Category);
                    command.Parameters.AddWithValue("@area", animal.Area);
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    n = command.ExecuteNonQuery();
                }
            }
            string messsage = n == 0 ? "No record was changed" : "Animal " + id + " was updated";
            return messsage;
        }
        public string DeleteAnimal(string id)
        {
            int n = 0;
            using (SqlConnection connection = new(_configuration.GetConnectionString("ProductionDb")))
            {
                using (SqlCommand command = new())
                {
                    command.Connection = connection;

                    command.CommandText = "DELETE FROM ANIMAL WHERE IdAnimal=@id";
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    n = command.ExecuteNonQuery();
                }
            }
            return n + " row(s) were deleted";
        }

        private static string GetAnimalsString(string orderBy)
        {
            string res = "SELECT * FROM ANIMAL ORDER BY ";
            res += orderBy switch
            {
                "Name" => "Name",
                "Description" => "Description",
                "Category" => "Category",
                "Area" => "Area",
                _ => throw new ArgumentException("Wrong column name"),
            };
            return res; 
        }
    }
}