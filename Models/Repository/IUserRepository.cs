namespace TaskHub.Models.Repository;

public interface IUserRepository<in T> where T : User
{
    Task<User> AddUser(T user);
    Task<User> UpdateUser(Guid userId, T user);
    Task<bool> DeleteUser(Guid userId);
    Task<User> GetUser(Guid userId);
}