using System.Threading.Tasks;
using SQLite;

namespace ScaryStoriesUniversal.Entities.DataAccess
{
    public interface IDbConnection
    {
        Task InitializeDatabase();
        SQLiteAsyncConnection GetAsyncConnection();
    }
}
