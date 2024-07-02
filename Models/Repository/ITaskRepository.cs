namespace TaskHub.Models.Repository;

public interface ITaskRepository<in T> where T : Models.Task
{
    Task<Models.Task> Add(T task);
    Task<Models.Task> Update(Guid taskId, T task);
    Task<bool> Delete(Guid taskId);
    Task<Models.Task> Get(Guid taskId);
    public Task<List<Models.Task>> GetAll();
    Task<List<Models.Task>> GetByCategory(string categoryName);
}