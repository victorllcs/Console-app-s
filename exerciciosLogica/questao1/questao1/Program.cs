using System;
using System.Runtime.InteropServices;
/*
Crie um programa que solicite ao usu ́ario a quantidade de notas que deseja inserir.
Em seguida, utilize um loop para ler essas notas (n ́umeros decimais) e armazene-as
em um vetor. Ap ́os a leitura, crie uma fun ̧c ̃ao que receba esse vetor e retorne a
m ́edia das notas. O programa deve ent ̃ao exibir a m ́edia calculada.
*/
namespace questao1
{
    class Program
    {
        static void Main(string[] args)
        {
            int qtdeNotas;
            Console.WriteLine("Informe a quantidade de notas!");
            qtdeNotas = int.Parse(Console.ReadLine());
            double [] notas= new double[qtdeNotas];
            for(int i=0;i<notas.Length;i++)
            {
                Console.WriteLine("Informe uma nota:");
                notas[i] = Double.Parse(Console.ReadLine());
            }
            Console.WriteLine("A média das notas é de: " + calcularMedia(notas));
        }
        public static double calcularMedia(double [] v)
        {
            double media =0;

            for(int i=0;i<v.Length;i++)
            {
                media+=(v[i])/v.Length;
            }
            return media;
        }
    }
}
