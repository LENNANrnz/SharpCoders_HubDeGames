using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubDeGames.Services
{
    public class JogoDaVelha
    {
        public void PlayJogoDaVelha(int player1id, int player2id)
        {

            string[] jogo = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
            string valorMarcado;
            bool player1win = false;
            bool player2win = false;
            bool empate = false;
            int contadorponto = 1;
            int ContaEmpate = 0;
            int contadopontopl1 = 0;
            int contadopontopl2 = 0;


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
                        Console.WriteLine($"o ganhador é  ");
                        player1win = true;
                        break;
                    }
                    else if (i % 2 == 0)
                    {
                        Console.WriteLine($"o ganhador é  ");
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
                    Console.Write($"Sua vez  ,digite o numero que deseja marcar o X: ");
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
                    Console.Write($"Sua vez,digite o numero que deseja marcar o O: ");
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


            }
            else if (player2win == true)
            {


            }
            string choise;
            do
            {
                choise = Console.ReadLine();
            } while (choise != "0");




        }

    }
}
