using System;
using System.Collections.Generic;
using System.Text;
using AsaniSample.Core.Entities.Enums;

namespace AsaniSample.Core.DTOs
{
   public class EstateForCreationDto
    {
        public string Name { get; set; }
        public int Area { get; set; }
        public EstateType Type { get; set; }
        public string Address { get; set; }
        public Guid OwnerId { get; set; }
    }
}
