using com.itransition.messenger.Models;
using Microsoft.EntityFrameworkCore;

namespace com.itransition.messenger.Models.Data;

public sealed class MessengerContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Message> Messages { get; set; } = null!;
    public DbSet<MessageToUsers> MessageToUsers { get; set; } = null!;
    
    public MessengerContext(DbContextOptions<MessengerContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}