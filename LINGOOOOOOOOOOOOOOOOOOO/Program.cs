using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace LINGOOOOOOOOOOOOOOOOOOO
{
    internal class Program
    {
        static  void Main(string[] args)
        {
            Console.WriteLine("welkom bij LINGOOOO");
            Console.WriteLine("lingo tutorial? [y/n]");
            ConsoleKeyInfo inputkey = Console.ReadKey();
            if (inputkey.Key == ConsoleKey.Y)
                Tutorial();
            else
                Lingo();
        }
        public static void Lingo()
        {
            Console.Clear();
            int kanzen = 5;
            string filepath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            filepath += @"\woorden.txt";
            TextReader t = new StreamReader(filepath);
            string tr = t.ReadLine();
            string[] splitw = tr.Split(' ');
            Random randomwoord = new Random();
            string gekozenwoord = splitw[randomwoord.Next(0, splitw.Length -1)];
            char[] geradenwoord = new char[5];
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(gekozenwoord[0]);
            for (int i = 1; i < gekozenwoord.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("#");
            }
            Console.WriteLine();
            while(kanzen > 0)
            {
                string input = Console.ReadLine();
                Console.Write(new string(' ', Console.WindowWidth));
                if(input.Length == gekozenwoord.Length)
                {
                    Check(input, gekozenwoord, geradenwoord);
                    kanzen--;
                }
                else if (input.Length < gekozenwoord.Length || input.Length > gekozenwoord.Length)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("DIT IS GÉÉN 5 LETTER WOORD!\nDruk op een toets om verder te gaan");
                    Console.ReadKey();
                    Console.Write(new String(' ', Console.WindowWidth));
                    Console.ForegroundColor = ConsoleColor.White;
                    //Check(input, gekozenwoord, geradenwoord);
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(geradenwoord);
                if (input != gekozenwoord && kanzen > 0)
                {
                    Console.WriteLine("Je kan nog " + kanzen + "x raden\n");
                }
                if(input == gekozenwoord && kanzen > 0)
                {
                    
                    Console.WriteLine("Gefeliciteerd je hebt lingo gewonnen!\nOpnieuw spelen? [y/n]");
                    ConsoleKeyInfo inputkey = Console.ReadKey();
                    if (inputkey.Key == ConsoleKey.Y)
                        Lingo();
                    else
                        Environment.Exit(0);
                }
            }
            if(kanzen == 0)
            {
                Console.WriteLine("Helaas je hebt lingo gefaalt.\nHet woord was: " + gekozenwoord + "\nOpnieuw spelen? [y/n]");
                ConsoleKeyInfo inputkey = Console.ReadKey();
                if (inputkey.Key == ConsoleKey.Y)
                    Lingo();
                else
                    Environment.Exit(0);
            }
        }
        public static void Tutorial()
        {
            Console.WriteLine("Lingo(tm) is super cool " +
                "\nJe moet een nederlands 5 letter woord raden \nAls een letter geel is is het goed maar niet op de goede plek " +
                "\nAls een letter blauw is is het op de goed plek " +
                "\nEn als een letter rood is is het fout" +"\nDruk op een toets om verder te gaan");
            Console.ReadKey();
            Lingo();
        }
        public static void Check(string input, string gekozenwoord, char[] geradenwoord)
        {
            List<char> letters = new List<char>();
            for (int i = 0; i < input.Length && input.Length == gekozenwoord.Length; i++)
            {
                if (input[i] == gekozenwoord[i])
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(input[i]);
                    if (i <= 0)
                    {
                        geradenwoord[i] = gekozenwoord[i];
                        letters.Add(input[i]);
                    }
                    else
                        geradenwoord[i] = input[i];
                }
                else if (input[i] != gekozenwoord[i] && gekozenwoord.Contains(input[i]) && !letters.Contains(input[i]))
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(input[i]);
                    geradenwoord[i] = '#';
                }
                else if (input[i] != gekozenwoord[i] && !gekozenwoord.Contains(input[i]))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(input[i]);
                    geradenwoord[i] = '#';
                }
                
            }
        }
    }
}