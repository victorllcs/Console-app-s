using System;
/*
Descri ̧c ̃ao: Sua equipe de desenvolvimento foi alocada para participar de um Sis-
tema de Gerenciamento de Biblioteca, trabalhando no planejamento, modelagem
e implementa ̧c ̃ao de um TAD que represente os Livros no sistema. A Estrutura de
dados inicialmente  ́e:
struct livro{
string titulo;
string autor;
string genero;
int ano;
}
As fun ̧c ̃oes que devem ser exportadas pela interface TAD s ̃ao:
1. Criar Livro que recebe por parˆametro o t ́ıtulo, autor, gˆenero e ano de pu-
blica ̧c ̃ao e retorna um objeto do tipo Livro.
2. Quatro fun ̧c ̃oes de manuten ̧c ̃ao b ́asicas de registros do TAD livros: Obter
Autor, T ́ıtulo, Gˆenero e Ano.
3. Duas fun ̧c ̃oes para verificar a Estilo liter ́ario, sendo que est ́as dever ̃ao receber
um Objeto do Tipo Livro e retornar um Boleano com o resultado, sendo:
Modernismo de 1930 a 1945 e Barroco de 1601 a 1768
*/
namespace questaoLivrosStruct
{
    struct Livro
    {
        string titulo;
        string autor;
        string genero;
        int ano;

        public Livro(string titulo, string autor, string genero, int ano)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.genero = genero;
            this.ano = ano;
        }

        public Livro criarLivro()
        {
            Console.WriteLine("Informe o título desejado:");
            string nomeLivro = Console.ReadLine();
            Console.WriteLine("Informe o autor do livro:");
            string nomeAutor = Console.ReadLine();
            Console.WriteLine("Informe o gênero do livro:");
            string generoLivro = Console.ReadLine();
            Console.WriteLine("Informe o ano de publicação do livro:");
            int anoPub = int.Parse(Console.ReadLine());

            return new Livro(nomeLivro, nomeAutor, genero, anoPub);
        }
        public string obterAutor(Livro livro)
        {
            return livro.autor;
        }
        public string obterTitulo(Livro livro)
        {
            return livro.titulo;
        }
        public string obterGenero(Livro livro)
        {
            return livro.genero;
        }
        public int obterAno(Livro livro)
        {
            return livro.ano;
        }
        public bool livroModernista(Livro livro)
        {
            if (livro.ano >= 1930 && livro.ano <= 1945)
                return true;
            return false;
        }
        public bool livroBarroco(Livro livro)
        {
            if (livro.ano >= 1601 && livro.ano <= 1768)
                return true;
            return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;
            Livro livro = new Livro();
            while (continuar)
            {

                menuPrincipal:
                Console.WriteLine("╔════════════════════════════════════╗");
                Console.WriteLine("║ Bem vindo a sua biblioteca virtual ║ ");
                Console.WriteLine("║ Escolha uma das opções abaixo      ║");
                Console.WriteLine("║ 1 - Adicionar Livro                ║");
                Console.WriteLine("║ 2 - Buscar pelo nome               ║");
                Console.WriteLine("║ 3 - Buscar pelo autor              ║");
                Console.WriteLine("║ 4 - Buscar pelo gênero             ║");
                Console.WriteLine("║ 5 - Buscar por ano                 ║");
                Console.WriteLine("║ 6 - Pesquisar gênero - Modernista  ║");
                Console.WriteLine("║ 7 - Pesqusiar gênero - Barroco     ║");
                Console.WriteLine("║ 8 - Sair                           ║");
                Console.WriteLine("╚════════════════════════════════════╝");
                if (int.TryParse(Console.ReadLine(), out int opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            Console.WriteLine("Opção escolhida:Adicionar livro");
                            livro = livro.criarLivro();
                            break;
                        case 2:
                            Console.WriteLine("Opção escolhida:Buscar livro pelo nome");
                            break;
                        case 3:
                            Console.WriteLine("Opção escolhida:Buscar livro pelo autor");
                            break;
                        case 4:
                            Console.WriteLine("Opção escolhida:Buscar livro pelo gênero");
                            break;
                        case 5:
                            Console.WriteLine("Opção escolhida:Buscar livro pelo ano de publicação");
                            break;
                        case 6:
                            Console.WriteLine("Opção escolhida:Pesquisar gênero literário - Modernista");
                            break;
                        case 7:
                            Console.WriteLine("Opção escolhida:Pesquisar gênero literário - Modernista");
                            break;
                        case 8:
                            continuar = false;
                            break;
                        default:
                            Console.WriteLine("Opção inválida, por favor tente novamente");
                            goto menuPrincipal;
                    }
                }
            }
        }
    }
}
