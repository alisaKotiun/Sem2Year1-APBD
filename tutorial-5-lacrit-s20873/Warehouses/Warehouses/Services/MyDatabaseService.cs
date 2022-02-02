using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.Common;
using System.Data.Entity.Core;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;
using Warehouses.Models;

namespace Warehouses.Services
{
    public interface IDatabaseService
    {
        Task<IActionResult> CreateRecord(ProductWarehouse productWarehouse);
        Task<IActionResult> CreateRecord2(ProductWarehouse productWarehouse);

    }
    public class MyDatabaseService : IDatabaseService
    {
        private IConfiguration _configuration;

        public MyDatabaseService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task<IActionResult> CreateRecord2(ProductWarehouse productWarehouse)
        {
            using SqlConnection connection = new(_configuration.GetConnectionString("ProductionDb"));
            using SqlCommand command = new("AddProductToWarehouse", connection);
            
            await connection.OpenAsync();

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdProduct", productWarehouse.IdProduct);
            command.Parameters.AddWithValue("@IdWarehouse", productWarehouse.IdWarehouse);
            command.Parameters.AddWithValue("@Amount", productWarehouse.Amount);
            command.Parameters.AddWithValue("@CreatedAt", productWarehouse.CreatedAt);

            try
            {
                return new OkObjectResult(await command.ExecuteNonQueryAsync());
            }
            catch(SqlException exc)
            {
                return new BadRequestObjectResult(exc.Message);
            }
        }

        public async Task<IActionResult> CreateRecord(ProductWarehouse productWarehouse)
        {
            using SqlConnection connection = new(_configuration.GetConnectionString("ProductionDb"));
            using SqlCommand command = new();

            command.Connection = connection;
            await connection.OpenAsync();

            using DbTransaction transaction = await connection.BeginTransactionAsync();
            command.Transaction = (SqlTransaction)transaction;

            try
            {
                //1
                if (await CheckIfExist(command, productWarehouse.IdProduct, "SELECT COUNT(*) as num FROM Product WHERE IdProduct=@id")) 
                    throw new ObjectNotFoundException("Product is not found");

                if (await CheckIfExist(command, productWarehouse.IdWarehouse, "SELECT COUNT(*) as num FROM Warehouse WHERE IdWarehouse=@id")) 
                    throw new ObjectNotFoundException("Warehouse is not found");

                //2
                int orderId;
                if ((orderId = await CheckOrderExist(command, productWarehouse.IdProduct, productWarehouse.Amount, productWarehouse.CreatedAt)) == 0)
                    throw new ObjectNotFoundException("Order is not found");

                //3
                if (await CheckOrderNotFulfilled(command, orderId))
                    throw new ArgumentException("Order is already fulfilled");

                if (await CheckOrderInPW(command, orderId))
                    throw new ArgumentException("Order is already in Product_Warehouse");

                //4
                command.Parameters.Clear();
                command.CommandText = "UPDATE [Order] SET FulfilledAt=SYSDATETIME() WHERE IdOrder=@id";
                command.Parameters.AddWithValue("@id", orderId);
                await command.ExecuteNonQueryAsync();

                //5
                string price = await CalculatePrice(command, productWarehouse.IdProduct);

                command.Parameters.Clear();
                command.CommandText = "INSERT INTO Product_Warehouse (IdWarehouse, IdProduct, IdOrder, Amount, Price, CreatedAt)" +
                    " VALUES(@idW, @idP, @idO, @amount, @price, SYSDATETIME())";
                command.Parameters.AddWithValue("@idW", productWarehouse.IdWarehouse);
                command.Parameters.AddWithValue("@idP", productWarehouse.IdProduct);
                command.Parameters.AddWithValue("@idO", orderId);
                command.Parameters.AddWithValue("@amount", productWarehouse.Amount);
                command.Parameters.AddWithValue("@price", price);
                await command.ExecuteNonQueryAsync();

                //6
                command.Parameters.Clear();
                command.CommandText = "SELECT @@Identity as newId FROM Product_Warehouse";
                var i = await command.ExecuteScalarAsync();

                await transaction.CommitAsync();
                return new OkObjectResult($"The record N{i} was successfully created");
            }
            catch (ObjectNotFoundException exc)
            {
                await transaction.RollbackAsync();
                return new NotFoundObjectResult(exc.Message);
            }
            catch (ArgumentException exc)
            {
                await transaction.RollbackAsync();
                return new BadRequestObjectResult(exc.Message);
            }
        }

        private static async Task<bool> CheckIfExist(SqlCommand command, int id, string query)
        {
            command.Parameters.Clear();
            command.CommandText = query;
            command.Parameters.AddWithValue("@id", id);

            using (var dr = await command.ExecuteReaderAsync())
            {
                await dr.ReadAsync();
                if (dr["num"].ToString().Equals("1"))
                {
                    return false;
                }
            }
            return true;
        }

        private static async Task<int> CheckOrderExist(SqlCommand command, int id, int amount, DateTime date)
        {
            command.Parameters.Clear();
            command.CommandText = "SELECT COUNT(*) as num FROM [Order] WHERE IdProduct=@id AND Amount=@amount AND CreatedAt<@date";
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@amount", amount);
            command.Parameters.AddWithValue("@date", date);

            using (var dr = await command.ExecuteReaderAsync())
            {
                await dr.ReadAsync();
                if (!dr["num"].ToString().Equals("1"))
                {
                    return 0;
                }
            }
            return await GetOrderId(command, id, amount, date);
        }

        private static async Task<int> GetOrderId(SqlCommand command, int id, int amount, DateTime date)
        {
            command.Parameters.Clear();
            command.CommandText = "SELECT IdOrder FROM [Order] WHERE IdProduct=@id AND Amount=@amount AND CreatedAt<@date";
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@amount", amount);
            command.Parameters.AddWithValue("@date", date);

            using var dr = await command.ExecuteReaderAsync();
            await dr.ReadAsync();
            return Int32.Parse(dr["IdOrder"].ToString());
        }

        private static async Task<bool> CheckOrderNotFulfilled(SqlCommand command, int id)
        {
            command.Parameters.Clear();
            command.CommandText = "SELECT COUNT(*) as num FROM [Order] WHERE IdOrder=@id AND FulfilledAt IS NULL";
            command.Parameters.AddWithValue("@id", id);

            using (var dr = await command.ExecuteReaderAsync())
            {
                await dr.ReadAsync();
                if (!dr["num"].ToString().Equals("1"))
                {
                    return true;
                }
            }
            return false;
        }

        private static async Task<bool> CheckOrderInPW(SqlCommand command, int id)
        {
            command.Parameters.Clear();
            command.CommandText = "SELECT COUNT(*) as num FROM Product_Warehouse WHERE IdOrder=@id";
            command.Parameters.AddWithValue("@id", id);
            using (var dr = await command.ExecuteReaderAsync())
            {
                await dr.ReadAsync();
                if (!dr["num"].ToString().Equals("0"))
                {
                    return true;
                }
            }
            return false;
        }

        private static async Task<string> CalculatePrice(SqlCommand command, int id)
        {
            command.Parameters.Clear();
            command.CommandText = "SELECT p.Price*o.Amount as price FROM Product p " +
                "JOIN[Order] o ON p.IdProduct = o.IdProduct" +
                " WHERE p.IdProduct=@id";
            command.Parameters.AddWithValue("@id", id);
            using (var dr = await command.ExecuteReaderAsync())
            {
                await dr.ReadAsync();
                return dr["price"].ToString();
            }
        }
    }
}
