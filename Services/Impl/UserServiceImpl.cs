using com.itransition.messenger.Models;
using com.itransition.messenger.Models.Data;
using com.itransition.messenger.Models.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace com.itransition.messenger.Services.Impl;

public class UserServiceImpl : IUserService
{
    private readonly MessengerContext _context;

    public UserServiceImpl(MessengerContext context)
    {
        _context = context;
    }

    public User CreateIfNotExistByNickName(LoginViewModel model)
    {
        var user = _context.Users.FirstOrDefault(u => u.Nickname.Equals(model.Nickname));
        return user ?? CreateUserFromModel(model);
    }

    public User FindById(int id)
    {
        return _context.Users.FirstOrDefault(u => u.UserId == id)!;
    }

    public List<User> GetUsers()
    {
        return _context.Users.ToList();
    }

    public User FindByName(string nickname)
    {
        return _context.Users.FirstOrDefault(u => u.Nickname.Equals(nickname))!;
    }

    public List<User> FindSenders(List<Message> messages)
    {
        List<User> senders = new List<User>();
        foreach (var message in messages)
        {
            senders.Add(_context.Users.FirstOrDefault(u =>
                u.MessageToUsers!.Any(um => um.Status == Status.Sent && um.MessageId == message.MessageId))!);
        }

        return senders;
    }

    private User CreateUserFromModel(LoginViewModel model)
    {
        var user = new User
        {
            Nickname = model.Nickname
        };
        _context.Users.Add(user);
        _context.SaveChangesAsync();
        return user;
    }
}