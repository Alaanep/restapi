using System.Collections.Generic;
using Catalog.Models;
using System;

namespace Catalog.Repositories{
    public interface IExpensesRepository{
        Expense GetExpense(Guid id);
        IEnumerable<Expense> GetExpenses();
    }
}
