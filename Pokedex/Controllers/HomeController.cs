using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Models;

namespace Pokedex.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Pokemon> pokemons = GetPokemons();
        List<Tipo> tipos = GetTipos();
        ViewData["Tipos"] = tipos;
        return View(pokemons);
    }

    public IActionResult Details(int id)
    {
        List<Pokemon> pokemons = GetPokemons();
        List<Tipo> tipos = GetTipos();
        DetailsVM details = new()
        {
            Tipos = tipos,
            Atual = pokemons.FirstOrDefault(p => p.Numero == id),
            Anterior = pokemons.OrderByDescending(p => p.Numero).FirstOrDefault(p => p.Numero < id),
            Proximo = pokemons.OrderBy(p => p.Numero).FirstOrDefault(p => p.Numero < id),
        };
        return View(details);
    }
    private List<Pokemon> GetPokemons()
    {
        using (StreamReader leitor = new("Data\\pokemons.json"))
        {
            string dados = leitor.ReadToEnd();
            return JsonSerializer.Deserialize<List<Pokemon>>(dados);
        }
    }
    private List<Tipo> GetTipos()
    {
        using (StreamReader leitor = new("Data\\tipos.json"))
        {
            string dados = leitor.ReadToEnd();
            return JsonSerializer.Deserialize<List<Tipo>>(dados);
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
