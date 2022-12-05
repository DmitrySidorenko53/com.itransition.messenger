using com.itransition.messenger.Models;
using com.itransition.messenger.Models.Data;
using com.itransition.messenger.Models.ViewModels;

namespace com.itransition.messenger.Services.Impl;

public class MessageServiceImpl : IMessageService
{
    private readonly MessengerContext _context;

    public MessageServiceImpl(MessengerContext context)
    {
        _context = context;
    }

    public List<Message> GetMessagesByStatusAndUser(Status status, User user)
    {
        return _context.Messages
            .Where(m => (m.MessageToUsers!.Any(um => um.UserId == user.UserId && um.Status == status)))
            .OrderByDescending(m => m.SentDate)
            .ToList();
    }

    public Message CreateMessageFromModel(MessageViewModel model)
    {
        var message = new Message
        {
            Subject = model.Subject,
            Text = model.Text,
            SentDate = DateTime.Now
        };
        _context.Messages.Add(message);
        return message;
    }
}