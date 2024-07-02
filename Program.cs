using TaskHub.Models;
using TaskHub.Models.Repository;
using TaskHub.Services;
using TaskHub.Services.Repository;
using Task = TaskHub.Models.Task;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DataBaseSettings>(
    builder.Configuration.GetSection("MongoDbConnection"));

builder.Services.AddSingleton<MongoDbService>();

builder.Services.AddScoped<ITaskRepository<Task>, TaskRepository>(sp =>
{
    var mongoDbService = sp.GetRequiredService<MongoDbService>();
    return new TaskRepository(mongoDbService.TaskColletion);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
