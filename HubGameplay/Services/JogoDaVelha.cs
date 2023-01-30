using HubDeGames.Entities;
using HubDeGames.View;
using HubGameplay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HubDeGames.Services
{
    public class JogoDaVelha
    {
        public static void PlayJogoDaVelha(Playersids player)
        {

            string arquivojson = @"D:\Minhas coisas\Projetos viasula studio\SharpCoders\Projeto HubDeJogos\SharpCoders_HubDeGames\HubGameplay\Players.json";
            var option = new JsonSerializerOptions { WriteIndented = true };
            string jsonlines = File.ReadAllText(arquivojson);
            List<Jogador>? lista;
            lista = System.Text.Json.JsonSerializer.Deserialize<List<Jogador>>(jsonlines, option);

            string[] jogo = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
            string valorMarcado;
            bool player1win = false;
            bool player2win = false;
            bool empate = false;
            int contadorponto = 1;



            for (int i = 0; i <= 9; i++)
            {
                Console.Clear();
                Console.Write(
                       $"__{jogo[0]}__|__{jogo[1]}__|__{jogo[2]}__\n" +
                       $"__{jogo[3]}__|__{jogo[4]}__|__{jogo[5]}__\n" +
                       $"  {jogo[6]}  |  {jogo[7]}  |  {jogo[8]}  \n\n");

                if (jogo[0] == jogo[1] && jogo[0] == jogo[2] || jogo[3] == jogo[4] && jogo[3] == jogo[5] ||
                    jogo[6] == jogo[7] && jogo[6] == jogo[8] || jogo[0] == jogo[3] && jogo[0] == jogo[6] ||
                    jogo[1] == jogo[4] && jogo[1] == jogo[7] || jogo[2] == jogo[5] && jogo[2] == jogo[8] ||
                    jogo[2] == jogo[4] && jogo[2] == jogo[6] || jogo[0] == jogo[4] && jogo[0] == jogo[8]
                    )
                {

                    //Mostra o se houve guanhador ou empate

                    if (i % 2 != 0)
                    {
                        Console.WriteLine($"o ganhador é {lista[player.id1].Nickname}");
                        player1win = true;
                        break;
                    }
                    else if (i % 2 == 0)
                    {
                        Console.WriteLine($"o ganhador é {lista[player.id2].Nickname}");
                        player2win = true;
                        break;
                    }

                }
                else if (i == 9)
                {
                    Console.WriteLine("EMPATE");
                    empate = true;
                    break;
                }

                //mostra a vez da pessoa

                if (i % 2 == 0)
                {
                    Console.Write($"Sua vez {lista[player.id1].Nickname},digite o numero que deseja marcar o X: ");
                    valorMarcado = Console.ReadLine();

                    while (valorMarcado != "0" && valorMarcado != "1" && valorMarcado != "2" && valorMarcado != "3" && valorMarcado != "4"
                    && valorMarcado != "5" && valorMarcado != "6" && valorMarcado != "7" && valorMarcado != "8")
                    {
                        Console.Write("Valor inválido, digite novamente um número válido :");
                        valorMarcado = Console.ReadLine();

                    };

                    int j = int.Parse(valorMarcado);

                    //mostra quando quadrado ja está selecinado

                    if (jogo[j] == "X")
                    {
                        while (jogo[j] == "X")
                        {
                            Console.Write("Quadrado já selecionado, digite um quadrado disponível: ");
                            valorMarcado = Console.ReadLine();
                            j = int.Parse(valorMarcado);
                        }
                    }

                    if (jogo[j] == "O")
                    {
                        while (jogo[j] == "O")
                        {

                            Console.Write("Quadrado já selecionado, digite um quadrado disponível: ");
                            valorMarcado = Console.ReadLine();
                            j = int.Parse(valorMarcado);

                        };
                        jogo[j] = "X";
                    }
                    else
                    {
                        jogo[j] = "X";
                    }


                }

                //mostra a vez da pessoa

                else if (i % 2 != 0)
                {
                    Console.Write($"Sua vez {lista[player.id2].Nickname},digite o numero que deseja marcar o O: ");
                    valorMarcado = Console.ReadLine();
                    while (valorMarcado != "0" && valorMarcado != "1" && valorMarcado != "2" && valorMarcado != "3" && valorMarcado != "4"
                  && valorMarcado != "5" && valorMarcado != "6" && valorMarcado != "7" && valorMarcado != "8")
                    {
                        Console.Write("Valor inválido, digite novamente um número válido :");
                        valorMarcado = Console.ReadLine();
                    };
                    int j = int.Parse(valorMarcado);

                    //mostra quando quadrado ja está selecinado

                    if (jogo[j] == "O")
                    {
                        while (jogo[j] == "O")
                        {
                            Console.Write("Quadrado já selecionado, digite um quadrado disponível: ");
                            valorMarcado = Console.ReadLine();
                            j = int.Parse(valorMarcado);
                        }
                    }

                    if (jogo[j] == "X")
                    {
                        while (jogo[j] == "X")
                        {

                            Console.WriteLine("Quadrado já selecionado, digite um quadrado disponível: ");
                            valorMarcado = Console.ReadLine();
                            j = int.Parse(valorMarcado);

                        };
                        jogo[j] = "O";
                    }
                    else
                    {
                        jogo[j] = "O";
                    }
                }
            }
            Console.WriteLine();


            //Contador tabela

            if (player1win == true)
            {
                lista[player.id1].PontosTotaisJogodaVelha += contadorponto;
                string playerjson = System.Text.Json.JsonSerializer.Serialize(lista, option);
                File.WriteAllText(arquivojson, playerjson);

            }
            else if (player2win == true)
            {
                lista[player.id2].PontosTotaisJogodaVelha += contadorponto;
                string playerjson = System.Text.Json.JsonSerializer.Serialize(lista, option);
                File.WriteAllText(arquivojson, playerjson);

            }

            string choise;
            do
            {
                Hub.Menuvoltar();
                choise = Console.ReadLine();
                switch (choise)
                {
                    case "1":
                        Jogador.RankingJogodaVelha();
                        break;
                    case "0": 
                        return;
                }
            } while (choise != "0");






        }

    }
}
