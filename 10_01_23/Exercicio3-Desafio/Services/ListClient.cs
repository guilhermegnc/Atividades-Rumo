using Exercicio3_Desafio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.PortableExecutable;
using Exercicio3_Desafio.Util;

namespace Exercicio3_Desafio.Services
{
    public class ListClient
    {
        public static void ShowClients(List<Client> clients)
        {
            Console.Clear();

            if (!Validations.HasSomeoneRegistered(clients)) return;

            int i = 3;
            string date;
            string Header = "================================ Lista de todos os clientes ================================";
            Console.SetCursorPosition((Console.WindowWidth - Header.Length) / 2, Console.CursorTop);
            Console.WriteLine($"{Header}\n\n");

            foreach (var client in clients)
            {
                Console.Write("{0,0}", client.Name.ToUpper());
                Console.SetCursorPosition(85, i);
                Console.Write($"{client.CPF}");

                date = client.DateOfBirth.ToString("dd/MM/yyyy");
                Console.WriteLine($"\t{date}");
                i++;
            }
        }
    }
}
