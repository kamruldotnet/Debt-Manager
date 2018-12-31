using DebtManager.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; 
using System.ComponentModel.DataAnnotations.Schema;


namespace DebtManager.Core.Entities
{
    public class TheirDebt : Entity
    {
        [Required]
        [ForeignKey("Id")]
        [Display(Name ="Contact Name")]
        public int debtId { get; set; }

        [Display(Name ="Amount")]
        public decimal Amount { get; set; }

        [Required]
        public string Currency { get; set; }

        [Display(Name="Date")]
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public bool Status { get; set; }

        [Display(Name ="Comment")]
        public string Comment { get; set; }
    }
}
