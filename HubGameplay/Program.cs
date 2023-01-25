using HubDeGames.Entities;
using HubDeGames.View;
using HubGameplay.Models;
using System.Xml.Schema;

namespace HubGameplay
{

    public class Program
    {

        public static void Main()
        {


            string choise;
            do
            {
                Hub.MenuInicial();

                choise = Console.ReadLine();

                switch (choise)
                {
                    case "1":
                        Playersids player = new Playersids();
                        Jogador.Login(player);
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