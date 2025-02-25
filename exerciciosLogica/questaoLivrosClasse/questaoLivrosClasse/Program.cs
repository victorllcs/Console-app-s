using System;

namespace questaoLivrosClasse
{
    struct Livro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public int Ano { get; set; }

        public Livro(string titulo, string autor, string genero, int ano)
        {
            Titulo = titulo;
            Autor = autor;
            Genero = genero;
            Ano = ano;
        }
    }

    class Biblioteca
    {
        public static void OrdenarPorAno(Livro[] livros)
        {
            Array.Sort(livros, (a, b) => a.Ano.CompareTo(b.Ano));
        }

        public static bool BuscarPorAutor(Livro[] livros, string autor)
        {
            foreach (var livro in livros)
            {
                if (livro.Autor.Equals(autor, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public static int ContarPorGenero(Livro[] livros, string genero)
        {
            int count = 0;
            foreach (var livro in livros)
            {
                if (livro.Genero.Equals(genero, StringComparison.OrdinalIgnoreCase))
                {
                    count++;
                }
            }
            return count;
        }
    }

    class Program
    {
        static void Main()
        {
            Livro[] listaLivros = new Livro[]
            {
                new Livro("O Universo numa Casca de Noz", "Stephen Hawking", "Física", 2001),
                new Livro("Cem Anos de Solidão", "Gabriel Garcia Marquez", "Romance", 1967),
                new Livro("Ariana, a Mulher", "Vinicius de Morais", "Poesia", 1936),
                new Livro("Prosopopeia", "Bento Teixeira", "Poema", 1601),
                new Livro("O Guia do Mochileiro das Galáxias", "Douglas Adams", "Ficção", 1981)
            };

            Biblioteca.OrdenarPorAno(listaLivros);
            Console.WriteLine("Livros ordenados por ano de publicação:");
            foreach (var livro in listaLivros)
            {
                Console.WriteLine($"{livro.Titulo} - {livro.Autor} ({livro.Ano})");
            }

            string autorBusca = "Stephen Hawking";
            Console.WriteLine($"Existe obra de {autorBusca}? {Biblioteca.BuscarPorAutor(listaLivros, autorBusca)}");

            string generoBusca = "Ficção";
            Console.WriteLine($"Quantidade de livros do gênero {generoBusca}: {Biblioteca.ContarPorGenero(listaLivros, generoBusca)}");
        }
    }
}
