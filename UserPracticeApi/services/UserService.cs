
public class UserService : IUserService
{


    private IUserRepository _userRepository;

    public UserService(IUserRepository userRepository){
        _userRepository = userRepository;
    }
    public Task<bool> Add(User user)
    {
        return _userRepository.Add(user);
    }

    public Task<bool> Delete(int userId)
    {
        return _userRepository.Delete(userId);
    }

    public Task<User> GetUser(int userId)
    {
        return _userRepository.GetUser(userId);
    }

    public Task<IEnumerable<User>> GetUsers()
    {
        return _userRepository.GetUsers();
    }
}