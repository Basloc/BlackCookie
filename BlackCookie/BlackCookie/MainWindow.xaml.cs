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

namespace BlackCookie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int points = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Point_onclick(object sender, RoutedEventArgs e)
        {
            points++;
            label_points.Content = "Bananes : "+points.ToString();

        }

        
    }
}
