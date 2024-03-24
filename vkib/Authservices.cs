using System.Linq;
using vk1;
public class AuthService
{
    private readonly DataContext _context;

    public AuthService(DataContext context)
    {
        _context = context;
    }

    public bool Authenticate(string username, string password)
    {
        return _context.Users.Any(u => u.Username == username && u.Password == password);
    }
}