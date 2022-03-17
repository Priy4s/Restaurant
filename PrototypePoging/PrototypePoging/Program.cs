using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visual
{
    public static class Globals
    {
        // Alle variabelen, die als globals gebruikt worden, moeten hier gedefiniëerd worden.
        public static int seats = 200;
        public static int available_seats = 200;
        public static int taken_seats = 0;
        public static Dictionary<string, int> reservering_personen = new Dictionary<string, int>();
        public static Dictionary<string, string> reservering_tijd = new Dictionary<string, string>();
        public static List<string> gebruikersnamen = new List<string>();
        public static List<string> wachtwoorden = new List<string>();
        public static bool ingelogd = false;
    }

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            /*
            Deze while-loop zorgt ervoor dat de applicatie blijft runnen. Deze eindigt pas wanneer er op het kruisje wordt geklikt OF
            bij het HOOFDMENU op de cijfer 0 wordt geklikt.
             */
            {
                Console.Clear(); // Maakt de console leeg, zodat het lijkt alsof er een nieuw scherm is geopend.
                Console.WriteLine("Welkom bij HighClass!\n");
                Console.WriteLine("Hoofdmenu");
                string scherm = "[1] Reserveren\n[2] Menu\n[3] Account\n[4] Omzet"; // De "knoppen"
                Console.WriteLine(scherm);
                ConsoleKeyInfo ckey = Console.ReadKey(); // Deze variabele krijgt als input de toets die de gebruiker op het toetsenbord heeft aangeklikt.
                if (ckey.Key == ConsoleKey.D1) // Checkt of de aangeklikte toets overeenkomt met het cijfer die aan de knop is gekoppeld (D1, D2, etc zijn de cijfers).
                {
                    bool no = false;
                    if (Globals.ingelogd) // Checkt of een medewerker is ingelogd, om een functie uit te voeren.
                    {
                        Console.Clear();
                        Console.WriteLine("Wilt u de beschikbare plekken wijzigen?");
                        string vraagje = "[1] Ja\n[2] Nee";
                        Console.WriteLine(vraagje);
                        ConsoleKeyInfo cvjkey = Console.ReadKey();
                        if (cvjkey.Key == ConsoleKey.D1)
                        {
                            Plekken();
                        }
                        else if (cvjkey.Key == ConsoleKey.D2)
                        {
                            no = true;
                        }
                    }
                    else if (Globals.ingelogd == false || no == false)
                    {
                        Console.Clear();
                        Console.WriteLine("Heeft u al een reservering?");
                        string vraag = "[1] Ja\n[2] Nee";
                        Console.WriteLine(vraag);
                        ConsoleKeyInfo cvkey = Console.ReadKey();
                        if (cvkey.Key == ConsoleKey.D1)
                        {
                            Console.Clear();
                            Console.WriteLine("Wilt u deze wijzigen of annuleren?");
                            string vraag2 = "[1] Wijzigen\n[2] Annuleren";
                            Console.WriteLine(vraag2);
                            ConsoleKeyInfo cv2key = Console.ReadKey();
                            if (cv2key.Key == ConsoleKey.D1)
                            {
                                Wijzigen();
                            }
                            else if (cv2key.Key == ConsoleKey.D2)
                            {
                                Annuleren();
                            }
                        }
                        else if (cvkey.Key == ConsoleKey.D2)
                        {
                            Reserveren();
                        }
                    }
                }
                else if (ckey.Key == ConsoleKey.D2)
                {
                    Menu();
                }
                else if (ckey.Key == ConsoleKey.D3)
                {
                    Account();
                }
                else if (ckey.Key == ConsoleKey.D4)
                {
                    Omzet();
                }
                else if (ckey.Key == ConsoleKey.D0)
                {
                    break;
                }
            }
        }
        static void Reserveren()
        {
            Console.Clear();

            string voornaam;
            Console.WriteLine("Voornaam: ");
            voornaam = Console.ReadLine(); // De input van de gebruiker wordt toegevoegd aan de variabel.

            string achternaam;
            Console.WriteLine("Achternaam: ");
            achternaam = Console.ReadLine();
            string naam = voornaam + achternaam; // Naam van reservering (komt later terug)

            Console.WriteLine("\nEr zijn nog " + Globals.available_seats + " plekken beschikbaar.");
            int aantal;
            Console.WriteLine("Aantal personen: ");
            aantal = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Starttijd reservering: ");
            string tijd;
            tijd = Console.ReadLine();
            Globals.reservering_personen.Add(naam, aantal); // Dictionary met de naam van de reservering als key en de value is het aantal personen.
            Globals.reservering_tijd.Add(naam, tijd); // Dictionary met de naam van de reservering als key en de value het tijdstip.
            Globals.available_seats -= aantal;
            Globals.taken_seats += aantal;
            Console.Clear();
            while (true) // Deze while-loop zorgt ervoor dat de tekst in de console blijft staan, totdat de gebruiker op 'Enter' klikt.
            {
                Console.WriteLine("Uw reservering is succesvol opgeslagen.");
                Console.WriteLine("U heeft nu een reservering voor " + aantal + " personen om " + tijd + ".\n" +
                    "\nKlik op 'Enter' om verder te gaan naar het hoofdmenu.");
                ConsoleKeyInfo done = Console.ReadKey();
                if (done.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }
        static void Wijzigen()
        {
            Console.Clear();
            string voornaam;
            Console.WriteLine("Voornaam: ");
            voornaam = Console.ReadLine();

            string achternaam;
            Console.WriteLine("Achternaam: ");
            achternaam = Console.ReadLine();

            string naam = voornaam + achternaam;

            Console.Clear();
            Console.WriteLine("Wilt u de tijd of het aantal personen wijzigen?");
            string vraag = "[1] Tijd\n[2] Aantal personen";
            Console.WriteLine(vraag);
            ConsoleKeyInfo cwkey = Console.ReadKey();

            if (cwkey.Key == ConsoleKey.D2)
            {
                Console.Clear();
                Console.WriteLine("Er zijn nog " + Globals.available_seats + " plekken beschikbaar.");
                Console.WriteLine("Nieuw aantal personen: ");
                int wijziging = Convert.ToInt32(Console.ReadLine());
                Globals.available_seats += Globals.reservering_personen[naam]; // Globals.reservering_personen[naam] zoekt naar de value die bj de key "naam" hoort.
                Globals.taken_seats -= Globals.reservering_personen[naam];
                Globals.available_seats -= wijziging;
                Globals.taken_seats += wijziging;
                Globals.reservering_personen[naam] = wijziging; // Verandert de value die bij de key "naam" hoort.
            }
            else if (cwkey.Key == ConsoleKey.D1)
            {
                Console.Clear();
                Console.WriteLine("Nieuwe tijd: ");
                string wijziging = Console.ReadLine();
                Globals.reservering_tijd[naam] = wijziging;
            }
            Console.Clear();
            while (true)
            {
                Console.WriteLine("\nUw reservering is succesvol gewijzigd.");
                Console.WriteLine("U heeft nu een reservering voor " + Globals.reservering_personen[naam] + " personen om " + Globals.reservering_tijd[naam] + ".\n\n");
                Console.WriteLine("\nKlik op 'Enter' om verder te gaan naar het hoofdmenu.");
                ConsoleKeyInfo done = Console.ReadKey();
                if (done.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }
        static void Annuleren()
        {
            Console.Clear();
            string voornaam;
            Console.WriteLine("Voornaam: ");
            voornaam = Console.ReadLine();

            string achternaam;
            Console.WriteLine("Achternaam: ");
            achternaam = Console.ReadLine();

            string naam = voornaam + achternaam;

            Globals.available_seats += Globals.reservering_personen[naam];
            Globals.taken_seats -= Globals.reservering_personen[naam];
            Globals.reservering_personen.Remove(naam); // Verwijdert de key (+ value) die bij "naam" hoort.
            Globals.reservering_tijd.Remove(naam);

            while (true)
            {
                Console.WriteLine("\nUw reservering is succesvol geannuleerd.");
                Console.WriteLine("Er zijn nu " + Globals.available_seats + " plekken beschikbaar.");
                Console.WriteLine("\nKlik op 'Enter' om verder te gaan naar het hoofdmenu.");
                ConsoleKeyInfo done = Console.ReadKey();
                if (done.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }
        static void Plekken()
        {
            Console.Clear();
            Console.WriteLine("Er zijn " + Globals.available_seats + " plekken beschikbaar.");

            Console.WriteLine("Zijn er meer of minder stoelen vrijgekomen?");
            string meerofminder = "[1] Meer\n[2] Minder";
            Console.WriteLine(meerofminder);
            ConsoleKeyInfo cpkey = Console.ReadKey();
            Console.WriteLine("\n\nMet hoeveel?");
            int wijziging = Convert.ToInt32(Console.ReadLine());

            if (cpkey.Key == ConsoleKey.D2)
            {
                Globals.taken_seats += wijziging;
                Globals.available_seats -= wijziging;
            }
            else if (cpkey.Key == ConsoleKey.D1)
            {
                Globals.taken_seats -= wijziging;
                Globals.available_seats += wijziging;
            }
            while (true)
            {
                Console.WriteLine($"Er zijn nu {Globals.available_seats} plekken beschikbaar.");
                Console.WriteLine("\nKlik op 'Enter' om verder te gaan naar het hoofdmenu.");
                ConsoleKeyInfo done = Console.ReadKey();
                if (done.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }
        static bool Inloggen()
        {
            int tries = 3; // Aantal kansen die de gebruiker heeft om de goede inloggegevens in te vullen.
            while (tries > 0)
            {
                Console.Clear();
                Console.WriteLine("Gebruikersnaam: ");
                string gebruikersnaam = Console.ReadLine();
                Console.WriteLine("Wachtwoord: ");
                string wachtwoord = Console.ReadLine();

                for (int i = 0; i < Globals.gebruikersnamen.Count; i++) // Deze for-loop zorgt ervoor dat zo vaak loopt als dat de lijst met gebruikersnamen lang is.
                {
                    if (Globals.gebruikersnamen[i] == gebruikersnaam) // Gaat door de lijst met gebruikersnamen heen, totdat de gebruikersnaam die op plaats i staat
                                                                      // gelijk is aan de (door de gebruiker) ingevulde gebruikersnaam.
                    {
                        if (Globals.wachtwoorden[i] == wachtwoord) // Hier is i gelijk aan de plaats van het (JUIST) ingevulde gebruikersnaam en checkt of op dezelfde
                                                                   // plaats in de wachtwoorden lijst het wachtwoord overeen komt met het (door de gebruiker) ingevulde
                                                                   // wachtwoord.
                        {
                            Console.Clear();
                            while (true)
                            {
                                Console.WriteLine("Welkom, " + gebruikersnaam + "!");
                                Console.WriteLine("\nKlik op 'Enter' om verder te gaan naar het hoofdmenu.");
                                ConsoleKeyInfo done = Console.ReadKey();
                                if (done.Key == ConsoleKey.Enter)
                                {
                                    break;
                                }
                            }
                            return true; // Zet de boolean "ingelogd" op true, waardoor het programma weet dat er succesvol is ingelogd.
                        }
                    }
                }
                while (true)
                {
                    Console.WriteLine("Gebruikersnaam en/of wachtwoord onjuist. U heeft nog " + tries + " over.\nKlik op 'Enter' om het opnieuw te proberen.");
                    ConsoleKeyInfo done = Console.ReadKey();
                    if (done.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
                tries--;
            }
            return false; // Wanneer er 3 keer foute inloggegevens zijn ingevuld, blijft de boolean "ingelogd" op false.
        }
        static bool Aanmelden()
        {
            Console.Clear();
            string gebruikersnaam; string wachtwoord;
            Console.WriteLine("Gebruikersnaam: ");
            gebruikersnaam = Console.ReadLine();
            Globals.gebruikersnamen.Add(gebruikersnaam); // Voegt de ingevulde gebruikersnaam toe aan de lijst 
            Console.WriteLine("Wachtwoord: ");
            wachtwoord = Console.ReadLine();
            Globals.wachtwoorden.Add(wachtwoord); // Voegt het ingevulde wachtwoord toe aan de lijst op dezelfde plek als de gebruikersnaam (maar in een andere lijst).
            Console.Clear();

            while (true)
            {
                Console.WriteLine("Account is succesvol aangemaakt.\n\nKlik op 'Enter' om in te loggen en verder te gaan.");
                ConsoleKeyInfo done = Console.ReadKey();
                if (done.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
            bool verder = Inloggen();
            return verder;
        }
        static bool Uitloggen()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("U bent succesvol uitgelogd.");
                Console.WriteLine("\nKlik op 'Enter' om verder te gaan naar het hoofdmenu.");
                ConsoleKeyInfo done = Console.ReadKey();
                if (done.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
            return false; // Zet de boolean "ingelogd" op false, MAAR de accounts bestaand nog! 
        }
        static void Account()
        {
            Console.Clear();
            string doen = "[1] Inloggen\n[2] Aanmelden\n[3] Uitloggen";
            Console.WriteLine(doen);
            ConsoleKeyInfo cakey = Console.ReadKey();

            if (cakey.Key == ConsoleKey.D1)
            {
                Globals.ingelogd = Inloggen();
            }
            else if (cakey.Key == ConsoleKey.D2)
            {
                Globals.ingelogd = Aanmelden();
            }
            else if (Globals.ingelogd == true && (cakey.Key == ConsoleKey.D3))
            {
                Globals.ingelogd = Uitloggen();
            }
        }
        static void Menu()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("We hebben helaas nog geen menu. Coming soon!\n");
                Console.WriteLine("\nKlik op 'Enter' om terug te gaan naar het hoofdmenu.");
                ConsoleKeyInfo done = Console.ReadKey();
                if (done.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }
        static void Omzet()
        {
            Console.Clear();
            if (Globals.ingelogd == true)
            {
                double omzet = 50 * Globals.taken_seats;
                while (true)
                {
                    Console.WriteLine($"Als we ervan uitgaan dat een klant 50 euro zal uitgeven, wordt uw omzet van vandaag: {omzet} euro.");
                    Console.WriteLine("\nKlik op 'Enter' om verder te gaan naar het hoofdmenu.");
                    ConsoleKeyInfo done = Console.ReadKey();
                    if (done.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            }
            else
            {
                while (true)
                {
                    Console.WriteLine("Alleen medewerkers kunnen de omzet bekijken.\nKlik op 'Enter' om in te loggen en probeer het opnieuw.");
                    ConsoleKeyInfo done = Console.ReadKey();
                    if (done.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
                Account();
            }
        }
    }
}