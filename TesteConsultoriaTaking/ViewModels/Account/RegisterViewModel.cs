using System.ComponentModel.DataAnnotations;

namespace TesteConsultoriaTaking.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Informe o nome completo.")]
        [Display(Name = "Nome completo")]
        [StringLength(180)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Informe o e-mail.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha.")]
        [StringLength(100, ErrorMessage = "A senha deve ter ao menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirme a senha.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "As senhas não conferem.")]
        [Display(Name = "Confirmar senha")]
        public string ConfirmPassword { get; set; }
    }
}
