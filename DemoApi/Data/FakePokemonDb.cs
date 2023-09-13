using DemoApi.Models;
using static DemoApi.Models.Pokemon;

namespace DemoApi.Data
{
    public class FakePokemonDb
    {
        public List<Pokemon> Pokemons { get; set; } = new List<Pokemon>()
        {
            new Pokemon()
            {
                Name = "Pikachu",
                Description = "la souris jaune là",
                Level = 10,
                Age = 5,
                Id = 1,
                Type1 = PokemonType.Electrik
            },
            new Pokemon()
            {
                Name = "Evoli",
                Description = "lapin nul",
                Level = 9,
                Age = 2,
                Id = 2,
                Type1 = PokemonType.Normal
            },
            new Pokemon()
            {
                Name = "Dracaufeu",
                Description = "le dragon",
                Level = 53,
                Age = 12,
                Id = 3,
                Type1 = PokemonType.Vol,
                Type2 = PokemonType.Feu
            }
        };
    }
}
