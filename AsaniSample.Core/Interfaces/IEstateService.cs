using System;
using System.Collections.Generic;
using System.Text;
using AsaniSample.Core.DTOs;

namespace AsaniSample.Core.Interfaces
{
  public  interface IEstateService
  {

      IEnumerable<EstateDto> GetEstates();
  }
}
