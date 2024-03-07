namespace Pokedex.Models;

public class DetailsVM
{
    public Pokemon Anterior {get; set;}
    public Pokemon Atual {get; set;}
    public Pokemon Proximo {get; set;}
    public List<Tipo> Tipos {get; set;}
}
