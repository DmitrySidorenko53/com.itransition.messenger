using System.ComponentModel.DataAnnotations;

namespace com.itransition.messenger.Models.ViewModels;

public class MessageViewModel
{
    [Required(ErrorMessage = "Required field")]
    public string To { get; set; } = null!;
    [Required(ErrorMessage = "Required field")]
    [DataType(DataType.Text)]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Should be 3-50 symbols in size")]
    public string Subject { get; set; } = null!;
    [Required(ErrorMessage = "Required field")]
    [DataType(DataType.Text)]
    [StringLength(500, MinimumLength = 3, ErrorMessage = "Should be 3-500 symbols in size")]
    public string Text { get; set; } = null!;
}