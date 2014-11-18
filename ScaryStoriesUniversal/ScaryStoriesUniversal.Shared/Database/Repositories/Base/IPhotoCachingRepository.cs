using System.Collections.Generic;
using System.Threading.Tasks;
using ScaryStoriesUniversal.Database.Entities;


namespace ScaryStoriesUniversal.Database.Repositories.Base
{
    public interface IPhotoCachingRepository
    {
        Task InsertAsync(PhotoEntity photo);
        Task<IEnumerable<PhotoEntity>> GetRandomPhoto();
    }
}