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
        private ObservableCollection<Items>? shopItems;
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
                new Items(5, "AK47", "2 bananes par cliques", 2),
                new Items(1000, "FIST", "5 bananes par clique", 5),
                new Items(5000, "BAT", "10 bananes par clique", 10),
                new Items(10000, "WHIP", "15 bananes par clique", 15),
                new Items(50000, "BANJO", "20 bananes par clique", 20),
                new Items(100000, "BOUGNOULS", "toujours en groupé car sans couilles...", 1)
            };

            upgradeList.ItemsSource = shopItems;
        }

        public void PurchaseUpgrade(object sender, RoutedEventArgs e)
        {
            Items selectedUpgrade = (Items)upgradeList.SelectedItem;

            if (selectedUpgrade != null)
            {
                MessageBox.Show($"Item '{selectedUpgrade.name}' acheté pour {selectedUpgrade.price} cookies. Votre solde actuel {mainWindow.points} est cookies.", "Achat réussi", MessageBoxButton.OK, MessageBoxImage.Information);
                mainWindow.Acheter(selectedUpgrade.price);
                mainWindow.UpdateClickValue(selectedUpgrade.durabilitée);
            }
            else
            {
                MessageBox.Show("Sélectionnez un item à acheter.", "Aucun item sélectionné", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


    }
}

