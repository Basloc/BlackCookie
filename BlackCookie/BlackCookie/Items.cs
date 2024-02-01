using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BlackCookie
{
    class Items : DependencyObject
    {
        public int price;
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(Items));

        public string name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        public string description{ get; set; }
        public int durabilitée { get; set; }
        public Items(int price,string name,string description,int durabilitée) 
        {
            this.price = price;
            this.name = name;
            this.description = description;
            this.durabilitée = durabilitée;
        }
    }
}
