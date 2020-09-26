using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace ConsumindoAPIJoker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\t\t\tBem vindo(a) ao gerador de piadas aleatórias!!!\n");
            while (true)
            {
                Console.WriteLine("Digite sempre 0 para encerrar!\n");
                string categorias = PrintaMenuCategorias();
                if (categorias == null)
                {
                    break;
                }
                PrintaMenuTipo();
                int tipo = Convert.ToInt32(Console.ReadLine());
                string type = "";
                if (tipo == 0)
                    break;
                else if (tipo == 1)
                {
                    type = "&type=single";
                }
                else if (tipo == 2)
                {
                    type = "&type=twopart";
                }
                else
                {
                    type = "";
                }
                GetData(categorias, type);
                Console.ReadKey();
            }
            
        }

        public static async void GetData(string category, string type)
        {
            HttpClient httpClient = new HttpClient();
            string url = $"https://sv443.net/jokeapi/v2/joke/{category}?blacklistFlags=nsfw,religious,political,racist,sexist{type}";
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            HttpResponseMessage response = await httpClient.SendAsync(request);
            string dados = await response.Content.ReadAsStringAsync();
            Piada piada = JsonConvert.DeserializeObject<Piada>(dados);
            Console.WriteLine($"Categoria: {piada.category}\n");
            Console.WriteLine($"Tipo: {piada.type}\n");
            if (piada.type == "twopart")
            {
                Console.WriteLine($"Pergunta: {piada.setup}\n" +
                    $"Resposta: {piada.delivery}\n"
                    );
            }
            else
            {
                Console.WriteLine($"Piada: {piada.joke}\n");
            }
            Console.WriteLine($"Id: {piada.id}\n");
        }

        private static string PrintaMenuCategorias()
        {
            string categorias = "";
            while (categorias.Length == 0)
            {
                Console.WriteLine("\nEscolha a(s) categoria(s) de piada de sua preferência:\n");
                Console.WriteLine($"A piada pode ser de: ");
                Console.WriteLine("Programação? ");
                string resposta = Console.ReadLine();
                if (resposta.ToLower() == "sim")
                {
                    categorias = "Programming";
                }
                else if(resposta == "0")
                {
                    return null;
                }
                Console.WriteLine("Diversos? ");
                resposta = Console.ReadLine();
                if (resposta.ToLower() == "sim")
                {
                    if (categorias.Length != 0)
                    {
                        categorias += ",";
                    }
                    categorias += "Miscellaneous";
                }
                Console.WriteLine("Pesado?");
                resposta = Console.ReadLine();
                if (resposta.ToLower() == "sim")
                {
                    if (categorias.Length != 0)
                    {
                        categorias += ",";
                    }
                    categorias += "Dark";
                }
                Console.WriteLine("Com trocadilhos?");
                resposta = Console.ReadLine();
                if (resposta.ToLower() == "sim")
                {
                    if (categorias.Length != 0)
                    {
                        categorias += ",";
                    }
                    categorias += "Pun";
                }
            }            
            return categorias;
        }

        private static void PrintaMenuTipo()
        {
            Console.WriteLine("\nEscolha o tipo de piada:\n");
            Console.WriteLine("[1] Sem pergunta\n" +
                "[2] Com pergunta\n" +
                "[3] Todos\n");
        }
    }
}
