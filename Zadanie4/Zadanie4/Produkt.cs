using System;

namespace zadanie4
{
    public interface IProdukt
    {
        string Nazwa { get; set; }
        decimal CenaNetto { get; set; }
        decimal CenaBrutto { get; }
        string KategoriaVAT { get; }
        string KrajPochodzenia { get; set; }
    }

    public class Produkt : IProdukt
    {
        public Produkt(string nazwa, decimal cenaNetto, string kategoriaVAT, string krajPochodzenia)
        {
            Nazwa = nazwa;
            CenaNetto = cenaNetto;
            KategoriaVAT = kategoriaVAT;
            KrajPochodzenia = krajPochodzenia;
        }

        public string Nazwa { get; set;}
        private decimal cenaNetto;
        public decimal CenaNetto
        {
            get { return cenaNetto; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cena nie może być ujemna");
                }
                cenaNetto = value;
            }
        }

        public string KategoriaVAT { get; set; }
        public decimal procenty => SłownikVAT[KategoriaVAT];

        public Dictionary<string, int> SłownikVAT = new Dictionary<string, int>()
        {
            {"1", 23},
            {"2", 8},
            {"3", 5 },
            {"4", 0}
        };

        public decimal CenaBrutto => CenaNetto * (1 + procenty / 100);

        

        private string krajPochodzenia;
        public string KrajPochodzenia
        {
            get => krajPochodzenia;
            set
            {
                if (krajPochodzenia == "")
                {
                    krajPochodzenia = "Nieznany";
                    throw new NotImplementedException();
                }
                else krajPochodzenia = value;
            }
        }

        public override string ToString()
        {
            return $"Nazwa: {Nazwa}\n" +
                   $"Cena netto: {CenaNetto}\n" +
                   $"Cena Brutto: {CenaBrutto}\n" +
                   $"Kategoria VAT: {KategoriaVAT}\n" +
                   $"Kraj pochodzenia: {KrajPochodzenia}\n";
        }

    }
}