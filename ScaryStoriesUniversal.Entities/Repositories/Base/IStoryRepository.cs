using System.Threading.Tasks;
using ScaryStoriesUniversal.Entities.Entities;

namespace ScaryStoriesUniversal.Entities.Repositories.Base
{
    public interface IStoryRepository
    {
        Task InsertStoryAsync(Story story);
    }
}