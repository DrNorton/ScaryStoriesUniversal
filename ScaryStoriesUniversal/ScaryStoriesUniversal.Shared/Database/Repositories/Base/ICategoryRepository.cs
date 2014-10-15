using System.Threading.Tasks;
using ScaryStoriesUniversal.Database.Entities;

namespace ScaryStoriesUniversal.Database.Repositories.Base
{
    public interface ICategoryRepository
    {
        Task InsertCategoryAsync(Category category);
    }
}