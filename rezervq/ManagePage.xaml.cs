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

namespace rezervq
{
    /// <summary>
    /// Логика взаимодействия для ManagePage.xaml
    /// </summary>
    public partial class ManagePage : Page
    {
        public ManagePage()
        {
            InitializeComponent();
        }

        private void Updatecabinet()
        {
            var currentcabinet = rezervEntities.GetContext().cabinet.ToList();

            currentcabinet = currentcabinet.Where(p => p.nomercab.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            DGridRez.ItemsSource = currentcabinet;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MaimFrame.Navigate(new EditPage(null));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MaimFrame.Navigate(new EditPage((sender as Button).DataContext as cabinet));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MaimFrame.Navigate(new EditPage(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var productForRemoving = DGridRez.SelectedItems.Cast<cabinet>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {productForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    rezervEntities.GetContext().Cars.RemoveRange(productForRemoving);
                    rezervEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridRez.ItemsSource = rezervEntities.GetContext().Cars.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                rezervEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridRez.ItemsSource = rezervEntities.GetContext().Cars.ToList();
            }
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Updatecabinet();
        }

    }
}
