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
using System.Data.SqlClient;

namespace UserInt
{
    /// <summary>
    /// Логика взаимодействия для ProductPAge.xaml
    /// </summary>
    public partial class ProductPAge : Page
    {
        Context database = new Context();

        public ProductPAge()
        {
            try
            {


                InitializeComponent();
                List<Product> pr = database.product.ToList();
                ProductListView.ItemsSource = pr;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());

            }


        }

        
    }
}