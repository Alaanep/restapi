using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Dtos;
using Catalog.Models; 

namespace Catalog{
    public static class Extensions{
        public static ExpenseDto AsDto(this Expense expense){
            return new  ExpenseDto{
                Id=expense.Id,
                Description=expense.Description,
                Category=expense.Category,
                Amount=expense.Amount,
                Date=expense.Date
            };
        }
    }
}