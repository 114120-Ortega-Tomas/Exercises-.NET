using MediatR;
using Microsoft.EntityFrameworkCore;
using Parcial3.Data;
using Parcial3.Resultados.ResultaodoFabricante;

namespace Parcial3.Bussiness.FabricanteBusinnes.Querues
{
    public class GetFabricantes
    {
        public class Get :IRequest<ResultadoFabricante>
        {

        }
        public class Manejador : IRequestHandler<Get, ResultadoFabricante>
        {
            private readonly ContextDB _context;
            public Manejador(ContextDB context)
            {
                _context = context;
            }

            public async Task<ResultadoFabricante> Handle(Get request, CancellationToken cancellationToken)
            {
                var resultado = new ResultadoFabricante();
                var Fabricntes = await _context.Fabricantes.ToArrayAsync();

                foreach (var item in Fabricntes)
                {
                    var fabri = new ItemFabricante()
                    {
                        Id = item.Id,
                        Nombre = item.Nombre
                    };
                    resultado.itemFabricantes.Add(fabri);
                }
                return resultado;
            }
        }
    }
}
