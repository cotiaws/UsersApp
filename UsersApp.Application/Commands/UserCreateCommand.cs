using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApp.Application.Commands
{
    public class UserCreateCommand : IRequest<string>
    {
        [MinLength(8, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string? Name { get; set; }

        [EmailAddress(ErrorMessage = "Endereço de email inválido.")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string? Email { get; set; }

        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", 
            ErrorMessage = "Informe pelo menos uma letra minúscula, uma letra maiúscula, um número, um símbolo e 8 caracteres.")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "Senhas não conferem.")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string? PasswordConfirm { get; set; }
    }
}
