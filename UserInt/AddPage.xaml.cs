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
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        Logic log = new Logic();
        public AddPage()
        {

            InitializeComponent();
        }
        private void ElementTypeChangePage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ElementTypeChangePage.SelectedIndex == 0)
            {
                NameBox.Visibility = Visibility.Visible;
                ArticleBox.Visibility = Visibility.Visible;
                ArticleLabel.Visibility = Visibility.Visible;
                SellpriceBox.Visibility = Visibility.Visible;
                SellPriceLabel.Visibility = Visibility.Visible;
                BuyPriceBox.Visibility = Visibility.Visible;
                BuyPriceLabel.Visibility = Visibility.Visible;
                LocationBox.Visibility = Visibility.Collapsed;
                LocationLabel.Visibility = Visibility.Collapsed;

            }
            else
            {
                NameLabel.Visibility = Visibility.Collapsed;
                NameBox.Visibility = Visibility.Collapsed;
                ArticleBox.Visibility = Visibility.Collapsed; ;
                ArticleLabel.Visibility = Visibility.Collapsed;
                SellpriceBox.Visibility = Visibility.Collapsed;
                SellPriceLabel.Visibility = Visibility.Collapsed; ;
                BuyPriceBox.Visibility = Visibility.Collapsed; ;
                BuyPriceLabel.Visibility = Visibility.Collapsed;
                LocationBox.Visibility = Visibility.Visible;
                LocationLabel.Visibility = Visibility.Visible;

            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ElementTypeChangePage.SelectedIndex == 0)
                {
                    log.AddProduct(ArticleBox.Text, NameBox.Text, int.Parse(SellpriceBox.Text), int.Parse(BuyPriceBox.Text));
                }
                else
                { log.AddVm(LocationBox.Text); }
            }
            catch 
            {
                MessageBox.Show("Для добавления товара артикул товара должен иметь длинну 4,а все поля должны быть заполнены и иметь верный формат ");
            }
        }
    }
}
