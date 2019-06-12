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
using ClassLibrary1;

namespace UserInt
{
    /// <summary>
    /// Логика взаимодействия для DeliteVmPage.xaml
    /// </summary>
    public partial class DeliteVmPage : Page
    {
        Logic log = new Logic();
        public DeliteVmPage()
        {
            InitializeComponent();
        }

        private void DeliteVmButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                log.DeliteVm(DeliteVmBox.Text);
            }
            catch 
            {
                { MessageBox.Show("Поле должно быть заполнено"); }
            }
        }
    }
}
