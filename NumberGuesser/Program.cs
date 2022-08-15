using System;

namespace NumberGuesser
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAppInfo();

            string userName = GetUserName();

            GreetUser(userName);

            Random random = new Random();
            int correctNumber = random.Next(1,11);

            bool correctAnswer = false;

            Console.WriteLine("Zgadnij wylosowana liczbe z przedzialu od 1 do 10");

            while (!correctAnswer)
            {
                string input = Console.ReadLine();

                int guess;

                bool isNumber=int.TryParse(input, out guess);

                if (!isNumber)
                {
                    PrintColorMessage(ConsoleColor.DarkYellow,"Proszę wpisać liczbę");
                    continue;
                }

                if (guess < 1 || guess > 10)
                {
                    PrintColorMessage(ConsoleColor.DarkYellow,"Proszę podać liczbe od 1 do 10");
                    continue;
                }

                if (guess < correctNumber)
                {
                    PrintColorMessage(ConsoleColor.DarkRed,"Błędna odpowiedź, wylosowana liczba jest większa");
                }
                else if (guess > correctNumber)
                {
                    PrintColorMessage(ConsoleColor.DarkRed, "Błędna odpowiedź, wylosowana liczba jest mniejsza");
                }
                else
                {
                    correctAnswer=true;
                    PrintColorMessage(ConsoleColor.DarkGreen, "Brawo prawidłowa odpowiedź");
                }
            }

        }

        static void GetAppInfo()
        {
            string appName = "Zgadywanie liczby";
            int appVersion = 1;
            string appData = "15.08.2022";

            //Console.ForegroundColor = ConsoleColor.DarkMagenta;
            string info = $"[{appName}] Wersja: 0.0.{appVersion}, Data: {appData}";

           PrintColorMessage(ConsoleColor.DarkMagenta, info);

           // Console.ResetColor();
        }

        static string GetUserName()
        {
            Console.WriteLine("Jak masz na imie?");

            string inputUserName = Console.ReadLine();

            return inputUserName;
        }

        static void GreetUser(string userName)
        {
            
            string greet = $"Powodzenia {userName}, odgadnij liczbę...";

            PrintColorMessage(ConsoleColor.DarkBlue,greet);

            
        }

        static void PrintColorMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
    
}

