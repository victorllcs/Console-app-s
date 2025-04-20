namespace primeiraAPI;

public class Veiculo
{
    public string marca { get; set; }

    public string modelo { get; set; }

    public int ano { get; set; }

    public string? cor { get; set; }

    public Veiculo(string marca, string modelo, int ano,string? cor)
    {
        this.marca = marca;
        this.modelo = modelo;
        this.ano = ano;
        this.cor = cor;
    }
}