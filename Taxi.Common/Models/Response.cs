namespace Taxi.Common.Models
{
    public class Response
    {
        //Esta clase es para saber si pudo o no pudo obtener resultados
        public bool IsSuccess { get; set; }//Si pudo o no pudo

        public string Message { get; set; }//Si no pudo devolver un mensaje 

        public object Result { get; set; }//Si pudo devuelve el resultado en un objeto object.
    }
}
