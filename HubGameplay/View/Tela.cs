using System;
using tabuleiro;
using xadrez;
using System.Collections.Generic;
using HubGameplay.Models;
using HubDeGames.Entities;
using System.Text.Json;
using System.Numerics;

namespace Xadrez_console
{
    class Tela
    {
        public static void imprimirPartida(PartidaXadrez partida)
        {
            string arquivojson = @"D:\Minhas coisas\Projetos viasula studio\SharpCoders\Projeto HubDeJogos\SharpCoders_HubDeGames\HubGameplay\Players.json";
            var option = new JsonSerializerOptions { WriteIndented = true };
            string jsonlines = File.ReadAllText(arquivojson);
            List<Jogador>? lista;
            lista = System.Text.Json.JsonSerializer.Deserialize<List<Jogador>>(jsonlines, option);


            imprimirTabuleiro(partida.tab);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.turno);
            if (!partida.terminada)
            {   
                if(partida.jogadorAtual == Cor.Branco)
                {
                    Console.WriteLine($"Aguardando cor {partida.jogadorAtual}, {lista[partida.playersssids1].Nickname}, jogar.") ;
                }
                else
                {
                    Console.WriteLine($"Aguardando cor {partida.jogadorAtual}, {lista[partida.playersssids2].Nickname}, jogar.");
                }
               
                if (partida.xeque)
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("XEQUE!");
                    Console.ForegroundColor = aux;
                }
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("XEQUEMATE!");
                Console.ForegroundColor = aux;
                Console.WriteLine("Vencedor: " + partida.jogadorAtual);
                if (partida.jogadorAtual == Cor.Branco)
                {
                    lista[partida.playersssids1].PontosTotaisXadrez += 1;
                    string playerjson = System.Text.Json.JsonSerializer.Serialize(lista, option);
                    File.WriteAllText(arquivojson, playerjson);
                }
                else
                {
                    lista[partida.playersssids2].PontosTotaisXadrez += 1;
                    string playerjson = System.Text.Json.JsonSerializer.Serialize(lista, option);
                    File.WriteAllText(arquivojson, playerjson);
                }

            }
        }



        public static void imprimirPecasCapturadas(PartidaXadrez partida)
        {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branco));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            imprimirConjunto(partida.pecasCapturadas(Cor.Preto));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (Peca x in conjunto)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }

        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.linhas; i++)
            {
                ConsoleColor aux1 = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(8 - i + " ");
                Console.ForegroundColor = aux1;

                for (int j = 0; j < tab.colunas; j++)
                {
                    imprimirPeca(tab.peca(i, j));
                }
                Console.WriteLine();
            }
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("  A B C D E F G H");
            Console.ForegroundColor = aux;
        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.linhas; i++)
            {
                ConsoleColor aux1 = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(8 - i + " ");
                Console.ForegroundColor = aux1;

                for (int j = 0; j < tab.colunas; j++)
                {
                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }

                    imprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("  A B C D E F G H");
            Console.ForegroundColor = aux;
            Console.BackgroundColor = fundoOriginal;
        }

        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        public static void imprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.cor == Cor.Branco)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
