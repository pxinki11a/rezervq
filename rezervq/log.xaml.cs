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
using System.Windows.Shapes;

namespace rezervq
{
    /// <summary>
    /// Логика взаимодействия для log.xaml
    /// </summary>
    public partial class log : Window
    {
        public log()
        {
            InitializeComponent();

            AppConnect.model0db = new UserEntities();
            AppFrame.frameMain = FrmMain;

            FrmMain.Navigate(new login());
        }
    }
}
