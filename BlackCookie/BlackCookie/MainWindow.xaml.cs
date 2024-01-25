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
using System;
using System.IO;
using System.ComponentModel;
using System.Windows.Ink;

namespace BlackCookie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int points = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Point_onclick(object sender, RoutedEventArgs e)
        {
            points++;
            label_points.Content = "Bananes : " + points;

        }

        private void GoToShop(object sender, RoutedEventArgs e)
        {
            Window1 shopWindow = new Window1(this);
            shopWindow.Show();
        }

        public void Acheter(int cout)
        {
            if (points >= cout)
            {
                points -= cout;
            }
            else
            {
                MessageBox.Show("Pas assez de bananes ");
            }
        }
    }
}
