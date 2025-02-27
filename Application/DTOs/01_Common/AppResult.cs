using Application.Enums;

namespace Application.DTOs._01_Common
{
    public class AppResult
    {
        public ResultState ResultState { get; set; }
        public string? Message { get; set; } = string.Empty;
        public object? Data { get; set; }

        public AppResult(string? message, object? data, ResultState resultState)
        {
            ResultState = resultState;
            Message = message;
            Data = data;
        }
    }
}
