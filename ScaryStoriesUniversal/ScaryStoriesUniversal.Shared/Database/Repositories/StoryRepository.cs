using System.Threading.Tasks;
using ScaryStoriesUniversal.Database.DataAccess;
using ScaryStoriesUniversal.Database.Entities;
using ScaryStoriesUniversal.Database.Repositories.Base;
using SQLite;

namespace ScaryStoriesUniversal.Database.Repositories
{
    public class StoryRepository : IStoryRepository
    {
        private readonly SQLiteAsyncConnection _connection;

        public StoryRepository(IDbConnection connection)
        {
            _connection = connection.GetAsyncConnection();
        }

        public async Task InsertStoryAsync(Story story)
        {
            await _connection.InsertAsync(story);
        }
    }
}
