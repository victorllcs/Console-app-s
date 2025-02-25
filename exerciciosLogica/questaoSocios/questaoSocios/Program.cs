using System;
using System.Collections.Generic;

namespace questaoSocios
{
    struct Dependente
    {
        public int Cota { get; }
        public string Nome { get; }
        public Data DataNascimento { get; }

        public Dependente(int cota, string nome, Data dataNascimento)
        {
            Cota = cota;
            Nome = nome;
            DataNascimento = dataNascimento;
        }

        public override string ToString()
        {
            return $"Cota: {Cota}, Nome: {Nome}, Nascimento: {DataNascimento}";
        }
    }

    struct Data
    {
        public string Dia { get; }
        public string Mes { get; }
        public string Ano { get; }

        public Data(string dia, string mes, string ano)
        {
            Dia = dia;
            Mes = mes;
            Ano = ano;
        }

        public override string ToString()
        {
            return $"{Dia}/{Mes}/{Ano}";
        }
    }

    struct Socios
    {
        public int Cota { get; }
        public string Nome { get; }
        public Data DataNascimento { get; }
        public Data DataAquisicao { get; }

        public Socios(int cota, string nome, Data dataNascimento, Data dataAquisicao)
        {
            Cota = cota;
            Nome = nome;
            DataNascimento = dataNascimento;
            DataAquisicao = dataAquisicao;
        }

        public override string ToString()
        {
            return $"Cota: {Cota}, Nome: {Nome}, Nascimento: {DataNascimento}, Aquisição: {DataAquisicao}";
        }
    }

    class Program
    {
        static void Main()
        {
            Dictionary<int, (Socios, List<Dependente>)> listaSocios = new Dictionary<int, (Socios, List<Dependente>)>();

            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("\nMenu Principal:");
                Console.WriteLine("1 - Cadastrar sócios e dependentes");
                Console.WriteLine("2 - Listar sócios e dependentes");
                Console.WriteLine("3 - Remover sócio");
                Console.WriteLine("4 - Sair");
                Console.Write("Escolha uma opção: ");

                if (int.TryParse(Console.ReadLine(), out int opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            Console.WriteLine("\nOpção escolhida: Cadastrar sócios e dependentes");

                            while (true)
                            {
                                Console.Write("\nInforme o número da cota do sócio (ou -1 para sair): ");
                                if (!int.TryParse(Console.ReadLine(), out int cotaSocio) || cotaSocio == -1)
                                    break;

                                Console.Write("Informe o nome do sócio: ");
                                string nomeSocio = Console.ReadLine();

                                Console.WriteLine("Informe a data de nascimento do sócio:");
                                Console.Write("Dia: ");
                                string diaSocio = Console.ReadLine();
                                Console.Write("Mês: ");
                                string mesSocio = Console.ReadLine();
                                Console.Write("Ano: ");
                                string anoSocio = Console.ReadLine();
                                Data dataNascimentoSocio = new Data(diaSocio, mesSocio, anoSocio);

                                Console.WriteLine("Informe a data de aquisição do sócio:");
                                Console.Write("Dia: ");
                                string diaAqsSocio = Console.ReadLine();
                                Console.Write("Mês: ");
                                string mesAqsSocio = Console.ReadLine();
                                Console.Write("Ano: ");
                                string anoAqsSocio = Console.ReadLine();
                                Data dataAquisicao = new Data(diaAqsSocio, mesAqsSocio, anoAqsSocio);

                                Console.Write("Informe a quantidade de dependentes do sócio: ");
                                int.TryParse(Console.ReadLine(), out int quantidadeDependentes);
                                quantidadeDependentes = Math.Max(0, quantidadeDependentes);

                                Socios novoSocio = new Socios(cotaSocio, nomeSocio, dataNascimentoSocio, dataAquisicao);
                                List<Dependente> dependentes = new List<Dependente>();

                                for (int i = 0; i < quantidadeDependentes; i++)
                                {
                                    Console.WriteLine($"\nCadastrando Dependente {i + 1}:");

                                    Console.Write("Informe o número da cota do dependente: ");
                                    int cotaDependente = int.Parse(Console.ReadLine());

                                    Console.Write("Informe o nome do dependente: ");
                                    string nomeDependente = Console.ReadLine();

                                    Console.WriteLine("Informe a data de nascimento do dependente:");
                                    Console.Write("Dia: ");
                                    string dia = Console.ReadLine();
                                    Console.Write("Mês: ");
                                    string mes = Console.ReadLine();
                                    Console.Write("Ano: ");
                                    string ano = Console.ReadLine();
                                    Data dataNascimentoDependente = new Data(dia, mes, ano);

                                    Dependente novoDependente = new Dependente(cotaDependente, nomeDependente, dataNascimentoDependente);
                                    dependentes.Add(novoDependente);
                                }

                                listaSocios[cotaSocio] = (novoSocio, dependentes);
                                Console.WriteLine("\nSócio e seus dependentes cadastrados com sucesso!");
                            }
                            break;

                        case 2:
                            Console.WriteLine("\nLista de Sócios e Dependentes:");
                            foreach (var item in listaSocios)
                            {
                                Socios socio = item.Value.Item1;
                                List<Dependente> dependentes = item.Value.Item2;

                                Console.WriteLine($"\nSócio: {socio}");
                                if (dependentes.Count > 0)
                                {
                                    Console.WriteLine("Dependentes:");
                                    foreach (var dep in dependentes)
                                        Console.WriteLine($"  - {dep}");
                                }
                                else
                                {
                                    Console.WriteLine("Sem dependentes.");
                                }
                            }
                            break;

                        case 3:
                            Console.Write("\nInforme o número da cota do sócio a ser removido: ");
                            if (int.TryParse(Console.ReadLine(), out int cotaRemovida))
                            {
                                if (listaSocios.Remove(cotaRemovida))
                                {
                                    Console.WriteLine("Sócio removido com sucesso!");
                                }
                                else
                                {
                                    Console.WriteLine("Sócio não encontrado.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Número de cota inválido.");
                            }
                            break;

                        case 4:
                            continuar = false;
                            Console.WriteLine("Programa encerrado.");
                            break;

                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
            }
        }
    }
}
