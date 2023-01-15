using Exercicio3_Desafio.Entities;
using Exercicio3_Desafio.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio3_Desafio.Services
{
    public class MonthBirthdays
    {
        private static List<Client> ClientsThatMakeBirthday = new List<Client>();   // LISTA COM OS ANIVERSARIANTES DO MÊS

        public static void ShowClientsThatMakeBirthdayThisMonth(List<Client> clients)
        {
            Console.Clear();

            if (!Validations.HasSomeoneRegistered(clients)) return;

            GetMonthBirthdays(clients);

            if(ClientsThatMakeBirthday.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Não há mais aniversariantes este mês");
                Console.ResetColor();

                return;
            }

            Console.WriteLine("Os seguinte clientes ainda fazem aniversário este mês:\n");

            int i = 3;
            foreach(var client in ClientsThatMakeBirthday)
            {
                Console.Write("{0,0}", client.Name.ToUpper());
                Console.SetCursorPosition(85, i);
                Console.Write($"{client.CPF}");

                var date = client.DateOfBirth.ToString("dd/MM/yyyy");
                Console.WriteLine($"\t{date}");
                i++;
            }
        }

        private static void GetMonthBirthdays(List<Client> clients)
        {
            var Today = DateTime.Now;
            foreach (var client in clients)
            {
                if(Today.Month.Equals(client.DateOfBirth.Month))        // SE FOR O MESMO MÊS
                {
                    if(Today.Day < client.DateOfBirth.Day)              // SE O DIA DE HOJE É MENOR QUE O DIA DO ANIVERSÁRIO
                    {
                        ClientsThatMakeBirthday.Add(client);
                    }
                }
            }
        }


    }
}
