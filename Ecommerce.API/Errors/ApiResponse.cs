namespace Ecommerce.API.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public ApiResponse(int statusCod,string message = null)
        {
            StatusCode = statusCod;
            Message = message ?? GetDefultMessageForStatusCode(statusCod);
        }
       private string GetDefultMessageForStatusCode(int statusCod)
        {
            return statusCod switch
            {
                400 => "A bad request,you have made",
                401 =>"Authorized you are not",
                404 =>"Response found it is not",
                500 =>"server error",
                _ =>null
            } ;
        }
    }
}
