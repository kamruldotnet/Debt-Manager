using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DebtManager.Core.SharedKernel
{
    public class Entity
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
    }
}
