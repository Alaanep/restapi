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
        [HttpPost]//post /expenses
        public ActionResult<ExpenseDto>CreateExpense(CreateExpenseDto expenseDto){
            Expense expense = new (){
                Id=Guid.NewGuid(),
                Description=expenseDto.Description,
                Category=expenseDto.Category,
                Amount=expenseDto.Amount,
                Date=expenseDto.Date
            };
            repository.CreatExpense(expense);
            return CreatedAtAction(nameof(GetExpense), new{id=expense.Id}, expense.AsDto());
        }

        [HttpPut("{id}")] //put /expenses/{id}
        public ActionResult UpdateExpense(Guid id,UpdateExpenseDto expenseDto){
            var existingExpense = repository.GetExpense(id);
            if(existingExpense is null){
                return NotFound();
            }
            Expense updatedExpense = existingExpense with {
                Description=expenseDto.Description,
                Category=expenseDto.Category,
                Amount=expenseDto.Amount,
                Date=expenseDto.Date
            };
            repository.UpdateItem(updatedExpense);
            return NoContent();
        }

        [HttpDelete("{id}")] //delete /expenses/{id}
        public ActionResult DeleteExpense(Guid id){
            var existingExpense = repository.GetExpense(id);
            if(existingExpense is null){
                return NotFound();
            }
            repository.DeleteItem(id);
            return NoContent();
        }

    }
}