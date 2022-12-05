using com.itransition.messenger.Models;
using com.itransition.messenger.Models.Data;

namespace com.itransition.messenger.Services.Impl;

public class MessageToUsersServiceImpl : IMessageToUsersService
{
    private readonly MessengerContext _context;

    public MessageToUsersServiceImpl(MessengerContext context)
    {
        _context = context;
    }
    
    public void CreateChat(Chat chat)
    {
        var messageFrom = SaveMessageToUsers(chat, UserRole.Sender);
        var messageTo = SaveMessageToUsers(chat, UserRole.Recipient);
        var messages = new List<MessageToUsers>() {messageFrom, messageTo};
        _context.MessageToUsers.AddRange(messages);
        _context.SaveChanges();
    }

    private MessageToUsers SaveMessageToUsers(Chat chat, UserRole role)
    {
        return new MessageToUsers
        {
            UserId = role == UserRole.Sender ? chat.Sender.UserId : chat.Recipient.UserId,
            User = role == UserRole.Sender ? chat.Sender : chat.Recipient,
            Status = role == UserRole.Sender ? Status.Sent : Status.Received,
            MessageId = chat.Message.MessageId,
            Message = chat.Message
        };
    }
}