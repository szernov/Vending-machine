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
    /// Логика взаимодействия для UpDatePage.xaml
    /// </summary>
    public partial class UpDatePage : Page
    {
        Logic log = new Logic();
        public UpDatePage()
        {
            InitializeComponent();
        }
        private void ElementTypeChangePage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ElementTypeChangePage.SelectedIndex == 0)
            {
                NameLabel.Visibility = Visibility.Visible;
                NameBox.Visibility = Visibility.Visible;
                ArticleBox.Visibility = Visibility.Visible;
                ArticleLabel.Visibility = Visibility.Visible;
                SellpriceBox.Visibility = Visibility.Visible;
                SellPriceLabel.Visibility = Visibility.Visible;
                BuyPriceBox.Visibility = Visibility.Visible;
                BuyPriceLabel.Visibility = Visibility.Visible;
                LocationBox.Visibility = Visibility.Collapsed;
                LocationLabel.Visibility = Visibility.Collapsed;
                IdComboBox.Visibility = Visibility.Collapsed;
                IdLabel.Visibility = Visibility.Collapsed;
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
                IdComboBox.Visibility = Visibility.Visible;
                IdLabel.Visibility = Visibility.Visible;

            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ElementTypeChangePage.SelectedIndex == 0)
                { log.UpdateProduct(ArticleBox.Text, NameBox.Text, int.Parse(SellpriceBox.Text), int.Parse(BuyPriceBox.Text)); }
            }
            catch 
            {
                {
                    MessageBox.Show("Все товары имеют артикул длинны 4,а все поля должны быть заполнены и иметь верный формат ");
                }
            }

        }
    }
}
