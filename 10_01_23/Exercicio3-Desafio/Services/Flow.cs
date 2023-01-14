using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercicio3_Desafio.Entities;

namespace Exercicio3_Desafio.Services
{
    internal class Flow
    {
        private static int SelectedClass { get; set; }

        
        public static void Caller()
        {
            bool flag = true;
            while (flag)
            {
                SelectedClass = Menu.MultipleChoice(true, "Cadastrar Cliente", "Listar Cliente",
                                                    "Buscar Cliente", "Listar Aniversariantes");

                switch (SelectedClass)
                {
                    case 0:

                        RegisterClient NewClient = new RegisterClient();
                        Client Client = new Client();

                        if (!NewClient.GetName()) break;

                        if (!NewClient.GetCPF()) break;

                        if (!NewClient.GetDateOfBirth()) break;

                        Client = NewClient.GetClient();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Cliente cadastrado com sucesso");
                        Console.ResetColor();
                        Console.WriteLine("\nPressione alguma tecla para continuar");
                        Console.ReadKey();
                        break;


                    case 1:

                        break;

                    case 2:
                        break;

                    case 3:
                        break;

                    case -1:
                        flag = false;
                        Console.Clear();
                        break;
                }
            }
            
        }

    }
}
