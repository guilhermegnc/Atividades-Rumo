using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercicio3_Desafio.Entities;
using Exercicio3_Desafio.Repositories;

namespace Exercicio3_Desafio.Services
{
    public class Flow
    {
        private static int Option { get; set; }
        private static ClientRepositories file = new ClientRepositories();
        private static List<Client> clients = file.GetAllElements(); // CARREGA A LISTA COM OS ELEMENTOS NO CSV

        public static void Caller()
        {
            bool flag = true;
            while (flag)
            {
                Option = Menu.MultipleChoice(true, "Cadastrar Cliente", "Listar Cliente",
                                                    "Buscar Cliente", "Listar Aniversariantes");


                switch (Option)
                {
                    case 0:

                        RegisterClient NewClient = new RegisterClient();
                        Client Client = new Client();

                        if (!NewClient.GetName()) break;

                        if (!NewClient.GetCPF()) break;

                        if (!NewClient.GetDateOfBirth()) break;

                       
                        file.InsertElement(NewClient.GetClient());  // ADICIONA ELEMENTO AO ARQUIVO
                        clients.Add(NewClient.GetClient());         // ADICIONA ELEMENTO À LISTA

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Cliente cadastrado com sucesso");
                        Console.ResetColor();
                        Console.WriteLine("\nPressione alguma tecla para continuar");
                        Console.ReadKey();
                        break;


                    case 1:
                        ListClient.ShowClients(clients);

                        Console.WriteLine("\n\nPressione alguma tecla para continuar");
                        Console.ReadKey();
                        break;

                    case 2:
                        SearchClient.Search(clients);

                        Console.WriteLine("\n\nPressione alguma tecla para continuar");
                        Console.ReadKey();
                        break;

                    case 3:
                        MonthBirthdays.ShowClientsThatMakeBirthdayThisMonth(clients);

                        Console.WriteLine("\n\nPressione alguma tecla para continuar");
                        Console.ReadKey();
                        break;

                    case -1:        // FLAG PARA FECHAMENTO DO PROGRAMA
                        flag = false;
                        Console.Clear();
                        break;
                }
            }
            
        }

    }
}
