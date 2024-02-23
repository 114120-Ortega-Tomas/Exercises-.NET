using MediatR;
using Microsoft.EntityFrameworkCore;
using Parcial3.Data;
using Parcial3.Resultados.ResultadoAvion;

namespace Parcial3.Bussiness.AvionesBusiness.Querys
{
    public class Get
    {
        public class GetAviones : IRequest<ResultadoAvion>
        {
        }

        public class Manejador : IRequestHandler<GetAviones, ResultadoAvion>
        {
            private readonly ContextDB _context;
            public Manejador(ContextDB context)
            {
                _context = context;
            }

            public async Task<ResultadoAvion> Handle(GetAviones request, CancellationToken cancellationToken)
            {
                var resultadoAvion = new ResultadoAvion();
                var aviones = await  _context.Aviones.Include(x => x.IdFabricanteNavigation).ToArrayAsync();
                if(aviones==null)
                {
                    resultadoAvion.Respuesta("No se encuentran aviones en la BD",System.Net.HttpStatusCode.NotFound);
                    return resultadoAvion;
                }
                foreach (var item in aviones)
                {
                    var itemA = new ItemAvion()
                    {
                        Id = item.Id,
                        Modelo = item.Modelo,
                        CantidadAsientos = item.CantidadAsientos,
                        CantidadMotores = item.CantidadMotores,
                        DatosVarios = item.DatosVarios,
                        IdFabricante = item.IdFabricante,
                        Fabricante = item.IdFabricanteNavigation.Nombre
                    };
                    resultadoAvion.listAviones.Add(itemA);

                }

                return resultadoAvion;
                
            }
        }
    }
}
