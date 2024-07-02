using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TaskHub.Models;
using Task = TaskHub.Models.Task;

namespace TaskHub.Services;
public class MongoDbService
{
    private readonly IMongoCollection<Task> _tasks;
    private readonly IMongoCollection<User> _users;

    public MongoDbService(IOptions<DataBaseSettings> options)
    {
        var settings = options.Value;
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);
        _tasks = database.GetCollection<Task>("Tasks");
        _users = database.GetCollection<User>("Users");
    }

    public IMongoCollection<Task> TaskColletion => _tasks;
    public IMongoCollection<User> UserColletion => _users;
}