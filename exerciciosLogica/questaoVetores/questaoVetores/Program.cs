using System;
using System.Globalization;
using System.Runtime.InteropServices;
/*
Implemente um TAD em uma Classe chamado Vet para opera ̧c ̃oes com
Vetores de N ́umeros Inteiros:
1. Criacao de um Vetor de um determinado Tamanho definido pelo usu ́ario;
2. Inclus ̃ao de um determinado valor em uma determinada posi ̧c ̃ao do Vetor;
3. Recupera ̧c ̃ao de um valor localizado em alguma posi ̧c ̃ao do Vetor;
4. Consulta sobre a existˆencia de um determinado valor dentro do Vetor;
5. Soma de elementos do Vetor:
• Pares;
•  ́Impares;
• Pares e  ́Impares.
6. Listagem de todos os elementos do Vetor.
1

*/
namespace questaoVetores
{
    struct Vet
    {
        public int[] criaVetor(int n)
        {
            int[] vetor = new int[n];
            Console.WriteLine($"Digite {n} valores abaixo:");
            for (int i = 0; i < vetor.Length; i++)
            {
                Console.WriteLine($"Valor {i + 1}/{n}");
                vetor[i] = int.Parse(Console.ReadLine());
            }
            return vetor;
        }
        public bool inserirPosicao(int[] v, int pos, int valor)
        {
            for (int i = 0; i < v.Length; i++)
            {
                if (i == pos && pos <= v.Length)
                {
                    v[i] = valor;
                    return true;
                }
            }
            return false;
        }
        public int buscarPosicao(int[] v, int pos)
        {
            for (int i = 0; i < v.Length; i++)
            {
                if (i == pos)
                    return v[i];
            }
            return 0;
        }
        public bool buscarValor(int[] v, int valor)
        {
            for (int i = 0; i < v.Length; i++)
            {
                if (v[i] == valor)
                    return true;
            }
            return false;
        }
        public int somarElementosPares(int[] v)
        {
            int somatorio = 0;
            for (int i = 0; i < v.Length; i++)
            {
                if (v[i] % 2 == 0)
                    somatorio += v[i];
            }
            return somatorio;
        }
        public int somarElementosImpares(int[] v)
        {
            int somatorio = 0;
            for (int i = 0; i < v.Length; i++)
            {
                if (v[i] % 2 == 0)
                {

                }
                else
                {
                    somatorio += v[i];
                }
            }
            return somatorio;
        }
        public int somarElementos(int[] v)
        {
            int somatorio = 0;

            foreach (int i in v)
            {
                somatorio += i;
            }
            return somatorio;
        }
        public void listarElementos(int[] v)
        {
            Console.WriteLine("[");
            for(int i=0;i<v.Length;i++)
                Console.WriteLine(v[i]);
            Console.WriteLine("]");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Criação do "objeto"
            Vet opVet = new Vet();
            int[] vetor = null;
            bool continuar = true;
            while (continuar)
            {

                Console.WriteLine("╔════════════════════════════════════╗");
                Console.WriteLine("║ Bem vindo a sua agenda de contatos ║ ");
                Console.WriteLine("║ Escolha uma das opções abaixo      ║");
                Console.WriteLine("║ 1 - Criar um vetor                 ║");
                Console.WriteLine("║ 2 - Incluir em posição específica  ║");
                Console.WriteLine("║ 3 - Recuperação de um valor        ║");
                Console.WriteLine("║ 4 - Consultar valor                ║");
                Console.WriteLine("║ 5 - Somar elementos                ║");
                Console.WriteLine("║ 6 - Listar elementos               ║");
                Console.WriteLine("║ 7 - Sair                           ║");
                Console.WriteLine("╚════════════════════════════════════╝");
                if (int.TryParse(Console.ReadLine(), out int opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            Console.WriteLine("Opção escolhida: Criar um vetor");
                            Console.WriteLine("Por favor digite o tamanho desejado:");
                            int tamanho = int.Parse(Console.ReadLine());
                            vetor = opVet.criaVetor(tamanho);
                            break;
                        case 2:
                            if (vetor == null)
                            {
                                Console.WriteLine("O vetor está vazio, favor preenche-lo");
                            }
                            else
                            {
                                Console.WriteLine("Opção escolhida: Incluir elemento em posição específica!");
                                Console.WriteLine("Digite o elemento que você deseja inserir no vetor:");
                                int elemento = int.Parse(Console.ReadLine());
                                Console.WriteLine($"Digite a posição que você deseja inserir o elemento {elemento}");
                                int pos = int.Parse(Console.ReadLine());
                                opVet.inserirPosicao(vetor, pos, elemento);
                            }
                            break;
                        case 3:
                            Console.WriteLine("Opção escolhida: Buscar elemento de acordo com a posição");
                            if (vetor == null)
                            {
                                Console.WriteLine("Vetor vazio, favor preenche-lo");
                            }
                            else
                            {
                                Console.WriteLine("Informe a posição que você deseja buscar");
                                int posicao = int.Parse(Console.ReadLine());
                                Console.WriteLine($"O número presente na posição {posicao} é:" + opVet.buscarPosicao(vetor, posicao));
                            }
                            break;
                        case 4:
                            Console.WriteLine("Opção escolhida: Buscar elemento");
                            Console.WriteLine("Digite o elemento que você deseja buscar dentro do vetor:");
                            int valor = int.Parse(Console.ReadLine());
                            if(vetor==null)
                            {
                                Console.WriteLine("Vetor vazio, favor preenche-lo");
                            }
                            else
                            {
                                if(!opVet.buscarValor(vetor,valor))
                                    Console.WriteLine($"valor {valor} não encontrado no vetor");
                                else
                                    Console.WriteLine($"valor {valor} foi econtrado no vetor");
                            }
                            break;
                        case 5:
                            Console.WriteLine("╔════════════════════════════════════╗");
                            Console.WriteLine("║ 1 - Somar Pares                    ║");
                            Console.WriteLine("║ 2 - Somar Impares                  ║");
                            Console.WriteLine("║ 3 - Somar todos                    ║");
                            Console.WriteLine("╚════════════════════════════════════╝");
                            if (int.TryParse(Console.ReadLine(), out int opcao2))
                                switch (opcao2)
                                {
                                    case 1:
                                        Console.WriteLine("Opção escolhida: somar pares");
                                        if(vetor==null)
                                            Console.WriteLine("Não há elementos a serem somados no vetor, por favor tente novamente");
                                        else
                                            Console.WriteLine("A soma dos números pares do vetor é: " + opVet.somarElementosPares(vetor));
                                        break;
                                    case 2:
                                        Console.WriteLine("Opção escolhida: somar ímpares");
                                        if(vetor==null)
                                            Console.WriteLine("Não há elementos a serem somados no vetor, por favor tente novamente");
                                        else
                                            Console.WriteLine("A soma dos números ímpares do vetor é: " + opVet.somarElementosImpares(vetor));
                                        break;
                                    case 3:
                                        Console.WriteLine("Opção escolhida: somar todos");
                                        if(vetor==null)
                                            Console.WriteLine("Não há elementos a serem somados no vetor, por favor tente novamente");
                                        else
                                            Console.WriteLine("A soma dos números do vetor é: " + opVet.somarElementos(vetor));
                                        break;
                                }
                            break;
                        case 6:
                            Console.WriteLine("Opção escolhida: lista vetor!!");
                            if(vetor==null)
                                Console.WriteLine("Não há elementos a serem listados nesse vetor");
                            else
                                opVet.listarElementos(vetor);
                            break;
                        case 7:
                            continuar = false;
                            break;
                        default:
                            Console.WriteLine("Opção inválida, tente novamente");
                        break;
                    }
                }
            }
        }
    }
}
