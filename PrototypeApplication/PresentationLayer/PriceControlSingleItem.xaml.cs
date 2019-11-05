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

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for PriceControlSingleItem.xaml
    /// </summary>
    public partial class PriceControlSingleItem : Window
    {
        public PriceControlSingleItem(int itemId)
        {
            InitializeComponent();

            //PriceBox.Text = 
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            PriceControl priceControl = new PriceControl();
            priceControl.Show();
            this.Close();
        }

    }
}
