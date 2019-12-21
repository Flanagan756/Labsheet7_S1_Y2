using System;
using System.Collections.Generic;
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

namespace Wpf_Labsheet7_Q2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Members> members;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        int totalMembers = 2;
        //The method will run when the window loads - on startup
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Display the intial nmumber of memebers
            Number_of_Members.Text = totalMembers.ToString();

            //Adds member types to combo-box on window startup
            tbxMemberType.Items.Add("Full");
            tbxMemberType.Items.Add("Off Peak");
            tbxMemberType.Items.Add("Student");
            tbxMemberType.Items.Add("OAP");

            //Create 2 Members
            Members m1 = new Members()
            {
                Name = "Tom Jones",
                MemberType = "Full",
                Joined = new DateTime(2015, 01, 23)
            };
           
            Members m2 = new Members()
            {
                Name = "Mary Smith",
                MemberType = "Student",
                Joined = new DateTime(2013, 06, 01)
            };
            //Add them to a list
            members = new List<Members>(); //A new lsit assigned on window load
            members.Add(m1);
            members.Add(m2);

            //Display list in listbox
            lbxMembers.ItemsSource = members;

        }
        //Generates a random date time
        private Random gen = new Random();
        DateTime RandomDay()
        {
            DateTime start = new DateTime(2010, 1, 1);
            int range = (new DateTime(2015,1,1)- start).Days;
            return start.AddDays(gen.Next(range));
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //create a memebr
            Members m1 = new Members()
            {
                Name = txbName.Text,
                MemberType = tbxMemberType.Text,
                Joined = RandomDay()

            };

            //Add to list
            
               members.Add(m1);

            //Count Members and add to total
            totalMembers++;
            Number_of_Members.Text = totalMembers.ToString();

            //Refresh Screen
            lbxMembers.ItemsSource = null;
            lbxMembers.ItemsSource = members;
            
        }
    } 
}
       

