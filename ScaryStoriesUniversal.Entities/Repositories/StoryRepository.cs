using System.Threading.Tasks;
using ScaryStoriesUniversal.Entities.DataAccess;
using ScaryStoriesUniversal.Entities.Entities;
using ScaryStoriesUniversal.Entities.Repositories.Base;
using SQLite;

namespace ScaryStoriesUniversal.Entities.Repositories
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
