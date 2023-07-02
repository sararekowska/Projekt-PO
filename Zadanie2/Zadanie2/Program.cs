using System;
using System.Text;
using System.Collections.Generic;

public class Prostokąt
{
    private double bokA;
    private double bokB;

    public Prostokąt(double bokA, double bokB)
    {
        BokA = bokA;
        BokB = bokB;
    }

    public double BokA
    {
        get => bokA;
        set
        {
            if (IsValidNumber(value))
            {
                bokA = value;
            }
            else
            {
                throw new ArgumentException("Długość boku A powinna być skończoną nieujemną liczbą");
            }
        }
    }

    public double BokB
    {
        get => bokB;
        set
        {
            if (IsValidNumber(value))
            {
                bokB = value;
            }
            else
            {
                throw new ArgumentException("Długość boku B powinna być skończoną nieujemną liczbą");
            }
        }
    }

    private bool IsValidNumber(double number)
    {
        return number >= 0 && !double.IsNaN(number) && !double.IsInfinity(number);
    }

    public static Dictionary<char, decimal> wysokośćArkusza0 = new Dictionary<char, decimal>
    {
        ['A'] = 1189,
        ['B'] = 1414,
        ['C'] = 1297
    };

    public static Prostokąt ArkuszPapieru(string formatPapieru)
    {
        char X = formatPapieru[0];
        byte i;

        decimal wysokośćBazowa = wysokośćArkusza0[X];
        double pierwiastekZDwóch = Math.Sqrt(2);

        if (!byte.TryParse(formatPapieru[1].ToString(), out i))
        {
            throw new ArgumentException("Niepoprawny format");
        }

        double bokA = Math.Round((double)(wysokośćBazowa / (decimal)Math.Pow(pierwiastekZDwóch, i)));
        double bokB = Math.Round(bokA / pierwiastekZDwóch);

        return new Prostokąt(bokA, bokB);
    }
}

class Zadanie2
{
    static void Main(string[] args)
    {
        Prostokąt arkusz = Prostokąt.ArkuszPapieru("A4");
        Console.WriteLine($"Bok A: {arkusz.BokA} mm, Bok B: {arkusz.BokB} mm");
        Console.ReadLine();
    }
}