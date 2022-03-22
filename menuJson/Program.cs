using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace menujson
{
    class Menuinfo
    {
        public string Naam { get; set; }
        public double Prijs { get; set; }
        public List<string> Allergie { get; set; }
        public string Categorie { get; set; }

    }

    class Menu
    {
        public static void Main(string[] args)
        {
            string menures = String.Empty;
            menures = File.ReadAllText(@"menu.json");
            JsonConvert.DeserializeObject<Menuinfo>(menures);


        }
    }
}

