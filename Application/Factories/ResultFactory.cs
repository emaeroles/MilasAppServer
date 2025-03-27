using Application.DTOs._01_Common;
using Application.Enums;

namespace Application.Factories
{
    internal static class ResultFactory
    {
        public static AppResult CreateData(string message, object data)
        {
            return new AppResult(message, data, ResultState.Data);
        }

        public static AppResult CreateNotFound(string message)
        {
            return new AppResult(message, null, ResultState.NotFound);
        }

        public static AppResult CreateConflict(string message)
        {
            return new AppResult(message, null, ResultState.Conflict);
        }

        public static AppResult CreateCreated(string message, object? data)
        {
            return new AppResult(message, data, ResultState.Created);
        }

        public static AppResult CreateNotCreated(string message)
        {
            return new AppResult(message, null, ResultState.NotCreated);
        }

        public static AppResult CreateUpdated(string message)
        {
            return new AppResult(message, null, ResultState.Updated);
        }

        public static AppResult CreateNotUpdated(string message)
        {
            return new AppResult(message, null, ResultState.NotUpdated);
        }

        public static AppResult CreateDeleted(string message)
        {
            return new AppResult(message, null, ResultState.Deleted);
        }

        public static AppResult CreateNotDeleted(string message)
        {
            return new AppResult(message, null, ResultState.NotDeleted);
        }

        public static AppResult CreateAuthorized(string message, object data)
        {
            return new AppResult(message, data, ResultState.Authorized);
        }

        public static AppResult CreateUnauthorized(string message)
        {
            return new AppResult(message, null, ResultState.Unauthorized);
        }
    }
}
