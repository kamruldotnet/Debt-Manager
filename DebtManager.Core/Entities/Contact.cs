using DebtManager.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DebtManager.Core.Entities
{
    public class Contact : Entity
    {
        [Required]
        [Display(Name="Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name="Phone Number")]
        public string Phone { get; set; }

        [Display(Name="Email Address")]
        public string Email { get; set; }

        [Display(Name="Address")]
        public string Address { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime CreateAt { get; set; }

        [DataType(DataType.Date)]
        public DateTime UpdateAt { get; set; }
        public bool Status { get; set; }
    }
}
