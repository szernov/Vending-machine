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
    /// Логика взаимодействия для DeliteProductPage.xaml
    /// </summary>
    public partial class DeliteProductPage : Page
    {
        Logic log = new Logic();
        public DeliteProductPage()
        {
            InitializeComponent();
        }

        private void DeliteProductButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                log.DeliteProduct(DeliteProductBox.Text);
            }
            catch 
            {
                MessageBox.Show("Поле должно быть заполнено");
            }
        }
    }
}
