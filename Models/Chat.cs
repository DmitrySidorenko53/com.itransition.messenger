namespace com.itransition.messenger.Models;

public class Chat
{
    public User Sender { get; set; } = null!;
    public User Recipient { get; set; } = null!;
    public Message Message { get; set; } = null!;
}