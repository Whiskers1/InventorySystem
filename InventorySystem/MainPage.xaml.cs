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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {

        public MainPage()
        {
            InitializeComponent();
            
            //dgItems.ItemsSource = MainWindow.items;
        }

       

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           // var filtered = MainWindow.items.Where(items => items.Name.StartsWith(Search_Text_Items.Text));
            //var filtered = items.Where(items => items.Name.StartsWith(Search_Text_Items.Text) || items.Id.ToString() == Search_Text_Items.Text);

            //dgItems.ItemsSource = filtered;
        }
    }
}
