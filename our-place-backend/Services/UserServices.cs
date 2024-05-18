using our_place_backend.Data;
using our_place_backend.Models;

namespace our_place_backend.Services;

public class UserServices(MyDbContext context)
{
    private readonly MyDbContext _context = context;

    public List<User> GetUsers()
    {
        return _context.Users.ToList();
    }
}