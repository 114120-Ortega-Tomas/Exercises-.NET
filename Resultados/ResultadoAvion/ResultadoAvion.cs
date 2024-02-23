namespace Parcial3.Resultados.ResultadoAvion
{
    public class ResultadoAvion : ResultadoBae              
    {
        public List<ItemAvion> listAviones { get; set; }=new List<ItemAvion>();
    }
    public class ItemAvion
    {
        public int Id { get; set; }

        public int IdFabricante { get; set; }

        public int CantidadAsientos { get; set; }

        public string Modelo { get; set; } = null!;

        public int CantidadMotores { get; set; }

        public string? DatosVarios { get; set; }

        public string Fabricante { get; set; }
    }
}
