using Ekz.Conn;
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

namespace Ekz.Pages
{
    /// <summary>
    /// Логика взаимодействия для ToDoList.xaml
    /// </summary>
    public partial class ToDoList : Page
    {
        public ToDoList()
        {
            InitializeComponent();
            App.mainWindow.txbMain.Text = "СПИСОК";
            lstData.ItemsSource= DB.decorEntities.Product.ToList(); 
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditPage(new Product()));
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var select = lstData.SelectedItem as Product;
                if ( select!= null)
                {
                    NavigationService.Navigate(new AddEditPage(select));
                }
                else MessageBox.Show("Выберите запись для изменения","Уведомление",MessageBoxButton.OK,MessageBoxImage.Information);
            }
            catch(Exception ex) {MessageBox.Show(ex.Message); }
        }

        private void lstData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select= lstData.SelectedItem as Product;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            lstData.ItemsSource = DB.decorEntities.Product.ToList();
        }
    }
}
