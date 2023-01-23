using HubDeGames.Services;
using System.Runtime.CompilerServices;

namespace HubDeGames.Entities
{
    public class Jogador : IMetodos, IComparable
    {
       
        protected Jogador(in object value)
        {
        }

        public string Nome { get; private set; }
        public string Senha { get; private set; }
        public string Nickname { get; set; }
        public int PontosTotaisJogodaVelha { get; private set; }

        public Jogador() { }

        public Jogador(string nome, string senha, string nickname)
        {
            Nome = nome;
            Senha = senha;
            Nickname = nickname;

        }

        public int MarcaPonto(Jogador u)
        {
            return u.PontosTotaisJogodaVelha += 1;
        }

        public static void Cadastrar()
        {
            string nome, senha, nickname;
            string rootpath = @"D:\Minhas coisas\Projetos viasula studio\SharpCoders\ProjetoHubDeJogos\HubGameplay\HubGameplay\";
            string Filepath = rootpath + "PlayersList.txt";

            if (!File.Exists(Filepath))
            {
                File.Create(Filepath).Close();
            }

            Console.Write("Digite seu nome: ");
            nome = Console.ReadLine();
            Console.Write("Digite sua senha: ");
            senha = Console.ReadLine();
            Console.Write("Digite seu nickname: ");
            nickname = Console.ReadLine();


            using (StreamReader sr = new StreamReader(Filepath))
            {
               
            }

            using (StreamWriter sw = File.AppendText(Filepath))
            {

                sw.WriteLine(new Jogador(nome, senha, nickname));

            }
        }



        public override string ToString()
        {
            return $"{Nome}|{Senha}|{Nickname}|{PontosTotaisJogodaVelha}";
        }

        public static void ListarContas()
        {
            string rootpath = @"D:\Minhas coisas\Projetos viasula studio\SharpCoders\ProjetoHubDeJogos\HubGameplay\HubGameplay\";
            string Filepath = rootpath + "PlayersList.txt";

            using (StreamReader sr = new StreamReader(Filepath))
            {

               while(!sr.EndOfStream)
                {
                    Console.WriteLine(sr.ReadLine());

                    
                }
               
            }

        }

        public static void RankingJogodaVelha()
        {
            string rootpath = @"D:\Minhas coisas\Projetos viasula studio\SharpCoders\ProjetoHubDeJogos\HubGameplay\HubGameplay\";
            string Filepath = rootpath + "PlayersList.txt";

            using(StreamReader sr = File.OpenText(Filepath))
            {

                List<Jogador> jogadors = new List<Jogador>();

                while (!sr.EndOfStream)
                {

                    jogadors.Add(new Jogador(sr.ReadLine()));
                }
                jogadors.Reverse();
                foreach(Jogador emp in jogadors)
                {
                    Console.WriteLine($"{emp.Nickname} | {emp.PontosTotaisJogodaVelha}");
                }
            }

        }

        public int CompareTo(object? obj)
        {   
            Jogador other = obj as Jogador;

            return other.PontosTotaisJogodaVelha.CompareTo(obj);
        }
    }
}
