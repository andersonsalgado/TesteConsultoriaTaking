using System.ComponentModel.DataAnnotations;

namespace TesteConsultoriaTaking.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Informe o nome completo")]
        [Display(Name = "Nome completo")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Informe o e-mail")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [StringLength(100, ErrorMessage = "A {0} deve ter ao menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirme a senha")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "As senhas não coincidem.")]
        [Display(Name = "Confirmar senha")]
        public string ConfirmPassword { get; set; }

        public string ReturnUrl { get; set; }
    }
}
