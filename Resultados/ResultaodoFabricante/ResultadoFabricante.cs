namespace Parcial3.Resultados.ResultaodoFabricante
{
    public class ResultadoFabricante : ResultadoBae
    {
        public List<ItemFabricante> itemFabricantes { get; set; } = new List<ItemFabricante>();
    }
    public class ItemFabricante
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;
    }
}
