using System;

namespace questaoFuncionarios
{
    struct Data
    {
        public string dia, mes, ano;

        public Data(string dia, string mes, string ano)
        {
            this.dia = dia;
            this.mes = mes;
            this.ano = ano;
        }
    }

    struct Funcionarios
    {
        public int matricula;
        public string nome, departamento;
        public double salario;
        public Data dataAdmissao;

        public Funcionarios(int matricula, string nome, string departamento, double salario, Data dataAdmissao)
        {
            this.matricula = matricula;
            this.nome = nome;
            this.departamento = departamento;
            this.salario = salario;
            this.dataAdmissao = dataAdmissao;
        }

        public override string ToString()
        {
            return $"Matrícula: {matricula}, Nome: {nome}, Departamento: {departamento}, Salário: {salario:C}, Data de Admissão: {dataAdmissao.dia}/{dataAdmissao.mes}/{dataAdmissao.ano}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Funcionarios[] listaFunc = new Funcionarios[50]; // Array com capacidade para 50 funcionários
            int count = 0; // Contador de funcionários cadastrados

            while (true)
            {
                Console.WriteLine("╔════════════════════════════════════╗");
                Console.WriteLine("║ Bem vindo ao Menu Principal        ║ ");
                Console.WriteLine("║ Escolha uma das opções abaixo      ║");
                Console.WriteLine("║ 1 - Cadastrar Funcionário          ║");
                Console.WriteLine("║ 2 - Listar Funcioários             ║");
                Console.WriteLine("║ 3 - Digite -1 para sair!!          ║");
                Console.WriteLine("╚════════════════════════════════════╝");
                if (!int.TryParse(Console.ReadLine(), out int opcao))
                {
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        if (count >= listaFunc.Length)
                        {
                            Console.WriteLine("A lista de funcionários está cheia!");
                            break;
                        }

                        Console.WriteLine("\nInforme os dados do funcionário:");

                        Console.Write("Matrícula: ");
                        if (!int.TryParse(Console.ReadLine(), out int matricula))
                        {
                            Console.WriteLine("Matrícula inválida!");
                            break;
                        }

                        Console.Write("Nome: ");
                        string nome = Console.ReadLine();

                        Console.Write("Departamento: ");
                        string departamento = Console.ReadLine();

                        Console.Write("Salário: ");
                        if (!double.TryParse(Console.ReadLine(), out double salario))
                        {
                            Console.WriteLine("Salário inválido!");
                            break;
                        }

                        Console.Write("Dia de admissão: ");
                        string dia = Console.ReadLine();

                        Console.Write("Mês de admissão: ");
                        string mes = Console.ReadLine();

                        Console.Write("Ano de admissão: ");
                        string ano = Console.ReadLine();

                        Data dataAdm = new Data(dia, mes, ano);
                        listaFunc[count] = new Funcionarios(matricula, nome, departamento, salario, dataAdm);
                        count++;

                        Console.WriteLine("Funcionário cadastrado com sucesso!");
                        break;

                    case 2:
                        if (count == 0)
                        {
                            Console.WriteLine("Nenhum funcionário cadastrado.");
                            break;
                        }

                        Console.Write("Informe o departamento para listar funcionários: ");
                        string option = Console.ReadLine();
                        bool encontrou = false;

                        for (int i = 0; i < count; i++)
                        {
                            if (listaFunc[i].departamento.Equals(option, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine(listaFunc[i]);
                                encontrou = true;
                            }
                        }

                        if (!encontrou)
                        {
                            Console.WriteLine("Nenhum funcionário encontrado nesse departamento.");
                        }
                        break;

                    case -1:
                        Console.WriteLine("Saindo do programa...");
                        return;

                    default:
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        break;
                }
            }
        }
    }
}
