using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApp.Application.Commands
{
    public class UserAuthCommand : IRequest<string>
    {
        [EmailAddress(ErrorMessage = "Endereço de email inválido.")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string? Email { get; set; }

        [MinLength(8, ErrorMessage = "Informe pelo menos {1} caracteres.")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string? Password { get; set; }
    }
}
