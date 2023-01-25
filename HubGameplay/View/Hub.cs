using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubDeGames.View
{
    public class Hub
    {
        public static void MenuInicial()
        {

            Console.WriteLine("Bem vindo á BugSfot, um lugar para você se divertir.");

            Console.WriteLine();
            Console.WriteLine("1 - Login");
            Console.WriteLine();
            Console.WriteLine("2 - Cadastro");
            Console.WriteLine();
            Console.WriteLine("3 - Listar Todas as Contas");
            Console.WriteLine();
            Console.WriteLine("0 - Fechar Programa");
            Console.WriteLine();
            Console.Write("Escolha uma das opções acima: ");


        }

        public static void MenuDeJogos()
        {

            Console.WriteLine();
            Console.WriteLine("1 - Jogo Da Velha");
            Console.WriteLine();
            Console.WriteLine("2 - Batalha Naval");
            Console.WriteLine();
            Console.WriteLine("0 - Fechar Programa");
            Console.WriteLine();      
            Console.Write("Escolha um dos jogos acima: ");
        }

        public static void JogarNovamente()
        {
            Console.WriteLine();
            Console.WriteLine("1 - Jogar Novamente");
            Console.WriteLine();
            Console.WriteLine("2 - Sair");
            Console.WriteLine();

            Console.Write("Escolha um dos jogos acima: ");

        }


    }
}
