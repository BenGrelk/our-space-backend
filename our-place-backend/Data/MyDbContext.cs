using Microsoft.EntityFrameworkCore;
using our_place_backend.Models;

namespace our_place_backend.Data;

public class MyDbContext(DbContextOptions<MyDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Channel> Channels { get; set; }
}