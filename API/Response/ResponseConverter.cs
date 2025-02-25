using Application.DTOs._01_Common;
using Application.DTOs.Auth;
using Application.Enums;
using Microsoft.AspNetCore.Mvc;

namespace API.Response
{
    public static class ResponseConverter
    {
        // TODO: el data ese polifuncional no me gusta nada
        public static IActionResult Execute(AppResult appResp, string url = "")
        {
            switch (appResp.ResultState)
            {
                case ResultState.Success:
                    return new OkObjectResult(
                        new ApiResponse(true, appResp.Message, appResp.Data));

                case ResultState.Created:
                    return new CreatedResult(
                        url,
                        new ApiResponse(true, appResp.Message, null));

                case ResultState.NotFound:
                    return new NotFoundObjectResult(
                        new ApiResponse(false, appResp.Message, appResp.Data));

                case ResultState.Conflict:
                    return new ConflictObjectResult(
                        new ApiResponse(false, appResp.Message, appResp.Data));

                default:
                    return new ObjectResult(
                        // Los mensajes podria ser manejado con constantes 
                        // que estarian, por ej, en una clase "ApiConstants"
                        new ApiResponse(false, "Internal Server Error from ResultFactory", null))
                    {
                        StatusCode = 500
                    };
            }
        }
    }
}
