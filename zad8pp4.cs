using System;

enum Plec
{
    Mezczyzna,
    Kobieta
}

struct Student
{
    public string Nazwisko;
    public int NrAlbumu;
    public double Ocena;
    public Plec Plec;

    public void WypelnijStudenta(string nazwisko, int nrAlbumu, double ocena, Plec plec)
    {
        Nazwisko = nazwisko;
        NrAlbumu = nrAlbumu;
        Ocena = Math.Max(2.0, Math.Min(5.0, ocena)); // Ustawienie oceny w zakresie 2.0 - 5.0
        Plec = plec;
    }

    public void WyswietlInformacje()
    {
        Console.WriteLine($"Student: {Nazwisko}, Nr albumu: {NrAlbumu}, Ocena: {Ocena}, Płeć: {Plec}");
    }
}

class Program
{
    static double ObliczSrednia(Student[] grupa)
    {
        if (grupa.Length == 0)
            return 0.0;

        double suma = 0.0;
        foreach (var student in grupa)
        {
            suma += student.Ocena;
        }

        return suma / grupa.Length;
    }

    static void Main(string[] args)
    {
        Student[] grupa = new Student[5];

        grupa[0].WypelnijStudenta("Kowalski", 1234, 4.5, Plec.Mezczyzna);
        grupa[1].WypelnijStudenta("Nowak", 5678, 3.2, Plec.Kobieta);
        grupa[2].WypelnijStudenta("Smith", 9012, 2.7, Plec.Mezczyzna);
        grupa[3].WypelnijStudenta("Johnson", 3456, 5.0, Plec.Kobieta);
        grupa[4].WypelnijStudenta("Gonzalez", 7890, 2.1, Plec.Mezczyzna);

        foreach (var student in grupa)
        {
            student.WyswietlInformacje();
        }

        double srednia = ObliczSrednia(grupa);
        Console.WriteLine($"Średnia ocen w grupie: {srednia}");

        Console.ReadLine();
    }
}
