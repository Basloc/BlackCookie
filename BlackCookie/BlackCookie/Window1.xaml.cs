using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Media;
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
                new Items(500, "AK47", "2 bananes par cliques", 2, @"C:\Users\Tran\Downloads\sound\new-movie-1.wav"),
                new Items(1000, "FIST", "5 bananes par clique", 5, @"C:\Users\Tran\Downloads\sound\punch_u4LmMsr.wav"),
                new Items(5000, "BAT", "10 bananes par clique", 10, @"C:\Users\Tran\Downloads\sound\bathitball.wav"),
                new Items(10000, "WHIP", "15 bananes par clique", 15, @"C:\Users\Tran\Downloads\sound\crack_the_whip.wav"),
                new Items(50000, "BANJO", "20 bananes par clique", 20, @"C:\Users\Tran\Downloads\sound\despacito-guitar-riff.wav"),
                new Items(100000, "BOUGNOULS", "toujours en groupé car sans couilles...", 1, @"C:\Users\Tran\Downloads\sound\ben-voyons_-eric-zemmour.wav")
            };

            upgradeList.ItemsSource = shopItems;
        }

        public void PurchaseUpgrade(object sender, RoutedEventArgs e)
        {
            Items selectedUpgrade = (Items)upgradeList.SelectedItem;

            if (selectedUpgrade != null)
            {
                if (mainWindow.Acheter(selectedUpgrade.price))
                {
                    PlaySound(selectedUpgrade.SoundFilePath);

                    MessageBox.Show($"Item '{selectedUpgrade.name}' acheté pour {selectedUpgrade.price} cookies. Votre solde actuel {mainWindow.points} est cookies.", "Achat réussi", MessageBoxButton.OK, MessageBoxImage.Information);
                    mainWindow.UpdateClickValue(selectedUpgrade.durabilitée);
                    mainWindow.EquipItem(selectedUpgrade); // Équipe automatiquement l'objet acheté
                }
                else
                {
                    MessageBox.Show("Pas assez de bananes pour acheter cet objet.", "Achat impossible", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Sélectionnez un item à acheter.", "Aucun item sélectionné", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private void PlaySound(string soundFilePath)
        {
            if (!string.IsNullOrEmpty(soundFilePath))
            {
                try
                {
                    SoundPlayer player = new SoundPlayer(soundFilePath);
                    player.Play();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la lecture du son : {ex.Message}", "Erreur de lecture du son", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }

}

