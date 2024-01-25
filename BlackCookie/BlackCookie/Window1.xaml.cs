using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace BlackCookie
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private MainWindow mainWindow;
        private ObservableCollection<Items> shopItems;
        public Window1(MainWindow main)
        {
            InitializeComponent();
            mainWindow = main;
            InitializeUpgrades();
        }
        

        private void GoHome(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }
        private void InitializeUpgrades()
        {
            // Initialisation des items du shop
            shopItems = new ObservableCollection<Items>
            {
                new Items(500, "AK47", "2 bananes par cliques", 32),
            };

            upgradeList.ItemsSource = shopItems;
        }

        private void PurchaseUpgrade(object sender, RoutedEventArgs e)
        {
            Items selectedUpgrade = (Items)upgradeList.SelectedItem;

            if (selectedUpgrade != null)
            {
                mainWindow.Acheter(selectedUpgrade.price);
            }
            else
            {
                MessageBox.Show("Sélectionnez un item à acheter.", "Aucun item sélectionné", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}

