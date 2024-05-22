using blogs.api.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;

namespace blogs.api.DataAccess
{
    public class BlogRepository
    {
        private readonly string _connectionString;

        public BlogRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Blog>> GetBlogsAsync()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Blogs";
                return await db.QueryAsync<Blog>(sql);
            }
        }
    }
}
