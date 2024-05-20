using our_place_backend.Data;
using our_place_backend.Models;

namespace our_place_backend.Services;

public class UserServices(MyDbContext context)
{
    public List<User> GetUsers()
    {
        return context.Users.ToList();
    }
}