﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CelebritiesAPI.Responses
{
  public class ListModelResponse<TModel> : IListModelResponse<TModel>
  {
    public String Message { get; set; }

    public Boolean DidError { get; set; }

    public String ErrorMessage { get; set; }

    public IEnumerable<TModel> Model { get; set; }
  }
}
