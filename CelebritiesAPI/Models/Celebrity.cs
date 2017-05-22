using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CelebritiesAPI.Core.EntityLayer
{
  public class Celebrity
  {
    public int? ID { get; set; }
    public String Name { get; set; }
    public int? Age {get;set;}
    public String Country { get; set; }
  }
}
