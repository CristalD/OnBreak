using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Negocio.Validadores
{
    public class ValidadorCliente : AbstractValidator<Cliente>
    {
        public ValidadorCliente()
        {
            RuleFor(c => c.RutCliente).NotEmpty().WithMessage("Debe ingresar Rut.").Length(10,10).WithMessage("El rut ingresado no es valido.");
            RuleFor(c => c.RazonSocial).NotEmpty().WithMessage("Debe ingresar razon social.");
            RuleFor(c => c.NombreContacto).NotEmpty().WithMessage("Debe ingresar un nombre.");
            RuleFor(c => c.MailContacto).NotEmpty().WithMessage("Debe ingresar un correo.");
            RuleFor(c => c.Direccion).NotEmpty().WithMessage("Debe ingresar una direccion.");
            RuleFor(c => c.Telefono).NotEmpty().WithMessage("Debe ingresar un telefono.");
        }
    }
}
