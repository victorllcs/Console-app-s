using System;
/*
Desenvolva um programa que crie uma matriz quadrada de ordem N (onde N  ́e
fornecido pelo usu ́ario) com n ́umeros inteiros. Solicite ao usu ́ario que insira os
valores para cada posi ̧c ̃ao da matriz. Em seguida, crie uma fun ̧c ̃ao que receba essa
matriz e retorne a soma dos elementos que est ̃ao acima da diagonal principal. O
programa deve exibir o resultado.
*/
namespace questao5
{
    class Program
    {
        static void Main(string[] args)
        {
            int tamanhoMatriz;
            Console.WriteLine("Informe o tamanho da matriz desejada");
            tamanhoMatriz = int.Parse(Console.ReadLine());
            int [,] matriz = new int [tamanhoMatriz,tamanhoMatriz];
            Console.WriteLine($"Informe {tamanhoMatriz*tamanhoMatriz} valores para colocar na matriz:");
            for(int i=0;i<tamanhoMatriz;i++)
                for(int j=0;j<tamanhoMatriz;j++)
                    {
                        Console.WriteLine($"Valor [{i},{j}]");
                        matriz[i,j] = int.Parse(Console.ReadLine());
                    }
            Console.WriteLine("A soma dos elementos que estão acima da diagonal principal é: " + somaValores(matriz));
        }
        public static int somaValores(int [,] matriz)
        {
            int soma=0;
            for(int i=0;i<matriz.GetLongLength(1);i++)
                for(int j=0;j<matriz.GetLength(1);j++)
                {
                    if(j>i)
                        soma+=matriz[j,i]; 
                }
            return soma;
        }
    }
}
