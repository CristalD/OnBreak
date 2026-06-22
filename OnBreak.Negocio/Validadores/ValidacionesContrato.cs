using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Negocio.Validadores
{
    public class ValidacionesContrato : AbstractValidator<Contrato>
    {
        public ValidacionesContrato()
        {
            RuleFor(c => c.Numero).NotEmpty().Must(ContratoValido).WithMessage("Debe esperar un minuto para crear un nuevo contrato.");
            RuleFor(c => c.RutCliente).NotEmpty().WithMessage("Debe ingresar Rut.")
                .Length(10, 10).WithMessage("El rut ingresado no es valido.")
                .Must(RutValido).WithMessage("El Rut ingresado no se encuentra registrado.");
            RuleFor(c => c.Asistentes).NotEmpty().WithMessage("La cantidad de asistentes debe ser mayor a 0.").InclusiveBetween(1, 300).WithMessage("El maximo de asistentes es de 300.");
            RuleFor(c => c.PersonalAdicional).Must(ValidarPersonal).WithMessage("Al solicitar personal adicional estos deben estar en un rango de 2 a 10.");
            RuleFor(c => c.FechaHoraInicio).Must(FechaInicialValida).WithMessage("La fecha de inicio no puede ser menor a la fecha actual.").LessThan(DateTime.Now.AddMonths(10)).WithMessage("La fecha maxima no debe superar los 10 meses");
            RuleFor(c => c.FechaHoraTermino).GreaterThan(c => c.FechaHoraInicio).WithMessage("La fecha de termino no puede ser menor a la fecha de inicio.")
                .LessThan(c => c.FechaHoraInicio.AddHours(24)).WithMessage("La fecha de termino no puede superar las 24 horas desde la fecha de inicio.");

        }

        protected bool ValidarPersonal(int personal)
        {
            if(personal <= 10 && personal >= 2 || personal == 0)
            {
                return true;
            }
            return false;
        }

        protected bool FechaInicialValida(DateTime fecha)
        {
            DateTime FechaActual = DateTime.Now;
            if(fecha > FechaActual)
            {
                return true;
            }
            return false;
        }

        protected bool RutValido(string rut)
        {
            Cliente cli = new Cliente()
            {
                RutCliente = rut
            };
            if (cli.Mostrar())
            {
                return true;
            }
            return false;
        }

        protected bool ContratoValido(string numero)
        {
            Contrato cont = new Contrato()
            {
                Numero = numero
            };
            if (cont.Leer())
            {
                return false;
            }
            return true;
        }
    }
}
