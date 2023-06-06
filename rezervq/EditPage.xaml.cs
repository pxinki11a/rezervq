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
    /// Логика взаимодействия для EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        private cabinet _currentrezerv = new cabinet();
        public EditPage(cabinet selectedrezerv)
        {
            InitializeComponent();

            if (selectedrezerv != null)
                _currentrezerv = selectedrezerv;

            DataContext = _currentrezerv;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_currentrezerv.id == 0)
                errors.AppendLine("Укажите кабинет");
            if (_currentrezerv.id_fio == 0) ;
            errors.AppendLine("Укажите фио");
            if (_currentrezerv.srok == 0)
                errors.AppendLine("Укажите срок");
            if (_currentrezerv.id_spec == 0)
                errors.AppendLine("Укажите специальность");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentrezerv.id == 0)
                rezervEntities.GetContext().rezerv.Add(_currentrezerv);

            try
            {
                rezervEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        }
}
