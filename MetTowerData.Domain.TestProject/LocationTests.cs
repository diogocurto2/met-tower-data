using MetTowerData.Domain.Entities;

namespace MetTowerData.Domain.TestProject
{
    using Xunit;
    public class LocationTests
    {
        [Fact]
        public void CreateLocation_ShouldCreate()
        {
            // Arrange
            var expectedName = "Location Name";
            double expectedShearCoeficiente = 5.6;

            // Act
            var location = new Location(
                expectedName,
                expectedShearCoeficiente);

            // Assert
            Assert.NotEqual(Guid.Empty, location.Id);
            Assert.Equal(expectedName, location.Name);
            Assert.Equal(expectedShearCoeficiente, location.ShearCoeficiente);
        }
    }
}

