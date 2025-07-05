namespace Domain.ErrorModel
{
    public class ErrorDetail
    {   
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public string? Details { get; set; }
        
        public ErrorDetail(string message, int statusCode , string? details)
        {
            Message = message;
            StatusCode = statusCode;
            Details = details;
        }
        
       
    }
}

