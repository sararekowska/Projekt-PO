using System;


public class Osoba
{
    public string imię;
    public string Nazwisko;
    public DateTime? DataUrodzenia = new DateTime();
    public DateTime? DataŚmierci = new DateTime();
    public string imięNazwisko
    {
        get { return imię + " " + Nazwisko; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                imię = null;
                Nazwisko = null;
            }
            else
            {
                string[] split = value.Split(' ');
                if (split.Length > 1)
                {
                    imię = split[0];
                    Nazwisko = split[split.Length - 1];
                }
                else if (split.Length == 1)
                {
                    imię = split[0];
                    Nazwisko = string.Empty;
                }
            }
        }
    }

    public string Imię
    {
        get => imię;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Imię nie może być puste");
            }
            imię = value;
        }
    }

    public TimeSpan? Wiek
    {
        get
        {
            if (!DataŚmierci.HasValue && DataUrodzenia.HasValue)
            {
                return DateTime.Now - DataUrodzenia;
            }
            else if (!DataŚmierci.HasValue && !DataUrodzenia.HasValue)
            {
                return null;
            }
            else
            {
                return DataŚmierci - DataUrodzenia;
            }
       }
    }

    public Osoba (string imięNazwisko)
    {
        this.imięNazwisko = imięNazwisko;
    }

    public override string ToString()
    {
        return $"Imię i nazwisko: {imięNazwisko}\n" +
               $"Imię: {imię}\n" +
               $"Nazwisko: {Nazwisko}\n" +
               $"Data urodzenia: {DataUrodzenia}\n" +
               $"Data śmierci: {DataŚmierci}\n" +
               $"Wiek: {Wiek?.TotalDays / 365} lat";
    }
}


class Zadanie1
{
    static void Main(string[] args)
    {
        Osoba osoba1 = new Osoba("John Doe");
        osoba1.DataUrodzenia = new DateTime(1980, 10, 12);
        osoba1.DataŚmierci = new DateTime(2003, 3, 23);

        Console.WriteLine(osoba1.ToString());
    }
}
