using System.ComponentModel.DataAnnotations;

namespace BlueBlotRecords.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Логин не указан")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Пароль не уазан")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
