using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AsaniSample.Models
{
   public class Owner
    {
        public Guid Id { get; set; }

        [MaxLength(200)]
        [Required]
        public string FirstName { get; set; }
        
        [MaxLength(200)]
        [Required]
        public string LastName { get; set; }

        
        [MaxLength(20)]
        [Required]
        public string Phone { get; set; }



    }
}
