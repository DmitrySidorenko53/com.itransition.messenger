using com.itransition.messenger.Models;
using com.itransition.messenger.Models.ViewModels;
using com.itransition.messenger.Services;
using Microsoft.AspNetCore.Mvc;

namespace com.itransition.messenger.Controllers;

public class MessengerController : Controller
{
    private readonly IMessageService _messageService;
    private readonly IUserService _userService;
    private readonly IMessageToUsersService _messageToUsersService;

    public MessengerController(IMessageService messageService, IUserService userService, 
        IMessageToUsersService messageToUsersService)
    {
        _messageService = messageService;
        _userService = userService;
        _messageToUsersService = messageToUsersService;
    }

    [HttpGet]
    public async Task<IActionResult> Home(string status)
    {
        var model = string.IsNullOrEmpty(status)
            ? CreateHomeViewModel(nameof(Status.Received))
            : CreateHomeViewModel(status);
        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> SendMessage(HomeViewModel model)
    { 
        var message = _messageService.CreateMessageFromModel(model.MessageViewModel);
        var chat = new Chat
        {
            Sender = _userService.FindById(
                Int32.Parse(HttpContext.Session.GetString("session_id")!)),
            Message = message,
            Recipient = _userService.FindByName(model.MessageViewModel.To)
        };
        _messageToUsersService.CreateChat(chat);
        return RedirectToAction("Home");
    }

    private HomeViewModel CreateHomeViewModel(string status, int page = 1)
    {
        int pageSize = 10;
        int currentUserId = Int32.Parse(HttpContext.Session.GetString("session_id")!);
        var currentUser = _userService.FindById(currentUserId);
        var messages = _messageService.GetMessagesByStatusAndUser(Enum.Parse<Status>(status), 
            currentUser);
        var items = messages.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        var pagesView = new PageViewModel(messages.Count, page, pageSize);
        HomeViewModel model = new HomeViewModel
        {
            Senders = _userService.FindSenders(items),
            PageViewModel = pagesView,
            Messages =  items,
            MessageViewModel = new MessageViewModel()
        };
        return model;
    }
}