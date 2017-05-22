﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CelebritiesAPI.Responses
{
  public interface IResponse
  {
    String Message { get; set; }

    Boolean DidError { get; set; }

    String ErrorMessage { get; set; }
  }
}
