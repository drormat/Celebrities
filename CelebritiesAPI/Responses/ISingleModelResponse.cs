﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CelebritiesAPI.Responses
{
  public interface ISingleModelResponse<TModel> : IResponse
  {
    TModel Model { get; set; }
  }
}
