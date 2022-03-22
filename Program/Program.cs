using System;

public class Program
{
    static void Main(string[] args)
    {
        bool zakonczenie = false;
        ustawianie_koloru(ConsoleColor.Blue, "Witaj mini kalkulatorze, możesz wykonać tu dodawanie, odejmowanie, dzielenie i mnożenie");
        while (!zakonczenie)
        {
            double x = 0;
            double y = 0;
            int liczba = 0;

            
            ustawianie_koloru(ConsoleColor.White, "Wybierz działanie, które chcesz wykonać:");
            ustawianie_koloru(ConsoleColor.Green, "0.Zakonczenie Programu\n1.Dodawanie\n2.Odejmowanie\n3.Dzielenie\n4.Mnożenie\nWpisz odpowiednią cyfrę.");

            liczba = wczytywanie_1();
            if (liczba != 0)
            {
                ustawianie_koloru(ConsoleColor.DarkRed, "Podaj x: ");
                x = wczytywanie_2();
                ustawianie_koloru(ConsoleColor.DarkRed, "Podaj y: ");
                y = wczytywanie_2();
                obliczanie(liczba, x, y);
            }
            else
            {
                zakonczenie = true;
            }
        }
    }

    static int wczytywanie_1()
    {
        bool cyfra = false;
        int liczba = 0;
        while (!cyfra)
        {
            string input = Console.ReadLine();
            bool isNumber = int.TryParse(input, out liczba);
            if (!isNumber || liczba > 4 || liczba < 0)
            {
                ustawianie_koloru(ConsoleColor.Red, "Podaj poprawną cyfrę 0,1,2,3 lub 4.");
            }
            else
            {
                cyfra = true;
            }
        }
        return liczba;
    }

    static double wczytywanie_2()
    {
        bool cyfra = false;
        double liczba = 0;
        while (!cyfra)
        {
            string input_liczba = Console.ReadLine();
            bool isNumber = double.TryParse(input_liczba, out liczba);
            if (!isNumber)
            {
                ustawianie_koloru(ConsoleColor.Red, "Podaj poprawną cyfrę.");
            }
            else
            {
                cyfra = true;
            }
        }
        return liczba;
    }
    static void obliczanie(int numer, double x, double y)
    {
        if (numer == 1)
        {
            ustawianie_koloru(ConsoleColor.DarkGreen, $"Twoje działanie to: {x}+{y}={dzialania(numer, x, y)}. ");
        }
        if (numer == 2)
        {
            ustawianie_koloru(ConsoleColor.DarkGreen, $"Twoje działanie to: {x}-{y}={dzialania(numer, x, y)}. ");
        }
        if (numer == 3)
        {
            ustawianie_koloru(ConsoleColor.DarkGreen, $"Twoje działanie to: {x}/{y}={dzialania(numer, x, y)}. ");
        }
        if (numer == 4)
        {
            ustawianie_koloru(ConsoleColor.DarkGreen, $"Twoje działanie to: {x}*{y}={dzialania(numer, x, y)}. ");
        }
    }
    static void ustawianie_koloru(ConsoleColor color, string massange)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(massange);
        Console.ResetColor();
    }
    public static double dzialania(int numer, double x, double y)
    {
        if(numer == 1)
        {
            return x + y;
        }
        if(numer == 2)
        {
            return x - y;
        }
        if(numer == 3)
        {
            return x / y;
        }
        else
        {
            return x * y;
        }
    }
}