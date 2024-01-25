using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCookie
{
    class Items
    {
        public int price;
        public string name;
        public string description;
        public int durabilitée;
        public Items(int price,string name,string description,int durabilitée) 
        {
            this.price = price;
            this.name = name;
            this.description = description;
            this.durabilitée = durabilitée;
        }
    }
}
