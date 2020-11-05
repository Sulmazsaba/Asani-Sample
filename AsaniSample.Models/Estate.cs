using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text;

namespace AsaniSample.Models
{
   public class Estate
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }

        public int Area { get; set; }
        public StatementType Type { get; set; }
        public string Address { get; set; }
        public bool IsDeleted { get; set; } = false;

        //foreign key
        public Guid OwnerId { get; set; }

        //navigational properties
        [ForeignKey("OwnerId")]
        public Owner Owner { get; set; }

    }
}
