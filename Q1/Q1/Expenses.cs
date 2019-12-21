using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Labsheet7
{
    class Expense
    {
        //Properties
        private decimal ammount;

        public decimal Ammount
        {
            get { return ammount; }
            set
            {
                TotalExpenses += value;

                ammount = value;
            }
        }

        public DateTime ExpenseDate { get; set; }

        public string Category { get; set; }

        public static decimal TotalExpenses;

        //Constructors - will return later
        public Expense() : this (0, DateTime.Now,"Unkown")
        {

        }
        public Expense(decimal ammount, DateTime date, string category)
        {
            Ammount = ammount;
            ExpenseDate = date;
            Category = category;
        }
        //Methods
        public override string ToString()
        {
            return $"{Category} {Ammount:c} on {ExpenseDate.ToShortDateString()}";
        }
    }
}
