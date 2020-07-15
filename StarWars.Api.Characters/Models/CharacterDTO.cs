using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Api.Characters.Models
{
    public class CharacterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Planet { get; set; }
        public CharacterDTO(int id, string name, string planet = "")
        {
            Id = id;
            Name = name;
            Planet = planet;
        }
    }
}
