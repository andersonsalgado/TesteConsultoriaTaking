using System.ComponentModel.DataAnnotations;

namespace TesteConsultoriaTaking.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o e-mail ou usuário.")]
        [Display(Name = "E-mail ou usuário")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Informe a senha.")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Lembrar-me")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
