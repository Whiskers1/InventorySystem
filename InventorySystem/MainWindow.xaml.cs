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

namespace InventorySystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Item> items;
        public static Admin admin;

        public MainWindow()
        {
            InitializeComponent();
            items = new List<Item>();
            items.Add(new Item() { Id = 1, Name = "test", Amount = 1 });

            Page page = new MainPage();
            //Page page = new LoginPage();

            _mainFrame.Content = page;

        }


        /// <summary>
        /// 
        /// </summary>
        public class Log
        {
            public int Id { get; set; }

            public int ItemId { get; set; }

            public int UserId { get; set; }

            public int AdminId { get; set; }

            public DateTime DateTime { get; set; }


        }

        /// <summary>
        /// 
        /// </summary>
        public class Item
        {
            public int Id { get; set; }

            public int ItemId { get; set; }

            public string Name { get; set; }

            public int Amount { get; set; }

            public string Details
            {
                get
                {
                    return String.Format("Details for item nr: {0} - name: {1}.", this.Id, this.Name);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public class User
        {
            public int Id { get; set; }

            public string UniLog { get; set; }

            public string Name { get; set; }

            public string Email { get; set; }

            public int PhoneNr { get; set; }

            public string Code { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        public class Admin
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }
    }
}
