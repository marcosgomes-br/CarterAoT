using Api;
using Core.Models;
using Core.Services;
using Infrastructure.Services;


var builder = WebApplication.CreateSlimBuilder(args);


builder.Services.AddHttpClient();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<ITestService, TestService>();


builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, TodoJsonSerializerContext.Default);
    options.SerializerOptions.TypeInfoResolverChain.Insert(1, PostJsonSerializerContext.Default);
});

var app = builder.Build();


new TodoModule().AddRoutes(app);
new PostModule().AddRoutes(app);


app.Run();


