using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio3_Desafio.Services
{
    public class ReadCPF
    {
        private static string _CPF = "";

        public static string? Read()
        {
            _CPF = "";

            bool loop = true;
            while (loop)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true); // LE A TECLA APERTADA
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Enter:
                        
                        loop = false;
                        break;

                    case ConsoleKey.Backspace:      // REMOVE O ULTIMO CARACTERE ESCRITO DA STRING E DO CONSOLE

                        if (_CPF.Length >= 1) {
                            _CPF = _CPF.Remove(_CPF.Length - 1, 1);
                            Console.Write("\b");
                            Console.Write(" ");
                            Console.Write("\b");
                        }
                        break;

                    default:
                        if (_CPF.Length == 3 || _CPF.Length == 7 && _CPF.Length < 10) // ADICIONA PONTO AO CPF
                        {
                            _CPF += ".";
                            Console.Write(".");
                        }


                        if (_CPF.Length == 11)  // ADICIONA - AO CPF
                        {
                            _CPF += "-";
                            Console.Write("-"); 
                        }

                        if (_CPF.Length < 14)       // TAMANHO MAXIMO DA STRING, NÃO É POSSÍVEL DIGITAR MAIS
                        {
                            _CPF += keyInfo.KeyChar;
                            Console.Write(keyInfo.KeyChar);
                        }
                        break;
                }
            }
            return _CPF;

        }

    }
}
