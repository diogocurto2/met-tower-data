using MetTowerData.Domain.Entities;

namespace MetTowerData.Domain.TestProject
{
    using Xunit;
    public class MetTowerTests
    {
        [Fact]
        public void CreateMetTower_ShouldCreate()
        {
            // Arrange
            string expectedName = "Met Tower Test";
            double expectedElevation = 5.9;
            var expectedLocation = new Location("Location test", 5.6);

            //Act
            var metTower = new MetTower(
                expectedName, 
                expectedElevation, 
                expectedLocation);

            // Assert
            Assert.NotEqual(Guid.Empty, metTower.Id);
            Assert.Equal(expectedName, metTower.Name);
            Assert.Equal(expectedElevation, metTower.Elevation);
            Assert.Equal(expectedLocation.Id, metTower.LocationId);
            Assert.Same(expectedLocation, metTower.Location);
        }

        [Fact]
        public void AddWindSensor_ShouldAddToList()
        {
            // Arrange
            var metTower = new MetTower(
                "Met Tower Test",
                5.9,
                new Location("Location test", 5.6));
            int expectedWindySensorHeight = 10;
            string expectedWindySensorOrientation = "North";

            // Act
            metTower.AddWindSensor(expectedWindySensorHeight, expectedWindySensorOrientation);

            // Assert
            Assert.Single(metTower.Sensors);
            Assert.Equal(metTower.Id, metTower.Sensors.First().MetTowerId);
            Assert.Equal(expectedWindySensorOrientation, metTower.Sensors.First().Orientation);
            Assert.Equal(expectedWindySensorHeight, metTower.Sensors.First().Height);
        }

        [Fact]
        public void CalculateAverageWindSpeed_ShouldntReturnAverage()
        {
            // Arrange
            DateTime startTime = DateTime.Now.AddMinutes(-1);
            DateTime endTime = DateTime.Now.AddMinutes(1);
            double expectedAverageWindShearExponent = -1;
            var metTower = new MetTower(
                "Met Tower Test",
                5.9,
                new Location("Location test", 5.6));

            // Act
            var averageWindShearExponent = metTower.CalculateAverageWindShearExponent(startTime, endTime);

            // Assert
            Assert.Equal(expectedAverageWindShearExponent, averageWindShearExponent, 2);
        }


        /// <summary>
        /// I don't know if this calculation is correct.
        /// This is just for demonstration.
        /// </summary>
        [Fact]
        public void CalculateAverageWindSpeed_ShouldReturnAverage()
        {
            // Arrange
            DateTime startTime = DateTime.Now.AddMinutes(-1);
            DateTime endTime = DateTime.Now.AddMinutes(1);
            double expectedAverageWindShearExponent = 0.68;
            var metTower = new MetTower(
                "Met Tower Test",
                5.9,
                new Location("Location test", 5.6));
            metTower.AddWindSensor(5, "North");
            metTower.Sensors.First().AddWindData(DateTime.Now, 5);
            metTower.Sensors.First().AddWindData(DateTime.Now, 5);
            metTower.Sensors.First().AddWindData(DateTime.Now.AddMinutes(3), 7);

            // Act
            var averageWindShearExponent = metTower.CalculateAverageWindShearExponent(startTime, endTime);

            // Assert
            Assert.Equal(expectedAverageWindShearExponent, averageWindShearExponent, 2);
        }
    }
}

