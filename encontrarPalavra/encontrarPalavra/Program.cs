using System;
using System.Runtime.InteropServices;
using System.Security;

namespace encontrarPalavra
{
    class Program
    {
        static void Main(string[] args)
        {
            string [] nomes = {"gabriel","victor","luiz","tiago","marcos"};
            Pesquisa("Victor",nomes); 
        }

        public static Array Pesquisa(string palavra,string [] lista)
        {
            int [] posicoes = new int [lista.Length];

            for(int i=0;i<lista.Length;i++)
                if(lista[i] == palavra)
                    posicoes[i]=1;
                else
                    posicoes[i]=0;

        return posicoes;
        }
    }
}
