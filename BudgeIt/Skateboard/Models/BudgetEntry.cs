using System;
using System.Collections.Generic;

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
        public static List<BudgetEntry> Ledger()
        {
            List<BudgetEntry> list = new List<BudgetEntry>();

            for(var i = 0; i<100; i++)
            {
                list.Add(GetRandomEntry());
            }
            return list;
        }
        private static BudgetEntry GetRandomEntry()
        {
            var notes = new[] {
                "One way",
                "or another",
                "I'm gonna find you",
                "I'm gonna getchu",
                "Here's a note"};

            var gen = new Random();
            var cats = new Categories().CategoryList;

            var thisCat = cats[gen.Next(0, cats.Count)];
            var thisAmt = (decimal)gen.Next(0, 100);
            var thisNote = notes[gen.Next(0, notes.Length)];
            var thisAction = gen.Next(0, 100) < 20 ? BudgetAction.Deposit : BudgetAction.Withdrawal;

            return new BudgetEntry(thisAction)
            {
                Category = thisCat,
                Amount = thisAmt,
                Note = thisNote
            };
        }
    }
}
