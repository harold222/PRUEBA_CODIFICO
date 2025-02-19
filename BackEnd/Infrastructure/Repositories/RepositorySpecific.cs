﻿using Application.Contracts.Persistence;
using Dapper;
using Domain;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repositories;

public class RepositorySpecific : IRepositorySpecific
{
    private readonly IConfiguration _configuration;

    public RepositorySpecific(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<IEnumerable<Orders>> GetOrderByClient(int Id)
    {
        using (SqlConnection connection = new(_configuration.GetConnectionString("Database")))
        {
            await connection.OpenAsync();

            string query = $@"SELECT Orderid, Requireddate, Shippeddate, Shipname, Shipaddress, Shipcity FROM Sales.Orders WHERE custid = @Id";

            return await connection.QueryAsync<Orders>(query, new { Id });
        }
    }
}
