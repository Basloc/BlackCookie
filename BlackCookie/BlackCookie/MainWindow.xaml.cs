using System.Windows;
using Newtonsoft.Json;
using System.IO;
using System;
using System.Timers;
using System.Windows.Threading;
using System.Media;


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
        private Items equippedItem;


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
            autoClickerTimer.Interval = 1000;
            autoClickerTimer.Elapsed += AutoClickerTimerElapsed;
            autoClickerTimer.Start();
            Closing += MainWindow_Closing;

        }

        private void Point_onclick(object sender, RoutedEventArgs e)
        {
            points += cookieGains;
            ApplyRandomEvent();
            updateBananaCount();
            Click(isAutoClick: false); // Appel de la méthode Click en spécifiant que le clic n'est pas automatique
        }


        private void GoToShop(object sender, RoutedEventArgs e)
        {
            Window1 shopWindow = new Window1(this);
            shopWindow.Show();
        }

        public bool Acheter(int cout)
        {
            if (points >= cout)
            {
                points -= cout;
                updateBananaCount();
                return true;
            }
            else
            {
                return false;
            }
        }

        internal void UpdateClickValue(int value)
        {
            cookieGains += value;
        }

        public void SaveGame()
        {
            
            Data data = new Data
            {
                CookieCount = points,
                ClickValue = cookieGains
                
            };

            
            string json = JsonConvert.SerializeObject(data);

          
            File.WriteAllText("save.json", json);
        }

        public void EquipItem(Items item)
        {
            equippedItem = item;
        }

        public void LoadGame()
        {
            
            if (File.Exists("save.json"))
            {
               
                string json = File.ReadAllText("save.json");

                
                Data data = JsonConvert.DeserializeObject<Data>(json);

                
                points = data.CookieCount;
                cookieGains = data.ClickValue;
                updateBananaCount();
                
            }
        }

        public void updateBananaCount()
        {
            label_points.Content = "Bananes : " + points;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
            SaveGame();
        }

        public void ApplyRandomEvent()
        {
            
            if (random.NextDouble() < 0.1)
            {
                if (points > 150)
                {
                    int randomSubtract = random.Next(1, 100);
                    points -= randomSubtract;
                }
                
                

                
                if (cookieGains > 15)
                {

                    int randomSubtractClickValue = random.Next(1, 5);
                    cookieGains -= randomSubtractClickValue;
                }

                
                updateBananaCount();
            }
        }
        private void AutoClickerTimerElapsed(object sender, ElapsedEventArgs e)
        {
            uiDispatcher.Invoke(() =>
            {
                ApplyAutoClick();
                ApplyRandomEvent();
            });
        }

        public void ApplyAutoClick()
        {
            uiDispatcher.Invoke(() =>
            {
                Click(isAutoClick: true);
            });
        }

        public void Click(bool isAutoClick = false)
        {
            points++;
            updateBananaCount();
            ApplyRandomEvent();

            // Vérifie s'il y a un objet équipé et si le clic n'est pas automatique
            if (equippedItem != null && !isAutoClick)
            {
                PlaySound(equippedItem.SoundFilePath);
            }
            else if (!isAutoClick && equippedItem == null)
            {
                PlaySound(@"C:\Users\Tran\Downloads\sound\slap-sound-effect-free.wav");
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
