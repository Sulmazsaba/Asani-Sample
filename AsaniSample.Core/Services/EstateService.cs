using System;
using System.Collections.Generic;
using System.Text;
using AsaniSample.Core.DTOs;
using AsaniSample.Core.Interfaces;

namespace AsaniSample.Core.Services
{
  public class EstateService :IEstateService
    {
         //IUnitOfWork
        public IEnumerable<EstateDto> GetEstates()
        {
            throw new NotImplementedException();
        }
    }
}
