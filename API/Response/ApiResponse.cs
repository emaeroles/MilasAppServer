namespace API.Response
{
    public class ApiResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public object? Data { get; set; } = null;

        public ApiResponse(bool isSucced, string message, object? data)
        {
            IsSuccess = isSucced;
            Message = message;
            Data = data;
        }
    }
}
