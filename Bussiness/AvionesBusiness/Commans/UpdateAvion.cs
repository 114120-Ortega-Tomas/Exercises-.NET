using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Parcial3.Data;
using Parcial3.Resultados.ResultadoAvion;

namespace Parcial3.Bussiness.AvionesBusiness.Commans
{
    public class UpdateAvion
    {
        public class Put : IRequest<ResultadoAvion>
        {
            public int Id { get; set; }

            public int IdFabricante { get; set; }

            public int CantidadAsientos { get; set; }

            public string Modelo { get; set; } = null!;

            public int CantidadMotores { get; set; }

            public string? DatosVarios { get; set; }
        }
        public class Validator : AbstractValidator<Put>
        {
            public Validator()
            {
                RuleFor(x => x.Id).NotEmpty();
                RuleFor(x => x.IdFabricante).NotEmpty();
                RuleFor(x => x.CantidadAsientos).NotEmpty();
                RuleFor(x => x.CantidadMotores).NotEmpty();
                RuleFor(x => x.Modelo).NotEmpty();
                RuleFor(x => x.DatosVarios).NotEmpty();

            }
        }

        public class Manejador : IRequestHandler<Put, ResultadoAvion>
        {
            private readonly ContextDB _context;
            private readonly Validator _validator;
            public Manejador(ContextDB context, Validator validator)
            {
                _context = context;
                _validator = validator;
            }

            public async Task<ResultadoAvion> Handle(Put request, CancellationToken cancellationToken)
            {
                var validacion = _validator.Validate(request);
                var resultado = new ResultadoAvion();
                var avion = await _context.Aviones.Include(x => x.IdFabricanteNavigation).FirstOrDefaultAsync(x => x.Id == request.Id);

                if (!validacion.IsValid)
                {
                    resultado.Respuesta("debe ingresar bien los datos", System.Net.HttpStatusCode.BadRequest);
                    return resultado;
                }

                if (avion == null)
                {
                    resultado.Respuesta("debe ingresar bien los datos", System.Net.HttpStatusCode.BadRequest);
                    return resultado;
                }
                avion.IdFabricante = request.IdFabricante;
                avion.Modelo = request.Modelo;
                avion.CantidadAsientos = request.CantidadAsientos;
                avion.CantidadMotores = request.CantidadMotores;
                avion.DatosVarios = request.DatosVarios;
                
                _context.Update(avion);
                await _context.SaveChangesAsync();
                await _context.Entry(avion).Reference(x => x.IdFabricanteNavigation).LoadAsync();

                var itemavion = new ItemAvion()
                {
                    Id = avion.Id,
                    Modelo = avion.Modelo,
                    IdFabricante = avion.IdFabricante,
                    CantidadMotores = avion.CantidadMotores,
                    CantidadAsientos = avion.CantidadAsientos,
                    DatosVarios = avion.DatosVarios,
                    Fabricante = avion.IdFabricanteNavigation.Nombre

                };
                resultado.listAviones.Add(itemavion);
                return resultado;
            }
        }
    }
}
