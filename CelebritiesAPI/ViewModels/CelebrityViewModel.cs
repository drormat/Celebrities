using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CelebritiesAPI.ViewModels
{
  public class CelebrityViewModel
  {
    public int? ID { get; set; }

    public String CelebrityName { get; set; }

    public int? CelebrityAge { get; set; }

    public String CelebrityCountry { get; set; }
  }
}
