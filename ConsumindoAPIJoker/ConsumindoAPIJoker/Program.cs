using System;

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
                PrintaMenuCategorias();
                int categoria = Convert.ToInt32(Console.ReadLine());
                if (categoria == 0)
                    break;
                PrintaMenuTipo();
                int tipo = Convert.ToInt32(Console.ReadLine());
                if (tipo == 0)
                    break;
            }
            
        }
        private static void PrintaMenuCategorias()
        {
            Console.WriteLine("\nEscolha a categoria de piada de sua preferência:\n");
            Console.WriteLine("[1] Programação\n" +
                "[2] Diversos\n" +
                "[3] Pesado\n" +
                "[4] Trocadilho\n" +
                "[5] Todas\n");
        }
        private static void PrintaMenuTipo()
        {
            Console.WriteLine("\nEscolha o tipo de piada:\n");
            Console.WriteLine("[1] Com pergunta\n" +
                "[2] Sem pergunta\n" +
                "[3] Todos\n");
        }
    }
}
