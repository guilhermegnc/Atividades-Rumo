using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Exercicio3_Desafio.Entities;
using Exercicio3_Desafio.Util;

namespace Exercicio3_Desafio.Services
{
    public class RegisterClient
    {
        private Client _NewClient = new Client();

        public Client GetClient()   // RETORNA O CLIENTE CADASTRADO
        {
            return _NewClient;
        }

        public bool GetName()
        {
            Console.Clear();

            Console.WriteLine("Entre com o seu nome: ");
            string? name = Console.ReadLine();
            bool Validation = Validations.ValidateName(name);

            if (Validation)
            {
                _NewClient.Name = name;
                return true;
            }
            else
            {
                Console.WriteLine("\nAperte uma tecla para continuar: ");
                Console.ReadKey();

                return false;
            }
           
        }

        public bool GetCPF()
        {
            Console.Clear();

            Console.WriteLine("Entre com o seu CPF: ");
            string? CPF = ReadCPF.Read();
            bool Validation = Validations.ValidateCPF(CPF);

            if (Validation)
            {
                Validation = Validations.AlreadyRegistered(CPF);
                if(!Validation) 
                {
                    _NewClient.CPF = CPF;
                    return true;
                }

                else
                {
                    Console.WriteLine("\nAperte uma tecla para continuar: ");
                    Console.ReadKey();

                    return false;
                }
                
            }
            else
            {
                Console.WriteLine("\nAperte uma tecla para continuar: ");
                Console.ReadKey();

                return false;
            }

        }

        public bool GetDateOfBirth()
        {
            Console.Clear();

            Console.WriteLine("Entre com a data de nascimento: ");
            Validations Validation = new Validations();
            Validation = Validations.ValidateDateOfBirth();

            if (Validation.GetValidation())
            {
                _NewClient.DateOfBirth = Validation.GetDate().Date;
                return true;
            }

            else
            {
                Console.WriteLine("\nAperte uma tecla para continuar: ");
                Console.ReadKey();

                return false;
            }
            
        }
    }
}
