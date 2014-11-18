using System.Collections.Generic;
using System.Threading.Tasks;
using ScaryStoriesUniversal.Database.Entities;

namespace ScaryStoriesUniversal.Database.Repositories.Base
{
    public interface IFavoriteStoriesRepository
    {
        Task InsertAsync(FavoriteStory category);
        Task<IEnumerable<FavoriteStory>> GetAll();
        Task DeleteAsync(string id);
        Task<bool> CheckIsFavorite(string id);
        Task<IEnumerable<FavoriteStory>> GetFetch(int fetchCount, int count);
    }
}