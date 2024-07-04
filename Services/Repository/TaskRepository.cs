using MongoDB.Driver;
using TaskHub.Models.Repository;
using Task = TaskHub.Models.Task;

namespace TaskHub.Services.Repository;

public class TaskRepository(IMongoCollection<Task> tasks) : ITaskRepository<Task>
{
    public async Task<Task> Add(Task task)
    {
        await tasks.InsertOneAsync(task);
        return task;
    }

    public async Task<Task> Update(Guid taskId, Task task)
    {
        await tasks.ReplaceOneAsync(t => t.TaskId == taskId, task);
        return task;    
    }

    async Task<bool> ITaskRepository<Task>.Delete(Guid taskId)
    {
        return (await tasks.DeleteOneAsync(t => t.TaskId == taskId)).DeletedCount != 0;
    }

    async Task<Task> ITaskRepository<Task>.Get(Guid taskId)
    {
        return await tasks.Find(t => t.TaskId == taskId).FirstOrDefaultAsync();
    }

    async Task<List<Task>> ITaskRepository<Task>.GetAll()
    {
        var x = await tasks.Find(t => true).ToListAsync();
        return x;
    }
}