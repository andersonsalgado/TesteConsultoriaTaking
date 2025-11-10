using System.ComponentModel.DataAnnotations;

namespace TesteConsultoriaTaking.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o e-mail")] 
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Manter conectado")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
