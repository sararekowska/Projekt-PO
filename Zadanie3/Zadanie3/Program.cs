using System;

public class Wektor
{
    private double[] współrzędne;

    public Wektor(byte wymiar)
    {
        współrzędne = new double[wymiar];
    }

    public Wektor(params double[] współrzędne)
    {
        this.współrzędne = współrzędne;
    }
    
    public double Długość
    {
        get { return Math.Sqrt(IloczynSkalarny(this, this)); }
    }

    public byte Wymiar
    {
        get { return (byte)współrzędne.Length;}
    }

    public double this[byte i]
    {
        get { return współrzędne[i]; }
        set { współrzędne[i] = value; }
    }

    private static bool CzyTakieSameWymiary(Wektor w1, Wektor w2)
    {
        return w1.Wymiar != w2.Wymiar;
    }

    //Statyczne metody:

    public static double IloczynSkalarny(Wektor v, Wektor w)
    {
        if (CzyTakieSameWymiary(v, w))
        {
            throw new ArgumentException("Wektory muszą mieć taki sam wymiar");
        }
        double suma = 0;
        for (byte i = 0; i < v.Wymiar; i++)
        {
            suma += v[i] * w[i];
        }
        return suma;
    }

    public static Wektor Suma(params Wektor[] wektory)
    {
        byte wymiar = wektory[0].Wymiar;
        Wektor wynik = new Wektor(wymiar);

        for (int i = 1; i < wektory.Length; i++)
        {
            if (wektory[i].Wymiar != wymiar)
            {
                throw new ArgumentException("Wektory nie mają tego samego wymiaru");
            }
        }

        for (byte i = 0; i < wymiar; i++)
        {
            double suma = 0;
            for (int x = 0; x < wektory.Length; x++)
            {
                suma += wektory[x][i];
            }
            wynik[i] = suma;
        }
        return wynik;
    }

    //Operatory:

    public static Wektor operator +(Wektor v, Wektor w)
    {
        if (CzyTakieSameWymiary(v, w))
        {
            throw new ArgumentException("Wektory muszą mieć taki sam wymiar");
        }

        Wektor wynik = new Wektor(v.Wymiar);
        for (byte i = 0; i < v.Wymiar; i++)
        {
            wynik[i] = v[i] + w[i];
        }
        return wynik;
    }

    public static Wektor operator -(Wektor v, Wektor w)
    {
        if (CzyTakieSameWymiary(v, w))
        {
            throw new ArgumentException("Wektory muszą mieć taki sam wymiar");
        }

        Wektor wynik = new Wektor(v.Wymiar);
        for (byte i = 0; i < v.Wymiar; i++)
        {
            wynik[i] = v[i] - w[i];
        }
        return wynik;
    }

    public static Wektor operator *(Wektor v, double skalar)
    {
        Wektor wynik = new Wektor(v.Wymiar);
        for (byte i = 0; i < v.Wymiar; i++)
        {
            wynik[i] = v[i] * skalar;
        }
        return wynik;
    }

    public static Wektor operator *(double skalar, Wektor w)
    {
        return w * skalar;
    }

    public static Wektor operator /(Wektor v, double skalar)
    {
        if (skalar == 0)
        {
            throw new ArgumentException("Nie można dzielić przez zero");
        }
        Wektor wynik = new Wektor(v.Wymiar);
        for (byte i = 0; i < v.Wymiar; i++)
        {
            wynik[i] = v[i] / skalar;
        }
        return wynik;
    }

    public override string ToString()
    {
        string final = string.Join(" | ", współrzędne);
        return $"{final}";
    }
}

class Zadanie3
{
    public static void Main(string[] args)
    {
        Wektor v = new Wektor(2, 2, 8, 6);
        Wektor w = new Wektor(4, 4, 2, 6);

        double iloczynSkalarny = Wektor.IloczynSkalarny(v, w);
        Console.WriteLine("Iloczyn skalarny: " + iloczynSkalarny);

        Wektor suma = Wektor.Suma(v, w);
        Console.WriteLine("Suma: " + suma);

        Wektor odejmowanie = v - w;
        Console.WriteLine("Różnica: " + odejmowanie);

        Wektor mnożenie1 = v * 1.5;
        Console.WriteLine("Mnożenie: " + mnożenie1);

        Wektor mnożenie2 = 1.5 * v;
        Console.WriteLine("Mnożenie2: " + mnożenie2);

        Wektor dzielenie = v / 2;
        Console.WriteLine("Dzielenie: " + dzielenie);
        
    }
}