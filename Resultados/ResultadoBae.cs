using System.Net;

namespace Parcial3.Resultados
{
    public class ResultadoBae
    {
        public bool OK { get; set; } = true;
        public string msj { get; set; } = "";
        public HttpStatusCode status { get; set; }=HttpStatusCode.OK;

        public void Respuesta( string mensaje , HttpStatusCode code)
        {
            OK = false;
            msj = mensaje;
            status = code;
        }
    }
}
