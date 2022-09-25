using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Catalog.Repositories;
using Catalog.Models;

namespace Catalog.Controllers{
    [ApiController]
    [Route("expenses")]
    public class ExpensesController: ControllerBase{
        private readonly InMemExpensesRepository repository;
        public ExpensesController(){
            repository=new InMemExpensesRepository();
        }
        [HttpGet]//get /expenses
        public ActionResult< IEnumerable<Expense>> GetExpenses(){
            var expenses=repository.GetExpenses();
            return Ok(expenses);
        }
        [HttpGet("{id}")]//get /expense/{id}
        public ActionResult<Expense> GetExpense(Guid id){
            var expense=repository.GetExpense(id);

            if(expense is null){
                return NotFound();
            }
            return Ok(expense);
        }
    }
}