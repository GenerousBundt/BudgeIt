using System;
namespace BudgeIt.Skateboard.Models
{
    public class BudgetEntry
    {
        public string Category { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; }
        public DateTime Created { get; set; }
        public BudgetAction Action { get; set; }

        public BudgetEntry(BudgetAction action)
        {
            Created = DateTime.Now;
            Action = action;
        }
    }
}
