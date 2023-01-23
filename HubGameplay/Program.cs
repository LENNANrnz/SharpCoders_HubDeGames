using HubDeGames.Entities;
using HubDeGames.View;

namespace HubGameplay
{

    public class Program
    {

        public static void Main()
        {


            string choise;

            Hub.MenuInicial();

            choise = Console.ReadLine();

            switch (choise)
            {
                case "1": 
                    break;
                case "2":
                    Jogador.Cadastrar();
                    break;
                case "3": Jogador.RankingJogodaVelha();
                    break;
                case "0":
                    break;

            }

        }
    }
}