using MetTowerData.Domain.Entities;

namespace MetTowerData.Domain.TestProject
{
    using Xunit;

    public class WindSensorTests
    {
        [Fact]
        public void AddWindData_ShouldCreate()
        {
            // Arrange
            Guid expectedMetTowerId = Guid.NewGuid();
            int expectedWindySensorHeight = 10;
            string expectedWindySensorOrientation = "North";

            // Act
            var sensor = new WindSensor(
                expectedMetTowerId,
                expectedWindySensorHeight,
                expectedWindySensorOrientation);

            // Assert
            Assert.NotNull(sensor.Data);
            Assert.NotEqual(Guid.Empty, sensor.Id);
            Assert.Equal(expectedWindySensorOrientation, sensor.Orientation);
            Assert.Equal(expectedWindySensorHeight, sensor.Height);
            Assert.Equal(expectedMetTowerId, sensor.MetTowerId);
        }

        [Fact]
        public void AddWindData_ShouldAddDataToList()
        {
            // Arrange
            DateTime expectedTimestamp = DateTime.Now;
            double expectedWindyVelocity = 6.7;
            var sensor = new WindSensor(Guid.NewGuid(), 10, "North");

            // Act
            sensor.AddWindData(expectedTimestamp, expectedWindyVelocity);

            // Assert
            Assert.Single(sensor.Data);
            Assert.Equal(sensor.Id, sensor.Data.First().SensorId);
            Assert.Equal(expectedTimestamp, sensor.Data.First().Timestamp);
            Assert.Equal(expectedWindyVelocity, sensor.Data.First().Velocity);
        }

        [Fact]
        public void CalculateAverageWindSpeed_ShouldReturnAverage()
        {
            // Arrange
            DateTime startTime = DateTime.Now.AddMinutes(-1);
            DateTime endTime = DateTime.Now.AddMinutes(1);
            double expectedAverageWindyVelocity = 5;

            var sensor = new WindSensor(Guid.NewGuid(), 10, "North");
            sensor.AddWindData(DateTime.Now, 4);
            sensor.AddWindData(DateTime.Now, 6);
            sensor.AddWindData(DateTime.Now.AddMinutes(3), 7);

            // Act
            var averageWindSpeed = sensor.CalculateAverageWindSpeed(startTime, endTime);

            // Assert
            Assert.Equal(expectedAverageWindyVelocity, averageWindSpeed, 2);
        }

        [Fact]
        public void CalculateAverageWindSpeed_ShouldntReturnAverage()
        {
            // Arrange
            DateTime startTime = DateTime.Now.AddMinutes(-1);
            DateTime endTime = DateTime.Now.AddMinutes(1);
            double expectedAverageWindyVelocity = -1;

            var sensor = new WindSensor(Guid.NewGuid(), 10, "North");

            // Act
            var averageWindSpeed = sensor.CalculateAverageWindSpeed(startTime, endTime);

            // Assert
            Assert.Equal(expectedAverageWindyVelocity, averageWindSpeed, 2);
        }

        [Fact]
        public void CalculateMinimumWindSpeed_ShouldReturnAverage()
        {
            // Arrange
            DateTime startTime = DateTime.Now.AddMinutes(-1);
            DateTime endTime = DateTime.Now.AddMinutes(1);
            double expectedMinimumWindyVelocity = 4;

            var sensor = new WindSensor(Guid.NewGuid(), 10, "North");
            sensor.AddWindData(DateTime.Now, 4);
            sensor.AddWindData(DateTime.Now, 6);
            sensor.AddWindData(DateTime.Now.AddMinutes(3), 7);

            // Act
            var minimumWindSpeed = sensor.CalculateMinimumWindSpeed(startTime, endTime);

            // Assert
            Assert.Equal(expectedMinimumWindyVelocity, minimumWindSpeed, 2);
        }

        [Fact]
        public void CalculateMinimumWindSpeed_ShouldntReturnAverage()
        {
            // Arrange
            DateTime startTime = DateTime.Now.AddMinutes(-1);
            DateTime endTime = DateTime.Now.AddMinutes(1);
            double expectedMinimumWindyVelocity = -1;

            var sensor = new WindSensor(Guid.NewGuid(), 10, "North");

            // Act
            var minimumWindSpeed = sensor.CalculateAverageWindSpeed(startTime, endTime);

            // Assert
            Assert.Equal(expectedMinimumWindyVelocity, minimumWindSpeed, 2);
        }

        [Fact]
        public void CalculateMaximumWindSpeed_ShouldReturnAverage()
        {
            // Arrange
            DateTime startTime = DateTime.Now.AddMinutes(-1);
            DateTime endTime = DateTime.Now.AddMinutes(1);
            double expectedMaximumWindyVelocity = 6;

            var sensor = new WindSensor(Guid.NewGuid(), 10, "North");
            sensor.AddWindData(DateTime.Now, 4);
            sensor.AddWindData(DateTime.Now, 6);
            sensor.AddWindData(DateTime.Now.AddMinutes(3), 7);

            // Act
            var maximumWindSpeed = sensor.CalculateMaximumWindSpeed(startTime, endTime);

            // Assert
            Assert.Equal(expectedMaximumWindyVelocity, maximumWindSpeed, 2);
        }

        [Fact]
        public void CalculateMaximumWindSpeed_ShouldntReturnAverage()
        {
            // Arrange
            DateTime startTime = DateTime.Now.AddMinutes(-1);
            DateTime endTime = DateTime.Now.AddMinutes(1);
            double expectedMaximumWindyVelocity = -1;

            var sensor = new WindSensor(Guid.NewGuid(), 10, "North");

            // Act
            var maximumWindSpeed = sensor.CalculateAverageWindSpeed(startTime, endTime);

            // Assert
            Assert.Equal(expectedMaximumWindyVelocity, maximumWindSpeed, 2);
        }

        [Fact]
        public void CalculateStandardDeviatonWindSpeed_ShouldReturnAverage()
        {
            // Arrange
            DateTime startTime = DateTime.Now.AddMinutes(-1);
            DateTime endTime = DateTime.Now.AddMinutes(1);
            double expectedStandardDeviatonWindyVelocity = 2.28;

            var sensor = new WindSensor(Guid.NewGuid(), 10, "North");
            sensor.AddWindData(DateTime.Now, 4);
            sensor.AddWindData(DateTime.Now, 6);
            sensor.AddWindData(DateTime.Now, 10);
            sensor.AddWindData(DateTime.Now, 5);

            // Act
            var standardDeviatonWindyVelocity = sensor.CalculateStandardDeviatonWindSpeed(startTime, endTime);

            // Assert
            Assert.Equal(expectedStandardDeviatonWindyVelocity, standardDeviatonWindyVelocity, 2);
        }

        [Fact]
        public void CalculateStandardDeviatonWindSpeed_ShouldntReturnAverage()
        {
            // Arrange
            DateTime startTime = DateTime.Now.AddMinutes(-1);
            DateTime endTime = DateTime.Now.AddMinutes(1);
            double expectedStandardDeviatonWindyVelocity = -1;

            var sensor = new WindSensor(Guid.NewGuid(), 10, "North");

            // Act
            var standardDeviatonWindyVelocity = sensor.CalculateStandardDeviatonWindSpeed(startTime, endTime);

            // Assert
            Assert.Equal(expectedStandardDeviatonWindyVelocity, standardDeviatonWindyVelocity, 2);
        }
    }
}