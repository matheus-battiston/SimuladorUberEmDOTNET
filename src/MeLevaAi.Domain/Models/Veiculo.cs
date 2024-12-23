namespace MeLevaAi.Domain.Models;

using System;
using static Guid;

public class Veiculo
{
    public Veiculo(string placa, string modelo, string cor, string? fotoUrl, Categoria categoria)
    {
        Placa = placa;
        Modelo = modelo;
        Cor = cor;
        FotoUrl = fotoUrl;
        Categoria = categoria;
    }

    public Veiculo()
    {
        
    }
    public Guid Id { get; init; } = NewGuid();

    public string Placa { get; private set; }
    
    public string Modelo { get; private set; }
    
    public string Cor { get; private set; }

    public string? FotoUrl { get; private set; }
    
    public Categoria Categoria { get; private set; }
    
}
