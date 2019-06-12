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
    /// Логика взаимодействия для CommandPage.xaml
    /// </summary>
    public partial class CommandPage : Page
    {
        Logic log = new Logic();
        public CommandPage()
        {
            InitializeComponent();
        }

        private void IncomeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                log.Income(IncomeListView, IncomeMounthTextBox.Text, IncomeYearTextBox.Text);
                IncomeGrid.Visibility = Visibility.Visible;
                LeastSoldGrid.Visibility = Visibility.Collapsed;
                MissGrid.Visibility = Visibility.Collapsed;
            }
            catch { MessageBox.Show("Нет необходимых элемениов"); }

        }

        private void LeastSoldButton_Click(object sender, RoutedEventArgs e)
        {
                log.LeastSold(LeastSoldListView, LeastSoldMounthTextBox.Text, LeastSoldYearTextBox.Text);
                IncomeGrid.Visibility = Visibility.Collapsed;
                LeastSoldGrid.Visibility = Visibility.Visible;
                MissGrid.Visibility = Visibility.Collapsed;
            
           
        }

        private void MissButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                log.Miss(MissListView);
                MissGrid.Visibility = Visibility.Visible;
                LeastSoldGrid.Visibility = Visibility.Collapsed;
                IncomeGrid.Visibility = Visibility.Collapsed;
            }
            catch { MessageBox.Show("Нет необходимых элемениов"); }
        }
    }
    
}
