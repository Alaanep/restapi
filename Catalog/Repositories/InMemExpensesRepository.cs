using System.Collections.Generic;
using Catalog.Models;
using System.Linq;
using System;

namespace Catalog.Repositories
{

    public class InMemExpensesRepository : IExpensesRepository
    {
        private readonly List<Expense> expenses = new(){
            new Expense{
                Id=System.Guid.NewGuid(),
                Description="Alexela",
                Category="Transport",
                Amount=30,
                Date=System.DateTimeOffset.Now
            },
            new Expense{
                Id=System.Guid.NewGuid(),
                Description="Alexela",
                Category="Transport",
                Amount=40,
                Date=System.DateTimeOffset.Now
            },
            new Expense{
                Id=System.Guid.NewGuid(),
                Description="Alexela",
                Category="Transport",
                Amount=50,
                Date=System.DateTimeOffset.Now
            }
        };

        public IEnumerable<Expense> GetExpenses()
        {
            return expenses;
        }

        public Expense GetExpense(Guid id)
        {
            return expenses.Where(expense => expense.Id == id).SingleOrDefault();
        }

        public void CreatExpense(Expense expense)
        {
            expenses.Add(expense);
        }

        public void UpdateItem(Expense expense)
        {
            var index=expenses.FindIndex(existingExpense=>existingExpense.Id==expense.Id);
            expenses[index]=expense;
        }

        public void DeleteItem(Guid id)
        {
            var index=expenses.FindIndex(existingExpense=>existingExpense.Id==id);
            expenses.RemoveAt(index);
        }
    }
}
