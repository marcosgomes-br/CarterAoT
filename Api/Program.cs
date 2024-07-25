using Api;
using Core.DTOs;
using Core.Models;
using Core.Services;
using Infrastructure.Services;


var builder = WebApplication.CreateSlimBuilder(args);


builder.Services.AddHttpClient();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<ITestService, TestService>();


builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Add(TodoJsonSerializerContext.Default);
    options.SerializerOptions.TypeInfoResolverChain.Add(PostJsonSerializerContext.Default);
    options.SerializerOptions.TypeInfoResolverChain.Add(GetPostJsonSerializerContext.Default);
    options.SerializerOptions.TypeInfoResolverChain.Add(InputPostDTOsonSerializerContext.Default);
    ServiceBase.options = options.SerializerOptions;
});



var app = builder.Build();


new TodoModule().AddRoutes(app);
new PostModule().AddRoutes(app);


app.Run();


