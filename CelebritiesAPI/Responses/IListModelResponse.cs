using System;
using System.Collections.Generic;

namespace CelebritiesAPI.Responses
{
    public interface IListModelResponse<TModel> : IResponse
    {
      IEnumerable<TModel> Model { get; set; }
    }
}
