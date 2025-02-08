using System;

class Program
{
    static void Main(string[] args)
    {
        string[] nomes = { "gabriel", "victor", "luiz", "victor", "marcos" };
        int[] resultado = Pesquisa("victor", nomes);

        // Corrigindo a impressão do array
        Console.WriteLine("Vetor de presença:");
        Console.WriteLine("[ " + string.Join(", ", resultado) + " ]");
    }

    public static int[] Pesquisa(string palavra, string[] lista)
    {
        int[] posicoes = new int[lista.Length]; // Vetor do mesmo tamanho da lista

        for (int i = 0; i < lista.Length; i++)
        {
            if (lista[i] == palavra)
                posicoes[i] = 1; // Marca 1 onde encontrou a palavra
            else
                posicoes[i] = 0; // Marca 0 onde não encontrou
        }

        return posicoes;
    }
}
