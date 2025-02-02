using System.Diagnostics.Contracts;
using System.Numerics;
using System.Runtime;
using System.Runtime.InteropServices;

class Personagem
{
    public int hp,mana,ataque,velocidade,defesa,inteligencia,alcance,nivel,destreza;
    public string classe,nome,origem,tipoArma,tipoArmadura;
    public double danoRecebido;

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

}

class Mago:Personagem
{
    int magia;
    
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
        while(mana<200)
        {
            mana++;
            Console.WriteLine(mana);
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