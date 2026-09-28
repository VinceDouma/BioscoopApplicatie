
using System;

class Program
{
    // Method 1: Naam vragen
    static string VraagNaam()
    {
        Console.Write("Wat is je naam? ");
        return Console.ReadLine();
    }

    // Method 2: Leeftijd vragen
    static int VraagLeeftijd()
    {
        int leeftijd;

        while (true)
        {
            Console.Write("Hoe oud ben je? ");

            if (int.TryParse(Console.ReadLine(), out leeftijd))
            {
                return leeftijd;
            }

            Console.WriteLine("Voer een geldig getal in.");
        }
    }

    // Method 3: Film kiezen
    static string KiesFilm()
    {
        string[] films = { "Avengers", "Toy Story", "Maze Runner" };

        Console.WriteLine();
        Console.WriteLine("Kies een film:");

        // For-lus
        for (int i = 0; i < films.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {films[i]}");
        }

        int choice;

        while (true)
        {
            Console.Write("Kies een film: ");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                if (choice >= 1 && choice <= films.Length)
                {
                    break;
                }
            }

            Console.WriteLine("Kies een nummer van 1 tot 3.");
        }

        
        switch (choice)
        {
            case 1:
                return "Avengers";

            case 2:
                return "Toy Story";

            case 3:
                return "Maze Runner";

            default:
                return "";
        }
    }

    // Method 4: Aantal kaartjes vragen
    static int VraagKaartjes()
    {
        int kaartjes;

        while (true)
        {
            Console.Write("Hoeveel kaartjes wil je? (1-8): ");

            if (int.TryParse(Console.ReadLine(), out kaartjes))
            {
                if (kaartjes >= 1 && kaartjes <= 8)
                {
                    return kaartjes;
                }
            }

            Console.WriteLine("Je moet tussen de 1 en 8 kaartjes kiezen.");
        }
    }

    // Method 5: Student vragen
    static bool VraagStudent()
    {
        while (true)
        {
            Console.Write("Ben je een student? (ja/nee): ");
            string studentchoice = Console.ReadLine().ToLower();

            if (studentchoice == "ja")
            {
                return true;
            }
            else if (studentchoice == "nee")
            {
                return false;
            }

            Console.WriteLine("Voer ja of nee in.");
        }
    }

    // Overloaded method 1: normale prijs
    static double BerekenPrijs(int kaartjes)
    {
        return kaartjes * 10;
    }

    // Overloaded method 2: prijs met studentenkorting
    static double BerekenPrijs(int kaartjes, bool student)
    {
        double prijs = kaartjes * 10;

        if (student)
        {
            prijs = prijs * 0.80;
        }

        return prijs;
    }

    // Method 6: Reserveringsoverzicht
    static void ToonOverzicht(string naam, int leeftijd, string film,
                              int kaartjes, bool student, double prijs)
    {
        Console.WriteLine();
        Console.WriteLine("===== RESERVERINGSOVERZICHT =====");
        Console.WriteLine($"Naam: {naam}");
        Console.WriteLine($"Leeftijd: {leeftijd}");
        Console.WriteLine($"Film: {film}");
        Console.WriteLine($"Aantal kaartjes: {kaartjes}");
        Console.WriteLine($"Student: {(student ? "Ja" : "Nee")}");
        Console.WriteLine($"Prijs: ${prijs:F2}");
        Console.WriteLine("================================");
    }

    // Method 7: Vragen of er nog een reservering komt
    static bool NogEenReservering()
    {
        while (true)
        {
            Console.Write("Wil je nog een reservering maken? (ja/nee): ");
            string antwoord = Console.ReadLine().ToLower();

            if (antwoord == "ja")
            {
                return true;
            }
            else if (antwoord == "nee")
            {
                return false;
            }

            Console.WriteLine("Voer ja of nee in.");
        }
    }

    static void Main()
    {
        bool opnieuw = true;

        Console.WriteLine("Welkom");

        // While-lus voor meerdere reserveringen
        while (opnieuw)
        {
            // 1. Naam vragen
            string naam = VraagNaam();

            // 2. Leeftijd vragen
            int leeftijd = VraagLeeftijd();

            if (leeftijd >= 18)
            {
                Console.WriteLine("Je bent oud genoeg.");
            }
            else
            {
                Console.WriteLine("Je bent te jong.");
                return;
            }

            // 3. Film kiezen
            string film = KiesFilm();

            // 7. Aantal kaartjes
            int kaartjes = VraagKaartjes();

            // 8. Student
            bool student = VraagStudent();

            // 9. Prijs berekenen
            double prijs;

            if (student)
            {
                prijs = BerekenPrijs(kaartjes, student);
            }
            else
            {
                prijs = BerekenPrijs(kaartjes);
            }

            // 10. Overzicht
            ToonOverzicht(naam, leeftijd, film, kaartjes, student, prijs);

            // 11. Nog een reservering?
            opnieuw = NogEenReservering();

            Console.WriteLine();
        }

        Console.WriteLine("Bedankt voor je reservering!");
    }
}


