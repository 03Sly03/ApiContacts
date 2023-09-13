using System.ComponentModel.DataAnnotations;

namespace DemoApi.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Le champ 'Nom' est requis")]
        [StringLength(30, ErrorMessage = "La taille maximum du champs 'Nom' est de 30 charactères")]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Age { get; set; }
        public int Level { get; set; }
        public PokemonType Type1 { get; set; }
        public PokemonType? Type2 { get; set; }
    }
    public enum PokemonType
    {
        Acier,
        Combat,
        Dragon,
        Eau,
        Electrik,
        Feu,
        Fee,
        Glace,
        Insecte,
        Normal,
        Plante,
        Poison,
        Psy,
        Roche,
        Sol,
        Spectre,
        Tenebres,
        Vol
    }
}
