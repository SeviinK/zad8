using System;

enum RzadkoscPrzedmiotu
{
    Powszechny,
    Rzadki,
    Unikalny,
    Epicki
}

enum TypPrzedmiotu
{
    Bron,
    Zbroja,
    Amulet,
    Pierscien,
    Helm,
    Tarcza,
    Buty
}

struct Przedmiot
{
    public float Waga;
    public int Wartosc;
    public RzadkoscPrzedmiotu Rzadkosc;
    public TypPrzedmiotu Typ;
    public string NazwaWlasna;

    public void WypelnijPrzedmiot(float waga, int wartosc, RzadkoscPrzedmiotu rzadkosc, TypPrzedmiotu typ, string nazwaWlasna)
    {
        Waga = waga;
        Wartosc = wartosc;
        Rzadkosc = rzadkosc;
        Typ = typ;
        NazwaWlasna = nazwaWlasna;
    }

    public void WyswietlInformacje()
    {
        Console.WriteLine("Przedmiot: " + NazwaWlasna);
        Console.WriteLine("Typ: " + Typ);
        Console.WriteLine("Rzadkosc: " + Rzadkosc);
        Console.WriteLine("Waga: " + Waga);
        Console.WriteLine("Wartosc: " + Wartosc);
        Console.WriteLine();
    }
}

class Program
{
    static Random random = new Random();

    static Przedmiot LosujPrzedmiot(Przedmiot[] przedmioty)
    {
        int index = random.Next(przedmioty.Length);
        return przedmioty[index];
    }

    static Przedmiot LosujPrzedmiotZRzadkoscia(Przedmiot[] przedmioty)
    {
        int sum = 0;
        foreach (var przedmiot in przedmioty)
        {
            sum += (int)przedmiot.Rzadkosc;
        }

        int losowaWartosc = random.Next(sum) + 1;
        int aktualnaWartosc = 0;

        foreach (var przedmiot in przedmioty)
        {
            aktualnaWartosc += (int)przedmiot.Rzadkosc;
            if (losowaWartosc <= aktualnaWartosc)
            {
                return przedmiot;
            }
        }

        return przedmioty[random.Next(przedmioty.Length)];
    }

    static void Main(string[] args)
    {
        Przedmiot[] przedmioty = new Przedmiot[5];
        przedmioty[0].WypelnijPrzedmiot(2.5f, 10, RzadkoscPrzedmiotu.Powszechny, TypPrzedmiotu.Bron, "Miecz");
        przedmioty[1].WypelnijPrzedmiot(3.0f, 20, RzadkoscPrzedmiotu.Rzadki, TypPrzedmiotu.Zbroja, "Zbroja Płytowa");
        przedmioty[2].WypelnijPrzedmiot(0.5f, 50, RzadkoscPrzedmiotu.Unikalny, TypPrzedmiotu.Amulet, "Amulet Mocy");
        przedmioty[3].WypelnijPrzedmiot(0.1f, 100, RzadkoscPrzedmiotu.Epicki, TypPrzedmiotu.Pierscien, "Pierscien Potęgi");
        przedmioty[4].WypelnijPrzedmiot(1.0f, 30, RzadkoscPrzedmiotu.Powszechny, TypPrzedmiotu.Helm, "Helm Żelazny");

        Przedmiot wylosowanyPrzedmiot = LosujPrzedmiot(przedmioty);
        wylosowanyPrzedmiot.WyswietlInformacje();

        Przedmiot wylosowanyPrzedmiotZRzadkoscia = LosujPrzedmiotZRzadkoscia(przedmioty);
        wylosowanyPrzedmiotZRzadkoscia.WyswietlInformacje();

        Console.ReadLine();
    }
}
