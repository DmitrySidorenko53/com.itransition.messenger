namespace com.itransition.messenger.Models;

public class User
{
    public int UserId { get; set; }
    public string Nickname { get; set; } = null!;
    public IEnumerable<MessageToUsers>? MessageToUsers { get; set; }
}