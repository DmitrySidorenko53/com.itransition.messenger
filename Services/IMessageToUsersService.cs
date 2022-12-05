using com.itransition.messenger.Models;

namespace com.itransition.messenger.Services;

public interface IMessageToUsersService
{
    void CreateChat(Chat chat);
}