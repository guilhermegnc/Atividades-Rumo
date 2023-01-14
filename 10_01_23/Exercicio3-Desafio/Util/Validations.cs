using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio3_Desafio.Util

{
    public class Validations
    { 
        private DateTime _DateReturn { get; set;  }
        private bool _DateBool { get; set;  }

        public static bool ValidateName(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nome Inválido");
                Console.ResetColor();
                return false;
            }

            else if (name.Length >= 3 && name.Length <= 80)
            {
                return true;
            }
                
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nome Inválido");
                Console.ResetColor();
                return false;
            }


        }

        public static bool ValidateCPF(string? cpf) 
        {
            if (string.IsNullOrWhiteSpace(cpf))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("CPF Inválido");
                Console.ResetColor();

                return false;
            }
            else
            {
                cpf = cpf.Replace("-", "");              
                cpf = cpf.Replace(".", "");               
                foreach (char c in cpf)
                {
                    if (c < '0' || c > '9')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nCPF Inválido");
                        Console.ResetColor();

                        return false;
                    }                       
                }                   
            }

            if (cpf.Length != 11)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nCPF Inválido");
                Console.ResetColor();

                return false;
            }

            int Sum = 0;
            int DigitCPF = 0;
            for (int i = 10; i >= 2; i--) 
            {
                Sum += int.Parse(cpf[DigitCPF].ToString()) * i;
                DigitCPF++;
            }

            int Modulus = Sum * 10% 11;
            if (Modulus == 10) Modulus = 0;

            if (cpf[9].ToString().Equals(Modulus.ToString()))
            {
                DigitCPF = 0;
                Sum = 0;
                for (int i = 11; i >= 2; i--)
                {
                    Sum += int.Parse(cpf[DigitCPF].ToString()) * i;
                    DigitCPF++;
                }

                Modulus = Sum * 10 % 11;
                if (Modulus == 10) Modulus = 0;

                if (cpf[10].ToString().Equals(Modulus.ToString()))
                {
                    return true;
                }

            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nCPF Inválido");
            Console.ResetColor();

            return false;



        }

        public static Validations ValidateDateOfBirth()
        {
            Validations ReturnData = new Validations();

            string[] formats = { "dd/MM/yyyy", "dd/M/yyyy", "d/MM/yyyy", "d/M/yyyy",
                                 "dd/MM/yy", "dd/M/yy", "d/MM/yy", "d/M/yy"};
            if (DateTime.TryParseExact(Console.ReadLine(), formats, new CultureInfo("pt-BR"),
                DateTimeStyles.None, out var date))
            {
                DateTime Today = DateTime.Today;
                var Age = Today.Year - date.Year;

                if (date.Date > Today.AddYears(-Age)) Age--;
                
                if (Age < 16)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Idade Mínima para utilização é 16 anos");
                    Console.ResetColor();

                    ReturnData._DateReturn = Convert.ToDateTime("01/01/0001");
                    ReturnData._DateBool = false;
                }
                else if (Age > 120)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Idade Máxima para utilização é 120 anos");
                    Console.ResetColor();

                    ReturnData._DateReturn = Convert.ToDateTime("01/01/0001");
                    ReturnData._DateBool = false;
                }
                else
                {
                    ReturnData._DateReturn = date;
                    ReturnData._DateBool = true;
                }
            
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Data Inválida");
                Console.ResetColor();

                ReturnData._DateReturn = Convert.ToDateTime("01/01/0001");
                ReturnData._DateBool = false;
            }

            return ReturnData;
        }

        public DateTime GetDate()
        {
            return _DateReturn;
        }

        public bool GetValidation()
        {
            return _DateBool;
        }
    }
}
