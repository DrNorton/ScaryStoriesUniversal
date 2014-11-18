using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScaryStoriesUniversal.Database.DataAccess;
using ScaryStoriesUniversal.Database.Entities;
using ScaryStoriesUniversal.Database.Repositories.Base;
using SQLite;

namespace ScaryStoriesUniversal.Database.Repositories
{
    public class FavoriteStoriesRepository : IFavoriteStoriesRepository
    {
        private readonly SQLiteAsyncConnection _connection;

        public FavoriteStoriesRepository(IDbConnection connection)
        {
            _connection = connection.GetAsyncConnection();
        }

        public async Task InsertAsync(FavoriteStory story)
        {
            await _connection.InsertAsync(story);
        }

        public async Task<IEnumerable<FavoriteStory>> GetAll()
        {
            return await _connection.Table<FavoriteStory>().OrderBy(x=>x.CreatedAt).ToListAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var item = await _connection.FindAsync<FavoriteStory>(x => x.Id == id);
            if (item != null)
            {
                await _connection.DeleteAsync(item);
            }
           
        }

        public async Task<bool> CheckIsFavorite(string id)
        {
            var item = await _connection.FindAsync<FavoriteStory>(x => x.Id == id);
            return (item != null);
        }


        public async Task<IEnumerable<FavoriteStory>> GetFetch(int limit, int offset)
        {
           var stories=await _connection.Table<FavoriteStory>().OrderBy(x => x.CreatedAt).Skip(offset).Take(limit).ToListAsync();
            return stories;
        }


    }
}
