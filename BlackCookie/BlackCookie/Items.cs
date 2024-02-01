using System.Windows;

namespace BlackCookie
{
    public class Items : DependencyObject
    {
        public int price;
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(Items));

        public string name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public string description { get; set; }
        public int durabilitée { get; set; }

        // Nouvelle propriété pour le chemin du fichier audio
        public string SoundFilePath { get; set; }

        public Items(int price, string name, string description, int durabilitée, string soundFilePath)
        {
            this.price = price;
            this.name = name;
            this.description = description;
            this.durabilitée = durabilitée;
            this.SoundFilePath = soundFilePath;
        }
    }
}
