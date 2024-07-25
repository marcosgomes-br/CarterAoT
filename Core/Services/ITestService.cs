using Core.DTOs;
using Core.Models;
using Core.Results;


namespace Core.Services
{
    public interface ITestService
    {
        Task<Result<IEnumerable<Post>>> GetPosts();
        Task<Result<Post>> InputPost(InputPostDTO inputPostDTO);
    }
}