using System.Windows;
using Newtonsoft.Json;
using System.IO;
using System;
using System.Timers;
using System.Windows.Threading;


namespace BlackCookie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int points = 0;
        int cookieGains = 1;
        private Random random = new Random();
        private Timer autoClickerTimer = new Timer();
        private Dispatcher uiDispatcher;
        

        private static MainWindow? instance;

        public static MainWindow Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainWindow();
                }
                return instance;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            LoadGame();
            uiDispatcher = Dispatcher.CurrentDispatcher;
            autoClickerTimer.Interval = 1000; // 1000 millisecondes (1 seconde)
            autoClickerTimer.Elapsed += AutoClickerTimerElapsed;
            autoClickerTimer.Start();
            Closing += MainWindow_Closing;

        }

        private void Point_onclick(object sender, RoutedEventArgs e)
        {
            points += cookieGains;
            ApplyRandomEvent();
            updateBananaCount();

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
                updateBananaCount();
            }
            else
            {
                MessageBox.Show("Pas assez de bananes ");
            }
        }
        internal void UpdateClickValue(int value)
        {
            cookieGains += value;
        }

        public void SaveGame()
        {
            // Créez un objet de données à sauvegarder
            Data data = new Data
            {
                CookieCount = points,
                ClickValue = cookieGains
                // Ajoutez d'autres propriétés si nécessaire
            };

            // Convertissez l'objet en JSON
            string json = JsonConvert.SerializeObject(data);

            // Sauvegardez le JSON dans un fichier
            File.WriteAllText("save.json", json);
        }

        public void LoadGame()
        {
            // Vérifiez si le fichier de sauvegarde existe
            if (File.Exists("save.json"))
            {
                // Lisez le JSON depuis le fichier
                string json = File.ReadAllText("save.json");

                // Désérialisez le JSON en objet
                Data data = JsonConvert.DeserializeObject<Data>(json);

                // Mettez à jour les données du jeu
                points = data.CookieCount;
                cookieGains = data.ClickValue;
                updateBananaCount();
                // Mettez à jour d'autres propriétés si nécessaire
            }
        }

        public void updateBananaCount()
        {
            label_points.Content = "Bananes : " + points;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Avant la fermeture, sauvegardez le jeu
            SaveGame();
        }

        public void ApplyRandomEvent()
        {
            // Générez un nombre aléatoire pour déterminer si un événement aléatoire se produit
            if (random.NextDouble() < 0.1) // 10% de chance, ajustez selon vos besoins
            {
                if (points > 150)
                {
                    int randomSubtract = random.Next(1, 100);
                    points -= randomSubtract;
                }
                // Générez un montant aléatoire à soustraire du nombre de cookies
                

                // Générez un montant aléatoire à soustraire du clickValue
                if (cookieGains > 15)
                {

                    int randomSubtractClickValue = random.Next(1, 5); // Par exemple, soustraire entre 1 et 5 au clickValue
                    cookieGains -= randomSubtractClickValue;
                }

                // Mettez à jour l'interface utilisateur
                updateBananaCount();
            }
        }
        private void AutoClickerTimerElapsed(object sender, ElapsedEventArgs e)
        {
            uiDispatcher.Invoke(() =>
            {
                ApplyAutoClick(); // Appliquer le clic automatique
                ApplyRandomEvent(); // Appliquer un événement aléatoire, si nécessaire
            });
        }

        public void ApplyAutoClick()
        {
            uiDispatcher.Invoke(() =>
            {
                Click();
            });
            
        }
        public  void Click()
        {
            points++;
            updateBananaCount();
            ApplyRandomEvent();
      
        }

    }
}
