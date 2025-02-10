using System.Diagnostics.Contracts;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
//Classes referentes aos personagens.
class Personagem
{
    /*Todo personagem vai vir padrão com uma certa quantidade de cada ponto, a quantidade será alterada de acordo com a classe*/

    //Atributos do personagem
    private int hp = 100;
    private int mana = 100;
    private int ataque = 5;
    private int velocidade = 5;
    private int defesa = 5;
    private int inteligencia = 5;
    private int alcance = 5;
    private int nivel = 1;
    private int destreza = 5;
    private double experiencia = 50; //A cada vez que o nível subir em 1, a experiência necessária para subir de nível será multiplicada por 2

    //Controladores de acesso para os atributos privados
    public int HP
    {
        get { return hp; } //Obtem o valor do hp
        set { hp = value; } //Modifica o valor do hp
    }
    public int Mana
    {
        get { return mana; }
        set { mana = value; }
    }
    public int Atack
    {
        get { return ataque; }
        set { ataque = value; }
    }
    public int Defense
    {
        get { return defesa; }
        set { defesa = value; }
    }
    public int Speed
    {
        get { return velocidade; }
        set { velocidade = value; }
    }
    public int Inteligence
    {
        get { return inteligencia; }
        set { inteligencia = value; }
    }
    public int Range
    {
        get { return alcance; }
        set { alcance = value; }
    }
    public int Level
    {
        get { return nivel; }
        set { nivel = value; }
    }
    public double Exp
    {
        get { return experiencia; }
        set { experiencia = value; }
    }

    public string weaponType
    {
        get { return tipoArma; }
        set { tipoArma = value; }
    }
    public string armorType
    {
        get { return tipoArmadura; }
        set { tipoArmadura = value; }
    }
    public int Dex
    {
        get { return destreza; }
        set { destreza = value; }
    }
    public string characterClass
    {
        get { return classe; }
        set { classe = value; }
    }
    public string Name
    {
        get { return nome ?? gerarNomeAleatorio(6); }
        set { nome = value; }
    }
    public string Origin
    {
        get { return origem ?? "Floresta Sangrenta"; }
        set { origem = value; }
    }

    //Propriedades do personagem
    private string classe = "Plebeu";
    private string? nome; //Ao adicionar o ? na variável, ela vira nullnable, ou seja, não pode ser nula.
    //Serão dadas as opções de origem para os jogadores escolherem, como se fossem países diferentes
    private string? origem;

    //O tipo de arma e armadura vai mudar de acordo com o personagem, e será criada uma classe para as armas ainda.
    private string tipoArma = "Pedaço de madeira";
    private string tipoArmadura = "Couraças de couro leve";
    private int danoRecebido;

    public void atacar(string alvo)
    {
        Console.WriteLine($"Atacando {alvo}");
    }
    public void andar()
    {
        Console.WriteLine($"Andando, velocidade = {velocidade}");
    }
    public void correr()
    {
        Console.WriteLine($"Correndo, velocidade = {velocidade * 0,3}");
    }
    public void pular()
    {
        Console.WriteLine("Pulando");
    }
    public void agachar()
    {
        Console.WriteLine("Agachando");
    }
    public void defender()
    {
        int danoTotal = danoRecebido * (20 / 100);
        int danoFinal = danoRecebido - danoTotal;
        danoRecebido = danoFinal;
        HP = HP - danoRecebido;
        Console.WriteLine($"Defendeu, dano recebido = {danoFinal}");
    }
    public void bradar()
    {
        Console.WriteLine($"Sou o {classe} da tribo {origem} e usarei toda a minha dedicação para derrotar o mal"); //Esse método receberá overrite de acordo com a classe
    }


    public double completarMissao(bool missaoConcluida, int quantidadeXp)
    {
        if (missaoConcluida == true)
            Exp = quantidadeXp;

        return Exp;
    }
    //Métodos para modificar os atritubos do personagem, todos eles serão utilizados de acordo com as classes
    public int subirNivel()
    {
        if (Level == Level + 1)
        {
            Exp *= 2;
            Level++;
        }
        return Level;
    }

    public int modificarMana(int newValue)
    {
        Mana = newValue;
        return Mana;
    }
    public int modificarHp(int newValue)
    {
        HP = newValue;
        return HP;
    }
    public int modificarAtaque(int newValue)
    {
        Atack = newValue;
        return Atack;
    }
    public int modificarDefesa(int newValue)
    {
        Defense = newValue;
        return Defense;
    }
    public int modificarVelocidade(int newValue)
    {
        Defense = newValue;
        return Speed;
    }
    public int modificarInteligencia(int newValue)
    {
        Inteligence = newValue;
        return Inteligence;
    }
    public int modifcarAlcance(int newValue)
    {
        Range = newValue;
        return Range;
    }

    private static readonly Random random = new Random();
    public string gerarNomeAleatorio(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
    }
        public virtual void usarHabilidade()
    {
        Console.WriteLine($"Disparando");
    }
}
//Classe mágicos que herda a classe personagem, essa classe vai ser uma superclase para mago, necromancer e curandeiro
class Magicos : Personagem
{
    private int magia = 10;

    public int Magic
    {
        get { return magia; }
        set { magia = value; }
    }

    public void aumentarMana()
    {
        Console.WriteLine("Carregando mana");
        while (Mana < 200)
        {
            Mana++;
            Console.WriteLine(Mana);
        }
    }
}
//Classe furtivos que herda a classe personagem, essa classe vai ser uma superclasse para assasino e ninja
class Furtivos : Personagem
{
    private int furtividade;
    public int Stealth
    {
        get{return furtividade;}
        set{furtividade=value;}
    }
    public virtual void camuflar()
    {
        Console.WriteLine("Cada personagem se camufla de um jeito diferente");
    }
}
//Classe humanos que herda personagem e vai ser herdada por guerreiro, paladino e arqueiro
class Humanos : Personagem
{
    private int agressividade = 10;

