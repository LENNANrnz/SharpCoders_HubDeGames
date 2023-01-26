using HubDeGames.Entities;
using HubDeGames.View;
using HubGameplay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HubGameplay.Services
{

    struct Point
    {
        public int X;
        public int Y;
    }
    public class BatalhaNaval
    {
        public static void DisplayBoard(char[,] board)
        {
            Console.WriteLine("   0 1 2 3 4 5 6 7 8 9");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(i + " |");
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(board[i, j] + "|");
                }
                Console.WriteLine();
            }
        }
        public static void PlayBatalhaNaval(Playersids jogadorezz)
        {
            string arquivojson = @"D:\\Minhas coisas\\Projetos viasula studio\\SharpCoders\\ProjetoHubDeJogos\\HubGameplay\\HubGameplay\\Players.json";
            var option = new JsonSerializerOptions { WriteIndented = true };
            string jsonlines = File.ReadAllText(arquivojson);
            List<Jogador>? lista;
            lista = System.Text.Json.JsonSerializer.Deserialize<List<Jogador>>(jsonlines, option);

            // Initialize the game board
            char[,] gameBoard = new char[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    gameBoard[i, j] = '-';
                }
            }

            // Place the player's ships
            PlaceShip(gameBoard, 5, lista[jogadorezz.id1].Nickname);
            PlaceShip(gameBoard, 4, lista[jogadorezz.id2].Nickname);

            // Place the computer's ships
            PlaceShip(gameBoard, 3, "Máquina");

            // Game loop
            while (true)
            {
                // Display the game board
                DisplayBoard(gameBoard);

                // Get player 1's guess
                Console.WriteLine($"{lista[jogadorezz.id1].Nickname}, digite seu palpite (linha coluna): ");
                int row = int.Parse(Console.ReadLine());
                int col = int.Parse(Console.ReadLine());

                // Check if the guess is a hit or miss
                if (gameBoard[row, col] != '-')
                {
                    Console.WriteLine("ACERTOU!");
                    gameBoard[row, col] = 'H';
                }
                else
                {
                    Console.WriteLine("ERROU!");
                    gameBoard[row, col] = 'M';
                }

                // Get player 2's guess
                Console.WriteLine($"{lista[jogadorezz.id2].Nickname}, digite seu palpite (linha coluna): ");
                row = int.Parse(Console.ReadLine());
                col = int.Parse(Console.ReadLine());
                // Check if the guess is a hit or miss
                if (gameBoard[row, col] != '-')
                {
                    Console.WriteLine("ACERTOU!");
                    gameBoard[row, col] = 'H';
                }
                else
                {
                    Console.WriteLine("ERROU!");
                    gameBoard[row, col] = 'M';
                }

                // Computer's turn to guess
                Random rand = new Random();
                row = rand.Next(0, 10);
                col = rand.Next(0, 10);
                Console.WriteLine("Máquina achou " + row + " " + col);

                // Check if the guess is a hit or miss
                if (gameBoard[row, col] != '-')
                {
                    Console.WriteLine("ACERTOU!");
                    gameBoard[row, col] = 'H';
                }
                else
                {
                    Console.WriteLine("ERROU!");
                    gameBoard[row, col] = 'M';
                }

                // Check if all ships have been sunk
                int player1Ships = 0;
                int player2Ships = 0;
                int computerShips = 0;

                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (gameBoard[i, j] == 'S')
                        {
                            if (i < 5)
                                player1Ships++;
                            else
                                player2Ships++;
                        }
                        if (gameBoard[i, j] == 'C')
                            computerShips++;
                    }
                }

                if (player1Ships == 0 && player2Ships == 0)
                {
                    Console.WriteLine($"{lista[jogadorezz.id1].Nickname} e {lista[jogadorezz.id2].Nickname} ganharam!");
                    lista[jogadorezz.id1].PontosTotaisBatalhaNaval += 1;
                    lista[jogadorezz.id2].PontosTotaisBatalhaNaval += 1;
                    break;
                }
                else if (computerShips == 0)
                {
                    Console.WriteLine($"{lista[jogadorezz.id1].Nickname} e {lista[jogadorezz.id2].Nickname} perderam!");
                    break;
                }
            }

            string esolha;
            do
            {
                Hub.Menuvoltar();
                esolha = Console.ReadLine();
                switch (esolha)
                {
                    case "1":
                        Jogador.RankingBatalhaNaval();
                        break;
                    case "0":
                        return;
                }
            } while (esolha != "0");
        }

        static void PlaceShip(char[,] board, int length, string player)
        {
            Random rand = new Random();
            int row = rand.Next(0, 10);
            int col = rand.Next(0, 10);
            int direction = rand.Next(0, 2);

            if (direction == 0)
            {
                if (row + length > 10)
                {
                    Console.WriteLine(player + ": O navio não cabe no tabuleiro. Gerando novo local...");
                    PlaceShip(board, length, player);
                    return;
                }

                for (int i = row; i < row + length; i++)
                {
                    if (player == "Máquina")
                        board[i, col] = 'C';
                    else
                        board[i, col] = 'S';
                }
            }
            else
            {
                if (col + length > 10)
                {
                    Console.WriteLine(player + ": O navio não cabe no tabuleiro. Gerando novo local...");
                    PlaceShip(board, length, player);
                    return;
                }
            }
            for (int i = col; i < col + length; i++)
            {
                if (player == "Máquina")
                    board[row, i] = 'C';
                else
                    board[row, i] = 'S';
            }
        }
    }


}
















