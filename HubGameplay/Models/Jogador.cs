using HubDeGames.Services;
using HubGameplay.Models;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace HubDeGames.Entities
{
    public class Jogador
    {

        protected Jogador(in object value)
        {
        }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Nickname { get; set; }
        public int PontosTotaisJogodaVelha { get; set; }
        public int PontosTotaisBatalhaNaval { get; set; }
        public int PontosTotaisXadrez { get; set; }

        public Jogador() { }

        public Jogador(string nome, string senha, string nickname)
        {
            Nome = nome;
            Senha = senha;
            Nickname = nickname;

        }

        public struct Result
        {
            public int value1;
            public int value2;
        }

        public static void RankingJogodaVelha()
        {
            string arquivojson = @"D:\Minhas coisas\Projetos viasula studio\SharpCoders\Projeto HubDeJogos\SharpCoders_HubDeGames\HubGameplay\Players.json";
            var option = new JsonSerializerOptions { WriteIndented = true };
            string jsonlines = File.ReadAllText(arquivojson);
            List<Jogador>? lista;
            lista = System.Text.Json.JsonSerializer.Deserialize<List<Jogador>>(jsonlines, option);

            
            var ranking = lista.OrderByDescending(o => o.PontosTotaisJogodaVelha);

            int count = 1;
            foreach (var item in ranking)
            {
                Console.WriteLine(count + ". " + item.Nickname + " - Pontos: " + item.PontosTotaisJogodaVelha);
                count++;
            }



        }

        public static void RankingBatalhaNaval()
        {
            string arquivojson = @"D:\Minhas coisas\Projetos viasula studio\SharpCoders\Projeto HubDeJogos\SharpCoders_HubDeGames\HubGameplay\Players.json";
            var option = new JsonSerializerOptions { WriteIndented = true };
            string jsonlines = File.ReadAllText(arquivojson);
            List<Jogador>? lista;
            lista = System.Text.Json.JsonSerializer.Deserialize<List<Jogador>>(jsonlines, option);


            var ranking = lista.OrderByDescending(o => o.PontosTotaisBatalhaNaval);

            int count = 1;
            foreach (var item in ranking)
            {
                Console.WriteLine(count + ". " + item.Nickname + " - Pontos: " + item.PontosTotaisBatalhaNaval);
                count++;
            }
        }
      
        public static void Login(Playersids playerid)
        {
            string arquivojson = @"D:\Minhas coisas\Projetos viasula studio\SharpCoders\Projeto HubDeJogos\SharpCoders_HubDeGames\HubGameplay\Players.json";
            string nome, senha, nickname;
            var option = new JsonSerializerOptions { WriteIndented = true };
            string jsonlines = File.ReadAllText(arquivojson);
            List<Jogador>? lista;
            lista = System.Text.Json.JsonSerializer.Deserialize<List<Jogador>>(jsonlines, option);
            string nameplayer1, nameplayer2, passwordplayer1, passwordplayer2;
            int z = 0;
            int y = 0;

            // Login player 1
            Console.Write("Digite o nome de usuário do player 1: ");
            nameplayer1 = Console.ReadLine();

            var result = lista.Where(x => x.Nickname != null).Select(x => x.Nickname).ToList();


            z = result.IndexOf(nameplayer1);

            if (z == -1)
            {
                Console.WriteLine("Usuário não encontrado, tente novamente");
                return;
            }

            Console.Write("Digite a senha do Player 1: ");

            passwordplayer1 = Console.ReadLine();

            result = lista.Where(x => x.Senha != null).Select(x => x.Senha).ToList();
            z = result.IndexOf(passwordplayer1);

            if (z == -1)
            {
                Console.WriteLine("Senha incorreta, tente novamente");
                return;

            }
            if (lista[z].Nickname == nameplayer1 && lista[z].Senha == passwordplayer1)
            {
                Console.WriteLine();
                Console.WriteLine("Login Player 1 Feito com sucesso.");
                Console.WriteLine();
            }

            //Login Player 2

            Console.Write("Digite o nome de usuário do player 2: ");
            nameplayer2 = Console.ReadLine();

            if (nameplayer2 == nameplayer1)
            {
                Console.WriteLine("O Nome do player 2 não pode ser o  mesmo do player 1! Tente Novamente. ");
                return;

            }
            result = lista.Where(x => x.Nickname != null).Select(x => x.Nickname).ToList();
            y = result.IndexOf(nameplayer2);

            if (y == -1)
            {
                Console.WriteLine("Usuário não encontrado, tente novamente");
                return;
            }
            Console.Write("Digite a senha do Player 2: ");
            passwordplayer2 = Console.ReadLine();

            if (lista[y].Nickname == nameplayer2 && lista[y].Senha == passwordplayer2)
            {
                Console.WriteLine();
                Console.WriteLine("Login Player 2 Feito com sucesso.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Senha incorreta, tente novamente");
                return;

            }
            playerid.id1 = z;
            playerid.id2 = y;
            playerid.logou = true;
        }
        public static void ListarContas()
        {
            string arquivojson = @"D:\Minhas coisas\Projetos viasula studio\SharpCoders\Projeto HubDeJogos\SharpCoders_HubDeGames\HubGameplay\Players.json";
            var option = new JsonSerializerOptions { WriteIndented = true };
            string jsonlines = File.ReadAllText(arquivojson);
            List<Jogador>? lista;
            lista = System.Text.Json.JsonSerializer.Deserialize<List<Jogador>>(jsonlines, option);
            foreach (Jogador jogador in lista)
            {
                Console.WriteLine($"Nome: {jogador.Nome} Nickname: {jogador.Nickname}\n");
            }

        }
        public static void Cadastrar()
        {
            try
            {
                string arquivojson = @"D:\Minhas coisas\Projetos viasula studio\SharpCoders\Projeto HubDeJogos\SharpCoders_HubDeGames\HubGameplay\Players.json";
                string nome, senha, nickname;
                var option = new JsonSerializerOptions { WriteIndented = true };

                if (!File.Exists(arquivojson))
                {
                    File.Create(arquivojson);
                    File.WriteAllText(arquivojson, "[]");
                }
                string jsonlines = File.ReadAllText(arquivojson);
                List<Jogador>? lista;
                if (string.IsNullOrWhiteSpace(jsonlines))
                {
                    lista = new List<Jogador>();
                }
                else
                {
                    lista = System.Text.Json.JsonSerializer.Deserialize<List<Jogador>>(jsonlines, option);
                }
                Console.Write("Digite seu nome: ");
                nome = Console.ReadLine();
                Console.Write("Digite sua senha: ");
                senha = Console.ReadLine();
                Console.Write("Digite seu nickname: ");
                nickname = Console.ReadLine();

                var result = lista.Where(x => x.Nickname != null).Select(x => x.Nickname).ToList();

                int z = result.IndexOf(nickname);

                while (z != -1)
                {
                    Console.Write("este nome de usuário ja existe, crie outro: ");
                    nickname = Console.ReadLine();

                    result = lista.Where(x => x.Nickname != null).Select(x => x.Nickname).ToList();

                    z = result.IndexOf(nickname);
                }

                lista.Add(new Jogador(nome, senha, nickname));

                string playerjson = System.Text.Json.JsonSerializer.Serialize(lista, option);
                File.WriteAllText(arquivojson, playerjson);

            }
            catch (Exception ex)
            {

                Console.WriteLine("Um erro ocorreu, arquivo foi criado, tente novamente");

            }

        }
        public override string ToString()
        {
            return $" Nome: {Nome}\n Senha: {Senha}\n Nick: {Nickname}\n Pontos Jogo Da Velha: {PontosTotaisJogodaVelha} \n Pontos Batalha Naval: {PontosTotaisBatalhaNaval}\n";
        }


    }
}
