using System.ComponentModel.DataAnnotations;

namespace AiWebGymTracker.Models.DTO.AuthDTO;

public class RegisterUserDto
{
    [Required(ErrorMessage = "E-mail обязателен")]
    [EmailAddress(ErrorMessage = "Некорректный формат email")]
    public string Email { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Пароль обязателен")]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "Пароль должен быть не менее 8 символов")]
    public string Password { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Никнэйм обязателен")]
    public string Username { get; set; } = string.Empty;
}