using com.itransition.messenger.Models;
using com.itransition.messenger.Models.ViewModels;

namespace com.itransition.messenger.Services;

public interface IMessageService
{
    List<Message> GetMessagesByStatusAndUser(Status status, User user);
    Message CreateMessageFromModel(MessageViewModel model);
}