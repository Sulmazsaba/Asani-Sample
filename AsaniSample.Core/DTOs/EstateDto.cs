using System;
using System.Collections.Generic;
using System.Text;

namespace AsaniSample.Core.DTOs
{
  public  class EstateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Area { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public string OwnerName { get; set; }
        public string OwnerPhone { get; set; }
    }
}
