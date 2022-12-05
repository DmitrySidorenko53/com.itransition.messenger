using com.itransition.messenger.Models;
using com.itransition.messenger.Models.ViewModels;

namespace com.itransition.messenger.Services;

public interface IUserService
{
    User CreateIfNotExistByNickName(LoginViewModel model);
    User FindById(int id);
    List<User> GetUsers();
    User FindByName(string nickname);
    List<User> FindSenders(List<Message> messages);
}