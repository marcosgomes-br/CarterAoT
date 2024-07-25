using Core.Models;

namespace Api
{
    public class TodoModule 
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {

            var todoGroup = app.MapGroup("Todos");
            todoGroup.MapGet("/{id}", GetTaskById).WithName("GetPatientById");
        }

        private IResult GetTaskById(HttpContext context, int id)
        {
            var sampleTodos = new Todo[] {
                 new(1, "Walk the dog"),
                 new(2, "Do the dishes", DateOnly.FromDateTime(DateTime.Now)),
                 new(3, "Do the laundry", DateOnly.FromDateTime(DateTime.Now.AddDays(1))),
                 new(4, "Clean the bathroom"),
                 new(5, "Clean the car", DateOnly.FromDateTime(DateTime.Now.AddDays(2)))
            };

            Todo? result = sampleTodos.FirstOrDefault(a => a.Id == id);

            return Results.Ok(result);
        
        }

    }
}
