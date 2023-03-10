using HubDeGames.Entities;
using HubDeGames.Services;
using HubDeGames.View;
using HubGameplay.Models;
using HubGameplay.Services;
using System.Xml.Schema;
using Xadrez_console;

namespace HubGameplay
{

    public class Program
    {

        public static void Main()
        {
           
           

            
            Playersids player = new Playersids();
            string choise;
            do
            {
                Hub.MenuInicial();

                choise = Console.ReadLine();

                switch (choise)
                {
                    case "1":
                        Jogador.Login(player);
                        if (player.logou == true)
                        {
                            do
                            {
                                Hub.MenuDeJogos();
                                choise = Console.ReadLine();

                                switch (choise)
                                {
                                    case "1": JogoDaVelha.PlayJogoDaVelha(player);
                                        break;
                                    case "2":
                                        BatalhaNaval.PlayBatalhaNaval(player);
                                        break;
                                        case "3": ChessGame.PlayChesGame(player);
                                        break;
                                    case "0": Environment.Exit(0);
                                        break;
                                }
                            } while (choise != "0");
                        }
                        break;
                    case "2":
                        Jogador.Cadastrar();
                        break;
                    case "3":
                        Jogador.ListarContas();
                        break;
                    case "0":
                        break;

                }

            } while (choise != "0");
           

        }
    }
}