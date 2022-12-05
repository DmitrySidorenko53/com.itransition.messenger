using System.ComponentModel.DataAnnotations;

namespace com.itransition.messenger.Models.ViewModels;

public class HomeViewModel
{
    public List<User> Senders { get; set; }
    public List<Message> Messages { get; set; } = null!;
    public PageViewModel PageViewModel { get; set; }
    public MessageViewModel MessageViewModel { get; set; } = null!;
}