using Application.DTOs._01_Common;
using Application.Enums;
using Microsoft.AspNetCore.Http;
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
                case ResultState.Success:
                case ResultState.Data:
                case ResultState.Updated:
                case ResultState.Deleted:
                    return new OkObjectResult(
                        new ApiResponse(true, appResp.Message, appResp.Data));

                case ResultState.Created:
                    return new CreatedResult(
                        url,
                        new ApiResponse(true, appResp.Message, appResp.Data));

                case ResultState.NotFound:
                    return new NotFoundObjectResult(
                        new ApiResponse(false, appResp.Message, null));

                case ResultState.Conflict:
                    return new ConflictObjectResult(
                        new ApiResponse(false, appResp.Message, null));

                case ResultState.BadRequest:
                    return new BadRequestObjectResult(
                        new ApiResponse(false, appResp.Message, null));

                case ResultState.NotCreated:
                case ResultState.NotUpdated:
                case ResultState.NotDeleted:
                    Log.Error($"Something went wrong... {appResp.Message}");
                    Log.CloseAndFlush();
                    return new ObjectResult(
                        new ApiResponse(false, appResp.Message, null))
                    {
                        StatusCode = 500
                    };

                default:
                    Log.Error($"Something went wrong... {appResp.Message}");
                    Log.CloseAndFlush();
                    return new ObjectResult(
                        // TODO: Los mensajes podria ser manejado con constantes 
                        // que estarian, por ej, en una clase "ApiConstants"
                        new ApiResponse(false, "Internal Server Error from ResultFactory", null))
                    {
                        StatusCode = 500
                    };
            }
        }
    }
}
