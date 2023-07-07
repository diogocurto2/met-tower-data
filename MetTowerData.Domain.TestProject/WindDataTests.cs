using MetTowerData.Domain.Entities;

namespace MetTowerData.Domain.TestProject
{
    using Xunit;
    public class WindDataTests
    {
        [Fact]
        public void CreateWindData_ShouldCreate()
        {
            // Arrange
            var expectedSensorId = Guid.NewGuid();
            DateTime expectedTimestamp = DateTime.Now;
            double expectedWindyVelocity = 6.7;

            // Act
            var windData = new WindData(
                expectedSensorId, 
                expectedTimestamp, 
                expectedWindyVelocity);

            // Assert
            Assert.NotEqual(Guid.Empty, windData.Id);
            Assert.Equal(expectedSensorId, windData.SensorId);
            Assert.Equal(expectedTimestamp, windData.Timestamp);
            Assert.Equal(expectedWindyVelocity, windData.Velocity);
        }


        [Fact]
        public void CreateWindData_ShouldSetStandardDeviaton()
        {
            // Arrange
            double expectedStandardDeviaton = 6.7;
            var windData = new WindData(Guid.NewGuid(), DateTime.Now, 6.7);

            // Act
            windData.SetStandardDeviaton(expectedStandardDeviaton);

            // Assert
            Assert.Equal(expectedStandardDeviaton, windData.StandardDeviaton);
        }
    }
}

