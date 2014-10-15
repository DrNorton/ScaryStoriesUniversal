using System.Threading.Tasks;
using ScaryStoriesUniversal.Database.Entities;

namespace ScaryStoriesUniversal.Database.Repositories.Base
{
    public interface IStoryRepository
    {
        Task InsertStoryAsync(Story story);
    }
}