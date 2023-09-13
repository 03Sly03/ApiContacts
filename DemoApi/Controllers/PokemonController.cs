using DemoApi.Data;
using DemoApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly FakePokemonDb _fakePokemonDb;
        public PokemonController(FakePokemonDb fakePokemon)
        {
            _fakePokemonDb = fakePokemon;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var pokemons = _fakePokemonDb.Pokemons;
            if(pokemons.Any())
                return Ok(pokemons); // retourne le statuscode 200
            return NoContent(); // retroune le statuscode 204
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var pokemon = _fakePokemonDb.Pokemons.FirstOrDefault(p => p.Id == id);

            if (pokemon == null)
                return NotFound(new{ Message = "Pokemon non trouvé !" });

            return Ok(new
            {
                Message = "Pokemon Trouvé !",
                Pokemon = pokemon
            });
        }

        [HttpPost]
        public IActionResult Post([FromBody]Pokemon pokemon)
        {
            _fakePokemonDb.Pokemons.Add(pokemon);
            //return Created("route/.../id", "Pokémon ajouté");
            return CreatedAtAction(nameof(Get), "Pokémon ajouté");
        }

        [HttpGet("FindByType/{type}")]
        public IActionResult Get(PokemonType type)
        {
            var pokemons = _fakePokemonDb.Pokemons.Where(p => p.Type1 == type || p.Type2 == type).ToList();

            if (pokemons.Any())
                return Ok(pokemons);

            return NoContent();
        }
    }
}
