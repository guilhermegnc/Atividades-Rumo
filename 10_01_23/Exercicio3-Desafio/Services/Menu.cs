using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio3_Desafio.Services
{
    public class Menu
    {
        public static int MultipleChoice(bool canCancel, params string[] options)
        {
            const int StartY = 3;
            const int LineOption = 1;
            

            int CurrentSelection = 0;

            ConsoleKey key;

            Console.CursorVisible = false;      // CURSOR NÃO APARECER NO CONSOLE

            Console.Clear();

            string Header = "=============  GERENCIAMENTO PETSHOP  =============";
            Console.SetCursorPosition((Console.WindowWidth - Header.Length) / 2, Console.CursorTop); // CURSOR NO MEIO DO CONSOLE
            Console.WriteLine(Header);

            do
            {
                //Console.Clear();

                for (int i = 0; i < options.Length; i++)
                {
                    Console.SetCursorPosition((Console.WindowWidth - options[i].Length) / 2, StartY + i);

                    if (i == CurrentSelection)
                        Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write(options[i]);

                    Console.ResetColor();
                }

                key = Console.ReadKey(true).Key;

                switch (key)    // MOVE PELO MENU USANDO AS SETAS DO TECLADO
                {
                    case ConsoleKey.UpArrow:
                        {
                            if (CurrentSelection >= LineOption)
                                CurrentSelection -= LineOption;
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (CurrentSelection + LineOption < options.Length)
                                CurrentSelection += LineOption;
                            break;
                        }
                    case ConsoleKey.Escape:         // ESC FECHA O PROGRAMA
                        {
                            if (canCancel)
                                return -1;
                            break;
                        }
                }
            } while (key != ConsoleKey.Enter);

            Console.CursorVisible = true;

            return CurrentSelection;
        }
    }
}

