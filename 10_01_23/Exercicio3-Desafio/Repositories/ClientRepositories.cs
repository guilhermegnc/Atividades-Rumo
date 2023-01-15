using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Exercicio3_Desafio.Entities;

namespace Exercicio3_Desafio.Repositories
{
    public class ClientRepositories
    {
        private readonly string _Filepath = GetSolutionDirectory();
        private List<Client> ListClients = new List<Client>();

        public ClientRepositories()
        {
            try
            {
                if (!File.Exists(_Filepath))
                {
                    var file = File.Create(_Filepath);
                    file.Close();
                }
            }
            catch   // ERRO NO CAMINHO, PRÓVAVEL QUE PASTA DE DATASET NÃO EXISTE NO DIRETÓRIO DA SOLUÇÃO
            {
                Directory.CreateDirectory(GetSolutionDirectory(null, false));
                var file = File.Create(_Filepath);
                file.Close();
            }
            
        }

        public void InsertElement(Client client)
        {
            var sw = new StreamWriter(_Filepath, true);
            sw.WriteLine($"{client.Name};{client.CPF};{client.DateOfBirth}");
            sw.Close();
        }

        public void RemoveElement(string cpf)       // REMOVE UM ELEMENTO DO ARQUIVO
        {
            string[] values = File.ReadAllLines(_Filepath);
            var sw = new StreamWriter(_Filepath, false);

            for (int i = 0; i < values.Length; i++)
            {
                if (!values[i].Contains(cpf))
                {
                    sw.WriteLine(values[i]);
                }
            }
            sw.Close();

            ListClients.RemoveAll(x => x.CPF.Equals(cpf)); // REMOVE O ELEMENTO
            InsertList();                                  // REESCREVE O ARQUIVO
        }

        public List<Client> GetAllElements()
        {
            GetFileElements();

            return ListClients;
        }

        private void GetFileElements()
        {
            var sr = new StreamReader(_Filepath);

            while(true)
            {
                var line = sr.ReadLine();

                if (line == null) break;

                ListClients.Add(LineTextToClient(line));
            }

            sr.Close();

        }

        private void InsertList()
        {
            var sw = new StreamWriter(_Filepath, true);

            foreach (var client in ListClients)
            {
                sw.WriteLine($"{client.Name};{client.CPF};{client.DateOfBirth.Date}");
                sw.Close();
            }
        }

        private Client LineTextToClient(string line)
        {
            var columns = line.Split(';');

            Client client = new Client();

            client.Name = columns[0];
            client.CPF = columns[1];
            client.DateOfBirth = DateTime.Parse(columns[2]);

            return client;
        }

        private static string GetSolutionDirectory(string? currentPath = null, bool csv = true) // RETORNA O DIRETÓRIO ONDE
        {                                                                      // ESTÁ A SOLUÇÃO DO PROJETO
            var dir = new DirectoryInfo(
                currentPath ?? Directory.GetCurrentDirectory());
            while (dir != null && !dir.GetFiles("*.sln").Any())
            {
                dir = dir.Parent;
            }

            string Path = dir.ToString();
            if(csv)          
                Path += "\\Datasets\\Clients.csv";
            else
                Path += "\\Datasets";

            return Path;
        }
    }
}
