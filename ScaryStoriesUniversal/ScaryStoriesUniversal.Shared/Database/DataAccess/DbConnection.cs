using System.Threading.Tasks;
using ScaryStoriesUniversal.Database.Entities;

using SQLite;

namespace ScaryStoriesUniversal.Database.DataAccess
{
    public class DbConnection : IDbConnection
    {
        string dbPath;
        SQLiteAsyncConnection conn;        

        public DbConnection(string path)
        {
            conn = new SQLiteAsyncConnection(path);
        }

        public async Task InitializeDatabase()
        {
          await  conn.CreateTableAsync<FavoriteStory>();
           await conn.CreateTableAsync<PhotoEntity>();

        }

        public SQLiteAsyncConnection GetAsyncConnection()
        {
            return conn;
        }
    }
}
