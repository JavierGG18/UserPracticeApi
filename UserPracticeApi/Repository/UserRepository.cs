

using Microsoft.EntityFrameworkCore;

public class UserRepository:IUserRepository{

    private UserContext _context;

    //Inyectar dependencias
    public UserRepository(UserContext context){
        _context = context;
    }


    //Metodos para crud
    public async Task<bool>  Add(User user)
    {
        //verificamos si el usuario existe
        var exist = await _context.Users.FindAsync(user.userId);
        if (exist != null){
            return false;
        }
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return true;

    }

    public async Task<bool> Delete(int userId)
    {
         //verificamos si el usuario existe
        var user = await _context.Users.FindAsync(userId);
        if (user == null){
            return false;
        }
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return true;

        
    }

    public async Task<User> GetUser(int userId)
    {
        return await _context.Users.FindAsync(userId);
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }
}