namespace com.itransition.messenger.Models;

public class MessageToUsers
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int MessageId { get; set; }
    public Status Status { get; set; }
    
    public User? User { get; set; }
    public Message? Message { get; set; }
}