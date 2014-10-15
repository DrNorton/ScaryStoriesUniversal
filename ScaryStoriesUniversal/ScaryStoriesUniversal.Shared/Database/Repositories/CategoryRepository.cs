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
    public class CategoryRepository : ICategoryRepository
    {
         private readonly SQLiteAsyncConnection _connection;

        public CategoryRepository(IDbConnection connection)
        {
            _connection = connection.GetAsyncConnection();
        }

        public async Task InsertCategoryAsync(Category category)
        {
            await _connection.InsertAsync(category);
        }
    }
}