    public int Fury
    {
        get{return agressividade;}
        set{agressividade=value;}
    }   
}
//Criação dos personagens de acordo com as suas classes

// Classe dos mágicos
class Mago : Magicos
{
    public void levitar()
    {
        Console.WriteLine("Levitação");
    }
    public void teletransportar(Random posicao)
    {
        Console.WriteLine($"Você foi teletransportado para longe da batalha, atual posição = {posicao}");
    }
    //Método da classe mágica sobreescrito
    public override void usarHabilidade()
    {
        Console.WriteLine($"Atirando bola de fogo");
    }
}
class Necromancer : Magicos
{
    int trevas;

    public void invocarTrevas()
    {
        Console.WriteLine("O poder das trevas foi invocado.");
        trevas = trevas + (trevas * 15 / 100);
        Console.WriteLine($"Atributo Trevas foi aumentado em 15%: {trevas}");
    }
    public override void usarHabilidade()
    {
        Console.WriteLine("Criaturas das trevas invocadas");
    }
}
class Curandeiro:Magicos
{
    int poderCura;
    public void ressucitar(string alvo)
    {
        Console.WriteLine($"Você ressucitou {alvo}");
    }
    public override void usarHabilidade()
    {
        Console.WriteLine($"Você acaba de curar um aliado");
    }
}
//Classe dos Humanos
class Paladino:Humanos
{
    private int fe,devocao;

    public int Faith
    {
        get{return fe;}
        set{fe=value;}
    }
    public int Devocion
    {
        get{return devocao;}
        set{devocao=value;}
    }
    public void orar() //Arrumar um jeito dessa modificação de atributos ir para todo mundo perto.
    {
        Faith = Faith +(Faith * 40/100);
        Fury = Fury + (Fury*40/100);
        Speed = Speed + (Speed*40/100);
        Atack = Atack + (Atack*40/100);
        Defense = Defense + (Defense*40/100);
        Dex = Dex + (Dex*40/100);
        Console.WriteLine("Todos os atributos do time foram buffados em 40%");
    }
}
class Arqueiro:Humanos
{
    private int visaoAguia = 10; //Propriedade particular do arqueiro
    public int eagleVision
    {
        get{return visaoAguia;}
        set{visaoAguia=value;}
    }
    public override void usarHabilidade()
    {
        Console.WriteLine("Rolar");
    }
    private void atirar()
    {
        Console.WriteLine("Atirando flechas");
    }
}
class Guerreiro:Humanos
{
    private int forca = 10;
    public int Strength
    {
        get{return forca;}
        set{forca=value;}
    }
    public override void usarHabilidade()
    {
        Console.WriteLine("Ativar Fúria");
        Speed = Speed + (Speed*30/100);
        Atack = Atack + (Atack*30/100);
        Strength = Strength + (Strength*30/100);
    }
}
class Assasino:Furtivos
{
    private int insanidade = 10;
    public int Insanity
    {
        get{return insanidade;}
        set{insanidade=value;}
    }

    public override void usarHabilidade()
    {
        Console.WriteLine("Furtivamente, o alvo foi assasinado.");  
    }
    public override void camuflar()
    {
        Console.WriteLine("O assasino utiliza as suas habilidades para se aglomerar no meio do público");
    }
}

class Ninja:Furtivos
{
    public override void camuflar()
    {
        Console.WriteLine("O ninja se camufla no ambiente");
    }
    public void escalar()
    {
        Console.WriteLine("Escalando...");
    }
    public override void usarHabilidade()
    {
        Console.WriteLine("Passo Silencioso utilizado");
    }
}
//A partir daqui, serão criadas as classes referentes as armas do jogo.
class Armas
{
    //em construção, é necessário criar o diagrama de classes antes de começar a estruturar essa classe.
    private string tipo;
    private int danoPrincipal;
    private string classePersonagem;
    private int velocidadeAtk;
    private int nivelNecessario;
    
}

class Program
{
    public static void Main(string[] args)
    {
        //Cria um objeto
        Personagem p1 = new Personagem();
        //Começa a adicionar atributos específicos no objeto
        Console.WriteLine("Escolha o nome do seu personagem:");
        p1.Name = Console.ReadLine() ?? "";
        if (string.IsNullOrEmpty(p1.Name))
            p1.Name = p1.gerarNomeAleatorio(6);
        escolhaReino://Label de retorno para o default do switch
        Console.WriteLine("Escolha o reino do seu personagem!");
        Console.WriteLine("A- Cidade das Feras \n B- Cidade dos Dragões \n C-Floresta Sangrenta \n D- Colina de Ossos \n E - Vales Nevados");
        p1.Origin = Console.ReadLine() ?? " "; //?? é um operador de coalescência nula, que nesse caso coloca "" na string caso o valor do usuário seja null
        switch (p1.Origin)
        {
            case "A":
                p1.Origin = "Cidade das feras";
                break;
            case "B":
                p1.Origin = "Cidade dos dragões";
                break;
            case "C":
                p1.Origin = "Floresta Sangrenta";
                break;
            case "D":
                p1.Origin = "Colina de Ossos";
                break;
            case "E":
                p1.Origin = "Vales Nevados";
                break;
            default:
                Console.WriteLine("A opção selecionada é inválida");
                Console.WriteLine("==============================");
                goto escolhaReino; //Referencia a label para o código retornar.
        }
        Console.WriteLine(p1.Name);
        Console.WriteLine(p1.Origin);

    }
}