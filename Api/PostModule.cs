using Core.DTOs;
using Core.Models;
using Core.Results;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api
{
    public class PostModule
    {

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var todoGroup = app.MapGroup("Posts");
            todoGroup.MapGet("/", GetPosts).WithName("getPosts");
            todoGroup.MapGet("/GetPostsByQuery", GetPostsByQuery);
            todoGroup.MapPost("/", InputPost);
        }

        public async Task<IResult> GetPosts(ITestService testeService)
        {
            Result<IEnumerable<Post>> posts;

            posts = await testeService.GetPosts();

            IEnumerable<GetPostDTO> result = posts.Value.Select(x => new GetPostDTO(x));

            return Results.Ok(new Result<IEnumerable<GetPostDTO>>(result));

        }

        public async Task<IResult> GetPostsByQuery([AsParameters] InputPostDTO inputPostDTO, ITestService testeService)
        {
            Result<IEnumerable<Post>> posts;

            posts = await testeService.GetPosts();

            IEnumerable<GetPostDTO> result = posts.Value.Where(w => w.Title == inputPostDTO.Title)
                .Select(x => new GetPostDTO(x));

            return Results.Ok(new Result<IEnumerable<GetPostDTO>>(result));

        }

        public async Task<IResult> InputPost([FromBody] InputPostDTO inputPostDTO, ITestService testeService)
        {


            Result<Post> post = await testeService.InputPost(inputPostDTO);
            GetPostDTO getpost = new(post.Value);

            return Results.Ok(new Result<GetPostDTO>(getpost));
        }
    }
}
