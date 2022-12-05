using System.ComponentModel.DataAnnotations;

namespace com.itransition.messenger.Models.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "Nickname is required")]
    [Display(Name = "Nickname")]
    [DataType(DataType.Text)]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Input length should be 3-50 symbols")]
    public string Nickname { get; set; }
}