using FluentAssertions;
using Moq;
using StarWars.Api.Characters.Contracts;
using StarWars.Api.Characters.Storage;
using StarWars.Api.Episodes;
using StarWars.Api.Episodes.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StarWars.Api.Characters.Tests
{
    public class CharacterServiceTests
    {
        private readonly Mock<ICharacterRepository> _mockCharacterRepo;
        private readonly Mock<IEpisodesService> _mockEpisodeService;
        private readonly ICharactersService _sut;
        public CharacterServiceTests()
        {
            _mockCharacterRepo = new Mock<ICharacterRepository>();
            _mockEpisodeService = new Mock<IEpisodesService>();
            _sut = new CharactersService(
                _mockCharacterRepo.Object,
                _mockEpisodeService.Object
                );
        }

        [Fact]
        public async Task WhenAllServicesReturnsFineData_ThenReturnsValidData()
        {
            //Arrange
            _mockCharacterRepo.Setup(x => x.GetAllCharacters())
                .Returns(new List<CharacterDBO>()
                {
                    new CharacterDBO(1, "Jabba", "TestPlanet", Storage.DataModels.StatusDBO.Active),
                    new CharacterDBO(2, "OTest", "TestPlanet", Storage.DataModels.StatusDBO.Active),
                    new CharacterDBO(3, "Palpi", "TestPlanet", Storage.DataModels.StatusDBO.Active),
                }.AsQueryable());

            _mockCharacterRepo.Setup(x => x.GetAllCharactersFriends(It.IsAny<IEnumerable<int>>()))
                .Returns(new List<CharacterFriendDBO>()
                {
                    new CharacterFriendDBO(1, 2),
                    new CharacterFriendDBO(3, 1),
                }.AsQueryable());

            _mockEpisodeService.Setup(x => x.GetAllEpisodes())
                .Returns(new List<EpisodeDTO>()
                {
                    new EpisodeDTO(7, "I do not exist.")
                }.AsQueryable());

            _mockEpisodeService.Setup(x => x.GetAllEpisodesCharacters(It.IsAny<IEnumerable<int>>()))
                .ReturnsAsync(new List<EpisodeCharacterDTO>()
                {
                    new EpisodeCharacterDTO(7, 1),
                    new EpisodeCharacterDTO(7, 2),
                    new EpisodeCharacterDTO(7, 3),
                }.AsEnumerable());

            //Act
            var result = await _sut.List(new GetCharactersQuery(10, 1));
            //Assert

            result.PagingInfo.TotalCount.Should().Be(3);
            result.Results.First().Name.Should().Be("Jabba");
            result.Results.ToList()[2].Name.Should().Be("Palpi");
        }
    }
}
