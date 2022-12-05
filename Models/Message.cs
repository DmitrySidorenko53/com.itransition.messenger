namespace com.itransition.messenger.Models;

public class Message
{
    public int MessageId { get; set; }
    public string Subject { get; set; } = null!;
    public string Text { get; set; } = null!;
    public DateTime SentDate { get; set; } 
    
    public IEnumerable<MessageToUsers>? MessageToUsers { get; set; }
}