using System;
using zadanie4;

namespace zadanie4
{
    class Zadanie4
    {
        public static void Main(string[] args)
        {
            Produkt produkt = new Produkt("Mleko", 5, "1", "Polska");
            Console.WriteLine(produkt.ToString());
        }
    }
}
