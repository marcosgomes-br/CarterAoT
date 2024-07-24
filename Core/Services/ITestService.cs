using Core.Models;

namespace Core.Services
{
    public interface ITestService
    {
        Task<IEnumerable<Post>> GetPosts();
    }
}