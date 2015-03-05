using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ScaryStoriesUniversal.Database.DataAccess;
using ScaryStoriesUniversal.Database.Entities;

using ScaryStoriesUniversal.Database.Repositories.Base;
using SQLite;

namespace ScaryStoriesUniversal.Database.Repositories
{
    public class PhotoCachingRepository : IPhotoCachingRepository
    {
        private readonly SQLiteAsyncConnection _connection;

        public PhotoCachingRepository(IDbConnection connection)
        {
            _connection = connection.GetAsyncConnection();
        }

        public async Task InsertAsync(PhotoEntity photo)
        {
            await _connection.InsertAsync(photo);
        }

        public async Task<IEnumerable<PhotoEntity>> GetRandomPhoto()
        {
            //SELECT * FROM table ORDER BY RANDOM() LIMIT 1;
            return await _connection.QueryAsync<PhotoEntity>("SELECT * FROM PhotoEntity ORDER BY RANDOM() LIMIT 1");
        }

        public async Task<int> DeleteAll()
        {
            return await _connection.ExecuteScalarAsync<int>("Delete From PhotoEntity");
        }
    }
}
