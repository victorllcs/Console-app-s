using System;
/*
Crie um programa que solicite ao usu ́ario um n ́umero inteiro n ̃ao negativo e calcule
o fatorial desse n ́umero utilizando um loop do-while. O c ́alculo do fatorial deve
ser implementado em uma fun ̧c ̃ao separada que recebe o n ́umero e retorna o fatorial
calculado. O programa deve exibir o resultado
*/
namespace questao4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Informe um número positivo para que o fatorial seja calculado");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine($"O fatorial do número {number} é: " + calculaFatorial(number));
        }
        public static int calculaFatorial(int numero)
        {
            if(numero ==0 || numero ==1)
                return 1;

            int resultado =1;
            do 
            {   
                resultado *= numero;
                numero--;
            }while(numero > 1);

        return resultado;
        }
    }
}
