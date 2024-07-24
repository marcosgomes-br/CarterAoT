using Carter;
using Core.Models;
using Core.Services;

namespace Api
{
    public class PostModule 
    {

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var todoGroup = app.MapGroup("Posts");
            todoGroup.MapGet("/", async (ITestService testeService, HttpResponse res) =>
                 await GetPosts(testeService)

            ).WithName("getPosts");
        }

        public async Task<IResult> GetPosts(ITestService testService)
        {
            IEnumerable<Post> posts = [];

            posts = await testService.GetPosts();

            return Results.Ok(posts);

        }
    }
}
