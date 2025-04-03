using Application.DTOs._01_Common;
using Application.Enums;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace API.Response
{
    public static class ResponseConverter
    {
        public static IActionResult Execute(AppResult appResp, string url = "")
        {
            switch (appResp.ResultState)
            {
                case ResultState.Data:
                case ResultState.Updated:
                case ResultState.Deleted:
                    return new OkObjectResult(
                        new ApiResponse(StatusCodes.Status200OK, appResp.Message, appResp.Data));

                case ResultState.Created:
                    return new CreatedResult(
                        url,
                        new ApiResponse(StatusCodes.Status201Created, appResp.Message, appResp.Data));

                case ResultState.NotFound:
                    return new NotFoundObjectResult(
                        new ApiResponse(StatusCodes.Status404NotFound, appResp.Message, null));

                case ResultState.Conflict:
                    return new ConflictObjectResult(
                        new ApiResponse(StatusCodes.Status409Conflict, appResp.Message, null));

                case ResultState.NotCreated:
                case ResultState.NotUpdated:
                case ResultState.NotDeleted:
                    Log.Error($"Something went wrong... {appResp.Message}");
                    Log.CloseAndFlush();
                    return new ObjectResult(
                        new ApiResponse(StatusCodes.Status500InternalServerError, appResp.Message, null))
                    {
                        StatusCode = StatusCodes.Status500InternalServerError
                    };

                default:
                    Log.Error($"Something went wrong... {appResp.Message}");
                    Log.CloseAndFlush();
                    return new ObjectResult(
                        new ApiResponse(StatusCodes.Status500InternalServerError, 
                            "Internal Server Error from ResultFactory", null))
                    {
                        StatusCode = StatusCodes.Status500InternalServerError
                    };
            }
        }
    }
}
