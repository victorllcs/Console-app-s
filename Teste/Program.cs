using System;
using System.Security.Cryptography.X509Certificates;

class Veiculo
{
    public int ano;
    public int cilindradaMotor;
    public string marca;
    public string modelo;
    public int numAssentos;
    public string cor;

    public void Buzinar()
    {
        Console.WriteLine("Beep");
    }

    public void acelerar()
    {
        Console.WriteLine("Acelerando...");
    }

    public void ligar()
    {
        Console.WriteLine("O veículo está em funcionamento");
    }
    
    public void desligar()
    {
        Console.WriteLine("O veículo foi desligado");
    }
}

class Carro:Veiculo
{
    private bool temACC;
    private bool vidrosEletricos;

    public void puxarFreioMao()
    {
        Console.WriteLine("Freio de mão acionado");
    }

    public void subirVidros()
    {
        Console.WriteLine("Subindo vidros...");
    }
}

class Moto:Veiculo
{
    public void puxarGrau()
    {
        Console.WriteLine("244 nato pae");
    }
    public void frear(string tipoFreio)
    {
        Console.WriteLine($"Foi utilizado o freio {tipoFreio} para parar a moto.");
    }
}

class Program
{
    static void Main()
    {
        Carro model1 = new Carro();
        model1.marca = "Nissan";
        model1.modelo= "March";
        model1.ano = 2016;
        model1.cor = "Branco Pérola";
        model1.cilindradaMotor = 1600;
        model1.ligar();
        model1.acelerar();
        model1.desligar();
        model1.puxarFreioMao();

        Moto moto1 = new Moto();
        moto1.marca = "Honda";
        moto1.modelo= "Hornet";
        moto1.ano = 2014;
        moto1.cor = "Branco";
        moto1.cilindradaMotor = 600;
        moto1.ligar();
        moto1.acelerar();
        moto1.puxarGrau();
        moto1.frear("traseiro");        
    }
}
