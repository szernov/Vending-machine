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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Context database = new Context();
        public MainWindow()
        {
            InitializeComponent();
            var a = database.product.ToList();
            Logic log = new Logic();




        }

       

 
        private void ChangePageButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            string data = button.Tag.ToString();

            switch (int.Parse(data))
            {

                case 1:
                    Main.Content = new VmPage();


                    break;
                case 2:
                    Main.Content = new ProductPAge();
                    break;
                case 3:
                    Main.Content = new AddPage();
                    break;

                case 4:
                    Main.Content = new DeliteProductPage();
                    break;
                case 5:
                    Main.Content = new DeliteVmPage();
                    break;
                case 6:
                    Main.Content = new UpDatePage();
                    break;
                case 7:
                    Main.Content = new CommandPage();
                    break;


            }
        }
    }
}
