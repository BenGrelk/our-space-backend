using our_place_backend.Data;
using our_place_backend.Models;

namespace our_place_backend.Services;

public class UserServices(MyDbContext context)
{
    public bool CreateUser(CreateUserModel model)
    {
        int id;
        try
        {
            id = context.Users.Max(user => user.UserId) + 1;
        }
        catch
        {
            id = 1;
        }

        User user;
        try
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);

            user = new User
            {
                UserId = id,
                CreatedAt = DateTime.UtcNow,
                Username = model.Username,
                Password = hashedPassword,
                ProfilePicture = model.ProfilePicture,
                DisplayName = model.DisplayName,
                Status = model.Status,
                Description = model.Description,
                Settings = model.Settings,
                Banner = model.Banner
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }

        context.Users.Add(user);
        context.SaveChanges();

        return true;
    }

    public bool UpdateUser(int userId, CreateUserModel model)
    {
        var user = context.Users.FirstOrDefault(user => user.UserId == userId);
        if (user == null) return false;

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);

        user.Username = model.Username;
        user.Password = hashedPassword;
        user.ProfilePicture = model.ProfilePicture;
        user.DisplayName = model.DisplayName;
        user.Status = model.Status;
        user.Description = model.Description;
        user.Settings = model.Settings;
        user.Banner = model.Banner;

        context.SaveChanges();

        return true;
    }

    public bool DeleteUser(int userId)
    {
        var user = context.Users.FirstOrDefault(user => user.UserId == userId);
        if (user == null) return false;

        context.Users.Remove(user);
        context.SaveChanges();

        return true;
    }

    public bool AuthenticateUser(string username, string password)
    {
        var user = context.Users.FirstOrDefault(user => user.Username == username);
        if (user == null) return false;

        return BCrypt.Net.BCrypt.Verify(password, user.Password);
    }
    
    public UserResponseModel? GetUser(int userId)
    {
        var user = context.Users.FirstOrDefault(user => user.UserId == userId);
        if (user == null) return null;

        return new UserResponseModel
        {
            UserId = user.UserId,
            CreatedAt = user.CreatedAt,
            Username = user.Username,
            ProfilePicture = user.ProfilePicture,
            DisplayName = user.DisplayName,
            Status = user.Status,
            Description = user.Description,
            Settings = user.Settings,
            Banner = user.Banner
        };
    }
}