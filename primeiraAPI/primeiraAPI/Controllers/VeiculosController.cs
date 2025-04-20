using Microsoft.AspNetCore.Mvc;

namespace primeiraAPI.Controllers;

[ApiController]
[Route("api/veiculos")]

public class VeiculosController: ControllerBase
{
    private static Dictionary<string, List<Veiculo>> veiculosPorMarca = new();
    
    private static readonly string[] marcas = new[]
    {
        "Toyota", "Honda", "Nissan", "Fiat", "Jeep", "Peugeot", "Citroen", "Hyundai", "Kia", "Audi"
    };

    private readonly ILogger<VeiculosController> _logger;

    public VeiculosController(ILogger<VeiculosController> logger)
    {
        _logger = logger;
    }

    [HttpGet("marcas/{marca}")]
    public IActionResult GetMarcas(string marca)
    {
        foreach (var carros in marcas)
        {
            if (marca.Equals(carros, StringComparison.InvariantCultureIgnoreCase))
                return Ok(carros);
        }
        return NotFound("Marca não encontrada.");
    }

    [HttpPost("adicionar")]
    public IActionResult Adicionar([FromBody] Veiculo newVeiculo)
    {
        if(!veiculosPorMarca.ContainsKey(newVeiculo.marca))
            veiculosPorMarca[newVeiculo.marca] = new List<Veiculo>();
        
        veiculosPorMarca[newVeiculo.marca].Add(newVeiculo);
        return Ok($"Veículo adicionado com sucesso.{newVeiculo}");
    }

    [HttpPost("buscar/{marca}")]
    public IActionResult Buscar(string marca)
    {
        if(veiculosPorMarca.TryGetValue(marca, out var lista))
            return Ok(lista);
        
        return NotFound("Marca não encontrada");
    }

    [HttpDelete("remover/{marca}")]
    public IActionResult RemoverVeiculo(string marca)
    {
        if (veiculosPorMarca.Remove(marca))
            return Ok($"Todos os veículos da marca {marca} foram removidos com sucesso.");
        
        return NotFound($"Marca não foi encontrada");
    }
}