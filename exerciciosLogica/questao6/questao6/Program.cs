using System;
/*
Implemente um TAD chamado de N ́umero Complexo com as opera ̧c ̃oes
para Soma e Subtra ̧c ̃ao. Um n ́umero Complexo possui os campos Real e Imagin ́ario
(x + yi, sendo i = √−1)
*/
namespace questao6
{
    struct numeroComplexo
    {
        public double Real {get;set;}
        public double Imaginario {get;set;}
        public numeroComplexo(double real,double imaginario)
        {
            Real=real;
            Imaginario=imaginario;
        }
        public numeroComplexo somarNumeros(numeroComplexo outro)
        {
            return new numeroComplexo(this.Real+outro.Real,this.Imaginario+outro.Imaginario);
        }
        public numeroComplexo subtrairNumeros(numeroComplexo outro)
        {
            return new numeroComplexo(this.Real-outro.Real,this.Imaginario-outro.Imaginario);
        }
        public override string ToString()
        {
            return $"{Real} {(Imaginario >= 0 ? "+" : "")} {Imaginario}";    
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Informe a parte real do primeiro número:");
            double real1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Informe a parte imaginária do primeiro número:");
            double imaginario1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Informe a parte real do segundo número:");
            double rea2 = double.Parse(Console.ReadLine());
            Console.WriteLine("Informe a parte imaginária do segundo número:");
            double imaginario2 = double.Parse(Console.ReadLine());

            numeroComplexo num1 = new numeroComplexo(real1,imaginario1);
            numeroComplexo num2 = new numeroComplexo(rea2,imaginario2);

            numeroComplexo soma = num1.somarNumeros(num2);
            numeroComplexo subtracao = num1.subtrairNumeros(num2);

            Console.WriteLine($"Soma: {soma}");
            Console.WriteLine($"Subtração: {subtracao}");
        }
    }
}
