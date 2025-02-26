using Application.DTOs._01_Common;
using Application.Enums;

namespace Application.Factories
{
    internal static class ResultFactory
    {
        public static AppResult CreateSuccess(string message, object? data)
        {
            return new AppResult(message, data, ResultState.Success);
        }

        public static AppResult CreateCreated(string message, object data)
        {
            return new AppResult(message, data, ResultState.Created);
        }

        public static AppResult CreateNotFound(string message)
        {
            return new AppResult(message, null, ResultState.NotFound);
        }

        public static AppResult CreateConflict(string message)
        {
            return new AppResult(message, null, ResultState.Conflict);
        }

        public static AppResult CreateAuthorized(string message)
        {
            return new AppResult(message, null, ResultState.Authorized);
        }

        public static AppResult CreateUnauthorized(string message)
        {
            return new AppResult(message, null, ResultState.Unauthorized);
        }
    }
}
