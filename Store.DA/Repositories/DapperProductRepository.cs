using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Store.Business.Entities;
using Store.Business.Interfaces;
using System.Data.SqlClient;

namespace Store.DA.Repositories
{
    internal class DapperProductRepository : IProductRepository
    {
        private string _connectionString = string.Empty;
        private readonly ILogger<DapperProductRepository> _logger;

        public DapperProductRepository(ILogger<DapperProductRepository> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetConnectionString("DbConnection");
        }


        public async Task<int> Save(Product product)
        {
            //"insert into table Products(1,2,3) values()";
            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            return await conn.InsertAsync(product);
        }


        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
