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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        Product product;
        public AddEditPage(Product _product)
        {
            InitializeComponent();
           product = _product;
            this.DataContext = product;
            cmbType.ItemsSource= DB.decorEntities.TypeProd.ToList();
            cmbType.DisplayMemberPath = "Name";
            App.mainWindow.txbMain.Text = "ДОБАВЛЕНИЕ/РЕДАКТИРОВАНИЕ";

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                if (product.Id == 0)
                {
                    product.IdType = (cmbType.SelectedItem as TypeProd).ID;
                    DB.decorEntities.Product.Add(product);
                }
                DB.decorEntities.SaveChanges();
                MessageBox.Show("СОХРАНЕНО", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new ToDoList());
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnOtm_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ToDoList());
        }
    }
}
