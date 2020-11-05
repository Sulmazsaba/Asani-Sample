using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;

namespace AsaniSample.Models
{
   public class Estate
    {
        public Guid Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }

        public int Area { get; set; }
        public StatementType Type { get; set; }
        public string Address { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
