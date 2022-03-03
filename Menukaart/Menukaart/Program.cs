using System;

namespace Menukaart
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine("\n Menukaart\n");
                Console.WriteLine("1. Brunch");
                Console.WriteLine("2. Lunch");
                Console.WriteLine("3. Diner");
                Console.WriteLine("4. Drinken");
                Console.WriteLine("5. Alergieën informatie");
                Console.WriteLine("0. Terug");

                string input = Console.ReadLine();
                int keuze = Convert.ToInt32(input);

                if (keuze == 1)
                {
                    Console.WriteLine("---------------------------------------------------------------------");
                    Console.WriteLine("\nBrunch");
                    Console.WriteLine(" Pannenkoek galette met ei - 7,50");
                    Console.WriteLine(" Rugelach recept met jam - 6,95 (G)");
                    Console.WriteLine(" Kaasfondue voor twee met knoflook - 7,95");
                    Console.WriteLine(" Appel kaneel wraps met citroen en bruine suiker - 5,00 (G)");

                }
                else if (keuze == 2)
                {
                    Console.WriteLine("---------------------------------------------------------------------");
                    Console.WriteLine("\nLunch");
                    Console.WriteLine(" Franse frietjes uit de oven met verse kruiden - 4,50 (V)");
                    Console.WriteLine(" Champignonsalade met spinazie - 4,95 (V,G)");
                    Console.WriteLine(" Walnoot-krulandijvie salade - 5,00 (V,G)");
                    Console.WriteLine(" Haricots verts met spek - 5,95\n");

                    Console.WriteLine(" -Soepen: ");
                    Console.WriteLine("   Gele tomaat paprika soep - 4,50 (V)");
                    Console.WriteLine("   Tomatensoep met pijnboompitten - 3,75");
                    Console.WriteLine("   Soep van lente ui rucola en knoflook - 3,50");
                    Console.WriteLine("   Tomaat pastinaak soep - 3,95");
                }
                else if (keuze == 3)
                {
                    Console.WriteLine("---------------------------------------------------------------------");
                    Console.WriteLine("\n Diner");
                    Console.WriteLine("1. Voorgerechten");
                    Console.WriteLine("2. Hoofdgerechten");
                    Console.WriteLine("3. Nagerechten");
                    Console.WriteLine("0. Terug");
                    input = Console.ReadLine();
                    keuze = Convert.ToInt32(input);

                    if (keuze == 1)
                    {

                        //Voorgerechten
                        Console.WriteLine("---------------------------------------------------------------------");
                        Console.WriteLine("\nVoorgerechten:  ");
                        Console.WriteLine(" Caesar salade met kip en bacon - 8,95");
                        Console.WriteLine(" Gebakken uien dip - 5,95");
                        Console.WriteLine(" Ragout met knolselderij - 7,95 ");
                        Console.WriteLine(" Hollandse garnalen op toast - 4,50\n ");

                        Console.WriteLine(" -Soepen: ");
                        Console.WriteLine("   Pittige tomaten-uiensoep - 5,75 (L)");
                        Console.WriteLine("   Franse uiensoep - 4,95");
                        Console.WriteLine("   Beurre Blanc - 5,95");
                        Console.WriteLine("   Chinese tomatensoep - 5,50 (L)");
                    }
                    else if (keuze == 2)
                    {
                        Console.WriteLine("---------------------------------------------------------------------");
                        Console.WriteLine("\nHoofdgerechten:");
                        Console.WriteLine(" -Sushi (8 stuks): ");
                        Console.WriteLine("   Sushi garnaal - 12,50 ");
                        Console.WriteLine("   California roll - 13,50 ");
                        Console.WriteLine("   Tuna roll - 15,00 ");
                        Console.WriteLine("   Vega roll - 11,75 (V)\n");

                        Console.WriteLine(" Ramen soep met spek en ei - 11,95");
                        Console.WriteLine(" Vegan ramen met kipstukjes - 12,50 (V)");
                        Console.WriteLine(" Vegan nacho schotel met pulled chicken - 9,95 (V)");
                        Console.WriteLine(" Snelle burger met sla  - 7,50");
                        Console.WriteLine(" Chili con carne - 5,95");
                        Console.WriteLine(" Kipnuggets - 5,95");
                    }
                    //Nagerechten
                    else if (keuze == 3)
                    {
                        Console.WriteLine("---------------------------------------------------------------------");
                        Console.WriteLine("\nNagerechten:");
                        Console.WriteLine(" Pavlova met rode sinaasappel - 5,95 ");
                        Console.WriteLine(" Dame Blanche klassiek - 6,50 ");
                        Console.WriteLine(" Vegan tiramisu recept - 6,95 (V) ");
                        Console.WriteLine(" Tiramisu met rood fruit - 6,50 (N) ");
                        Console.WriteLine(" Panna cotta met witte chocolade - 6,95 ");
                        Console.WriteLine(" Vijgen uit de oven met crumble - 7,50 (N) ");
                        Console.WriteLine(" Tarte tatin met wilde perzik - 6,95 ");
                    }
                }

                else if (keuze == 4)
                {
                    Console.WriteLine("---------------------------------------------------------------------");
                    Console.WriteLine("\n Drinken\n");
                    Console.WriteLine("1. Non alcoholische dranken");
                    Console.WriteLine("2. Alcoholische dranken (A)");
                    Console.WriteLine("0. Terug");
                    input = Console.ReadLine();
                    keuze = Convert.ToInt32(input);
                    //Warme dranken
                    if (keuze == 1)
                    {
                        Console.WriteLine("---------------------------------------------------------------------");
                        Console.WriteLine("\nNon alcoholische dranken\n");
                        Console.WriteLine(" -Warme dranken");
                        Console.WriteLine("   Zwarte koffie - 3.50");
                        Console.WriteLine("   Cappuccino - 3.70");
                        Console.WriteLine("   Koffie verkeerd - 3.50");
                        Console.WriteLine("   Munt thee - 3.00");
                        Console.WriteLine("   Gember thee - 3.10\n");
                        //Koude dranken
                        Console.WriteLine(" -Koude dranken");
                        Console.WriteLine("   Coca Cola (regular/light/zero) - 2.90");
                        Console.WriteLine("   Fanta/Sprite - 2.90");
                        Console.WriteLine("   Water (plat/bruisend) - 2.70");
                        Console.WriteLine("   Lipton Ice Tea Sparkling of Green - 2.75");
                        Console.WriteLine("   Verse Jus d'Orange - 3.15\n");
                    }
                    //Alcoholische dranken
                    else if (keuze == 2)
                    {
                        Console.WriteLine("---------------------------------------------------------------------");
                        Console.WriteLine("\nAlcoholische dranken\n");
                        Console.WriteLine(" -Bier:");
                        Console.WriteLine("   Jupiler - 2.60");
                        Console.WriteLine("   Heineken - 3.25");
                        Console.WriteLine("   Hertog Jan - 3.10");
                        Console.WriteLine(" -Wijn:");
                        Console.WriteLine("   Rosé/zoete witte wijn - 3.50");
                        Console.WriteLine("   Merlot wijn - 3.60");
                        Console.WriteLine("   Rode wijn - 3.10");
                        Console.WriteLine(" -Cocktails:");
                        Console.WriteLine("   Passion Energy - 9.75");
                        Console.WriteLine("   Red ginger - 9.70");
                        Console.WriteLine("   Mojito (regular/strawberry mojito) - 9.70");
                    }
                }
                else if (keuze == 5)
                {
                    Console.WriteLine("---------------------------------------------------------------------");
                    Console.WriteLine("\n Alergieën informatie\n");
                    Console.WriteLine("V - Vegan");
                    Console.WriteLine("N - Bevat noten");
                    Console.WriteLine("L - Lactose vrij");
                    Console.WriteLine("G - Gluten vrij");
                    Console.WriteLine("A - Bevat alocohol");
                }
                    Console.WriteLine("\n0. Terug"); // checkt niet, programma gaat autoamtisch terug naar main menukaart
                    string input2 = Console.ReadLine();
                
            }
        }
    }
}
