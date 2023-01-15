using Exercicio3_Desafio.Util;
using Exercicio3_Desafio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio3_Desafio.Services
{
    public class SearchClient
    {
        private static string? cpf;

        public static void Search(List<Client> clients)
        {
            Console.Clear();

            if (!Validations.HasSomeoneRegistered(clients)) return;

            bool ValidatedCPF = GetCPF();
            if (!ValidatedCPF) return;

            foreach (var client in clients)
            {
                if(cpf.Equals(client.CPF))
                {
                    Console.Clear();
                    Console.WriteLine("Resultado da busca:\n");
                    Console.WriteLine($"Nome do cliente: {client.Name.ToUpper()}");
                    Console.WriteLine($"CPF do cliente: {client.CPF}");
                    Console.WriteLine($"Data de Nascimento do cliente: {client.DateOfBirth.ToString("dd/MM/yyyy")}");

                    return;
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nCliente não encontrado");
            Console.ResetColor();
        }

        private static bool GetCPF()
        {
            Console.Clear();
            Console.WriteLine("Entre com o CPF: ");
            string? tempCPF = ReadCPF.Read();
            bool Validation = Validations.ValidateCPF(tempCPF);
            if (Validation)
            {
                Validation = Validations.AlreadyRegistered(tempCPF, false);
                if (Validation)
                {
                    cpf = tempCPF;
                    return true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nCPF não cadastrado");
                    Console.ResetColor();

                    return false;
                }
            }

            return false;
        }
    }
}
