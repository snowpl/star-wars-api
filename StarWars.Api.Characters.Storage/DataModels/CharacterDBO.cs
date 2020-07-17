using StarWars.Api.Characters.Storage.DataModels;

namespace StarWars.Api.Characters.Storage
{
    public class CharacterDBO
    {
        public int Id { get; }
        public string Name { get; private set; }
        public string Planet { get; }
        public StatusDBO Status { get; private set; }
        public CharacterDBO(int id, string name, string planet = "", StatusDBO status = StatusDBO.Active)
        {
            Id = id;
            Name = name;
            Planet = planet;
            Status = status;
        }

        internal void SetStatus(StatusDBO status)
        {
            Status = status;
        }

        internal void ChangeName(string name)
        {
            Name = name;
        }
    }
}
