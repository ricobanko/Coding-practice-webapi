using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.Services;
using TodoApi.CustomBinders;
using Microsoft.AspNetCore.Builder;
using TodoApi.Controllers.ExceptionFilters;
using TodoApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IToDoService, ToDoItemService>();

builder.Services.AddDbContext<TodoContext>(opt =>
    opt.UseInMemoryDatabase("TodoList"));

builder.Services.AddControllers(options => 
{ 
    options.ModelBinderProviders.Insert(0, new TodoItemDTOModelBinderProvider());
    options.Filters.Add<CustomExceptionFilterTest>();
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.MapOpenApi();
} 
else 
{
    app.UseExceptionHandler("/error");
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseRequestMiddlewareTest();

app.Run();
