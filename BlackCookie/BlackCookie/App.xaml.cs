using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows;

namespace BlackCookie
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var ak = new Items(500, "AK47", "2 bananes par cliques", 32);
            var fist = new Items(1000, "FIST", "5 bananes par clique", 50);
            var bat = new Items(5000, "BAT", "10 bananes par clique", 25);
            var whip = new Items(10000, "WHIP", "15 bananes par clique", 10);
            var banjo = new Items(50000, "BANJO", "20 bananes par clique", 10);
            var bougnouls = new Items(100000, "BOUGNOULS", "toujours en groupé car sans couilles...", 1);
        }
    }
}
