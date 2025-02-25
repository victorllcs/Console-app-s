using System;
using System.Security;
/*
Escreva um programa que solicite ao usu ́ario uma palavra e verifique se ela  ́e um
pal ́ındromo (ou seja, se pode ser lida da mesma forma de tr ́as para frente). Utilize
uma fun ̧c ̃ao que receba a palavra e retorne um valor booleano indicando se  ́e ou n ̃ao
um pal ́ındromo. O programa deve exibir uma mensagem informando o resultado.
*/
namespace questao3
{
    class Program
    {
        static void Main(string[] args)
        {
            string palavra;
            Console.WriteLine("Informe uma palavra");
            palavra=Console.ReadLine();
            if(palindrome(palavra))
                Console.WriteLine($"A palavra {palavra} é um palíndrome.");
            else
                Console.WriteLine($"A palavra {palavra} não é um palíndrome.");        
        }
    
        public static bool palindrome(string palavra)
        {
            if(string.IsNullOrEmpty(palavra))
                Console.WriteLine("String vazia,tente novamente");
            for(int i=0;i<(palavra.Length)/2;i++)
                if(palavra[i]!=palavra[palavra.Length-1-i])
                    return false;
            return true;
        }
    }
}
