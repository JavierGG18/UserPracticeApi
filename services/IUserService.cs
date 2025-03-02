public interface IUserService{

    Task<bool> Add(User user);
    Task<bool> Delete(int userId);

    Task<User> GetUser(int userId);

    Task<IEnumerable<User>> GetUsers();

}