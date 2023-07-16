namespace Ecommerce.API.Errors
{
    public class HandlingException:ApiResponse
    {
        private int internalServerError;

        public string Details { get; set; }

        public HandlingException(int statusCode,string message,string details):base(statusCode,message)
        {
            Details = details;
        }

        public HandlingException(int statusCode):base(statusCode) 
        {
            
        }
    }
}
