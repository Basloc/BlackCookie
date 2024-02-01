using System.Windows;
using Newtonsoft.Json;
using System.IO;


namespace BlackCookie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int points = 0;
        int cookieGains = 1;

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
            Closing += MainWindow_Closing;

        }

        private void Point_onclick(object sender, RoutedEventArgs e)
        {
            points += cookieGains;
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
                label_points.Content = "Bananes : " + points;
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
                label_points.Content = "Bananes : " + points;
                // Mettez à jour d'autres propriétés si nécessaire
            }
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Avant la fermeture, sauvegardez le jeu
            SaveGame();
        }


    }
}
