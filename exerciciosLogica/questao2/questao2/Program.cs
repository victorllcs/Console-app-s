using System;
using System.Security.Cryptography.X509Certificates;

namespace questao2
{
    /*Desenvolva um programa que crie uma matriz 3x3 de n ́umeros inteiros. Solicite ao
usuario que insira os valores para cada posi ̧c ̃ao da matriz. Em seguida, crie uma
fun ̧cao que receba essa matriz e retorne a quantidade de n ́umeros pares presentes
nela. O programa deve exibir o resultado.*/
    class Program
    {
        static void Main(string[] args)
        {   
            int [,] numeros = new int[3,3];
            for(int i=0;i<3;i++)
                for(int j=0;j<3;j++)
                {
                    Console.WriteLine($"Preencha a matriz na posição [{i},{j}]:");
                    numeros[i,j] = int.Parse(Console.ReadLine());
                }    
            Console.WriteLine("A quantidade de números pares na matriz é de: " + contaPares(numeros));
        }
        public static int contaPares(int [,] matriz)
        {
            int contador =0;
            for(int i=0;i<3;i++)
                for(int j=0;j<3;j++)
                    if(matriz[i,j]%2==0)
                        contador++;

            return contador;
        }
    }
}
