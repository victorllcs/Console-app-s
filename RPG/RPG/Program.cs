using System.Diagnostics.Contracts;
using System.Numerics;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

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
    private double experiencia=50; //A cada vez que o nível subir em 1, a experiência necessária para subir de nível será multiplicada por 2
    
    //Controladores de acesso para os atributos privados
    public int HP
    {
        get {return hp;} //Obtem o valor do hp
        set {hp=value;} //Modifica o valor do hp
    }
    public int Mana
    {   
        get {return mana;}
        set {mana=value;}
    }
    public int Atack
    {
        get {return ataque;}
        set {ataque=value;}
    }
    public int Defense
    {
        get {return defesa;}
        set {defesa=value;}
    }
    public int Speed
    {
        get {return velocidade;}
        set {velocidade=value;}
    }
    public int Inteligence
    {
        get {return inteligencia;}
        set {inteligencia=value;}
    }
    public int Range
    {
        get {return alcance;}
        set {alcance=value;}
    }
    public int Level
    {
        get {return nivel;}
        set {nivel=value;}
    }
    public double Exp
    {
        get {return experiencia;}
        set {experiencia=value;}
    }

    public string weaponType
    {
        get {return tipoArma;}
        set {tipoArma=value;}
    }
    public string armorType
    {
        get {return tipoArmadura;}
        set {tipoArmadura=value;}
    }
    public int Dex
    {
        get {return destreza;}
        set {destreza=value;}
    }
    public string characterClass
    {
        get {return classe;}
        set {classe=value;}
    }
    public string Name
    {
        get {return nome;}
        set {nome=value;}
    }
    public string Origin
    {
        get {return origem;}
        set {origem=value;}
    }

    //Propriedades do personagem
    private string classe = "Plebeu";
    private string nome;
    //Serão dadas as opções de origem para os jogadores escolherem, como se fossem países diferentes
    private string origem;

    //O tipo de arma e armadura vai mudar de acordo com o personagem, e será criada uma classe para as armas ainda.
    private string tipoArma = "Pedaço de madeira";
    private string tipoArmadura = "Couraças de couro leve";
    private double danoRecebido;

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
        Console.WriteLine($"Correndo, velocidade = {velocidade*0,3}");
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
        double danoTotal = danoRecebido*(20/100);
        double danoFinal = danoRecebido-danoTotal;
        Console.WriteLine($"Defendeu, dano recebido = {danoFinal}");
    }
    public void bradar()
    {
        Console.WriteLine($"Sou o {classe} da tribo {origem} e usarei toda a minha dedicação para derrotar o mal"); //Esse método receberá overrite de acordo com a classe
    }


    public double completarMissao(bool missaoConcluida,int quantidadeXp)
    {
        if(missaoConcluida==true)
            Exp=quantidadeXp;
        
        return Exp;
    }
    //Métodos para modificar os atritubos do personagem, todos eles serão utilizados de acordo com as classes
    public int subirNivel()
    {
        if(Level==Level+1)
        {
            Exp*=2;
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
}

class Mago:Personagem
{
    int magia;
    
    //As classes mágicas terão um aumento de mana de 100 para 200
    public void dispararHabilidade(string habilidade)
    {
        Console.WriteLine($"Disparando {habilidade}");
    }
    public void levitar()
    {
        Console.WriteLine("Levitação");
    }
    public void teletransportar(Random posicao)
    {
        Console.WriteLine($"Você foi teletransportado para longe da batalha, atual posição = {posicao}");
    }
    public void carregarMana()
    {
        Console.WriteLine("Carregando mana");
        while(Mana<200)
        {
            Mana++;
            Console.WriteLine(Mana);
        } 
    }
}

class Necromancer:Personagem
{
    int trevas,invocacao;

    public void invocarTrevas()
    {
        Console.WriteLine("O poder das trevas foi invocado.");
        trevas = trevas+(trevas*15/100);
        Console.WriteLine($"Atributo Trevas foi aumentado em 15%: {trevas}");
    }
    public void invocarCriaturas(string criatura)
    {
        Console.WriteLine($"Você invocou: {criatura}");
    }
}