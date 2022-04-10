using Microsoft.Extensions.Configuration;
using Store.Business.Entities;
using Store.Business.Interfaces;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Dapper.Contrib.Extensions;

namespace Store.DA.Repositories;
internal class ProductRepository : IProductRepository
{
    private string _connectionString = string.Empty;

    public ProductRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DbConnection");
    }

    public Task<int> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> Save(Product product)
    {
        try
        {
            using SqlConnection conn = new(_connectionString);
            conn.Open();
            return await conn.InsertAsync(product);
        }
        catch (Exception e)
        {

            throw;
        }
    }
}
