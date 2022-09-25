using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
    public record CreateExpenseDto{
        [Required]public string Description { get; init;}
        [Required]public string Category {get; init;}
        [Required]public decimal Amount { get; init;}
        [Required]public DateTimeOffset Date { get; init;}
    }
}