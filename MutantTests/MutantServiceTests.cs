using MutantDetection.Services;
using MutantDetection.Services.Interfaces;
namespace MutantAPI.Tests
{
    public class MutantServiceTests
    {
        private readonly IMutantService _mutantService;
        public MutantServiceTests()
        {
            _mutantService = new MutantService();
        }

        [Fact]
        public void IsMutant_ReturnsTrue_WhenDnaContainsTwoSequences()
        {
            // Arrange
            var dna = new string[]
            {
            "ATGCGA",
            "CAGTGC",
            "TTATGT",
            "AGAAGG",
            "CCCCTA",
            "TCACTG"
            };
            // Act
            bool result = _mutantService.IsMutant(dna);
            // Assert
            Assert.True(result);
        }
        [Fact]
        public void IsMutant_ReturnsFalse_WhenDnaDoesNotContainTwoSequences()
        {
            // Arrange
            var dna = new string[]
            {
            "ATGCGA",
            "CAGTGC",
            "TTATTT",
            "AGACGG",
            "GCGTCA",
            "TCACTG"
            };
            // Act
            bool result = _mutantService.IsMutant(dna);
            // Assert
            Assert.False(result);
        }
        [Fact]
        public void IsMutant_ThrowsException_WhenDnaIsInvalid()
        {
            // Arrange
            var dna = new string[]
            {
            "ATGCGA",
            "CAGTGC",
            "INVALID",
            "AGACGG"
            };
            // Act & Assert
            Assert.Throws<ArgumentException>(() => _mutantService.IsMutant(dna));
        }
        [Fact]
        public void IsMutant_ThrowsException_WhenDnaIsNullOrEmpty()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => _mutantService.IsMutant(null));
            Assert.Throws<ArgumentException>(() => _mutantService.IsMutant(new string[] { }));
        }
    }
}