using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Labsheet7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Links the list to expenses within the Toal_Loaded
        //Right click the lightbulb and select  first to get ObervableCollection working
        //Has an auto refresh built in
        ObservableCollection<Expense> expenses;
        Random rng = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }
        //This Method will run in the window loads
        private void Total_Loaded(object sender, RoutedEventArgs e)
        {
            //Create 3 Expense objects
            Expense expense1 = new Expense()
            {
                Category = "Travel",
                Ammount = 19.95m,
                ExpenseDate = new DateTime(2019, 06, 30)
            };
            Expense expense2 = new Expense()
            {
                Category = "Entertainment",
                Ammount = 99.95m,
                ExpenseDate = new DateTime(2019, 07, 30)
            };
            Expense expense3 = new Expense()
            {
                Category = "Office",
                Ammount = 9.95m,
                ExpenseDate = new DateTime(2019, 6, 25)
            };

            //Add those to a list
            expenses = new ObservableCollection<Expense>();
            expenses.Add(expense1);
            expenses.Add(expense2);
            expenses.Add(expense3);

            //Display lists in box
            list1.ItemsSource = expenses;

            Total.Text = Expense.TotalExpenses.ToString();
        }
        //Method to add expense
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Create an expense
            //Expense e1 = new Expense()
            //{
            //    Category = "Travel",
            //    Ammount = 55.45m,
            //    ExpenseDate = DateTime.Now
            //};
            //Add that to the list
            expenses.Add(GetRandomExpense());

            Total.Text = Expense.TotalExpenses.ToString();
            //Refresh Screen
            //list1.ItemsSource = null;
            //list1.ItemsSource = expenses;
            //DON'T NEED THIS IF OBSERVABLE COLLECTION WORKS AND REPLACES LIST//

        }
        private Expense GetRandomExpense()
        {
            //get random category
            string[] categories = { "Office", "Travel", "Entertainment" };
            int randomNumber = rng.Next(0, 3);
           string category = categories[randomNumber];
            //get random ammount
            randomNumber = rng.Next(1, 10001);
            decimal randomAmount = (decimal)randomNumber / 100;

            //get random date - in the last 30 days
            randomNumber = rng.Next(0, 31); //0 - 30
            DateTime randomDate = DateTime.Now.AddDays(-randomNumber);
            //create an expense object with above infomatin
            Expense e1 = new Expense(randomAmount, randomDate, category);
            //return random object
            return e1;
        }
    }
}
