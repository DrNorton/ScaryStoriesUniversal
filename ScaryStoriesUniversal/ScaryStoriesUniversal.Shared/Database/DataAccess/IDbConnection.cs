using System.Threading.Tasks;
using SQLite;

namespace ScaryStoriesUniversal.Database.DataAccess
{
    public interface IDbConnection
    {
        Task InitializeDatabase();
        SQLiteAsyncConnection GetAsyncConnection();
    }
}
