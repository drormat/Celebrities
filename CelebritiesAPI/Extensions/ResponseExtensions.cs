﻿using System;
using System.Net;
using CelebritiesAPI.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CelebritiesAPI.Extensions
{
    public static class ResponseExtensions
    {
      public static IActionResult ToHttpResponse<TModel>(this IListModelResponse<TModel> response)
      {
        var status = HttpStatusCode.OK;

        if (response.DidError)
        {
          status = HttpStatusCode.InternalServerError;
        }
        else if (response.Model == null)
        {
          status = HttpStatusCode.NoContent;
        }

        return new ObjectResult(response) { StatusCode = (int)status };
      }

      public static IActionResult ToHttpResponse<TModel>(this ISingleModelResponse<TModel> response)
      {
        var status = HttpStatusCode.OK;

        if (response.DidError)
        {
          status = HttpStatusCode.InternalServerError;
        }
        else if (response.Model == null)
        {
          status = HttpStatusCode.NotFound;
        }

        return new ObjectResult(response) { StatusCode = (int)status };
      }
  }
}
