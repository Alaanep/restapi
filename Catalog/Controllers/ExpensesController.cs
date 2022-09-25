using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Catalog.Repositories;
using Catalog.Models;
using Catalog.Dtos;

namespace Catalog.Controllers{
    [ApiController]
    [Route("expenses")]
    public class ExpensesController: ControllerBase{
        private readonly IExpensesRepository repository;
        public ExpensesController(IExpensesRepository repository){
            this.repository=repository;
        }
        [HttpGet]//get /expenses
        public ActionResult< IEnumerable<ExpenseDto>> GetExpenses(){
            var expenses=repository.GetExpenses().Select(expense=>expense.AsDto());
            return Ok(expenses);
        }
        [HttpGet("{id}")]//get /expense/{id}
        public ActionResult<ExpenseDto> GetExpense(Guid id){
            var expense=repository.GetExpense(id);

            if(expense is null){
                return NotFound();
            }
            return Ok(expense.AsDto());
        }
    }
}