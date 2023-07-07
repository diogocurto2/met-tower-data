using MetTowerData.Domain.Entities;
using MetTowerData.Domain.Repositories;
using MetTowerData.Services.Get10MinutesData;
using Moq;

namespace MetTowerData.Services.TestProject
{
    public class Get10MinutesDataUseCaseUnitTest
    {
        [Fact]
        public async Task Get10MinutesDataUseCase_SholdExecute()
        {
            //Arrange
            var dateTime = DateTime.Now;
            var sensor = new WindSensor(Guid.NewGuid(), 10, "North");
            sensor.AddWindData(dateTime, 4);
            sensor.AddWindData(dateTime, 6);
            sensor.AddWindData(dateTime, 10);
            sensor.AddWindData(dateTime, 5);
            var expectedAverageWindSpeed =
                sensor.CalculateAverageWindSpeed(dateTime, dateTime);
            var expectedMinimumWindSpeed =
                sensor.CalculateMinimumWindSpeed(dateTime, dateTime);
            var expectedMaximumWindSpeed =
                sensor.CalculateMaximumWindSpeed(dateTime, dateTime);
            var expectedStandardDeviatonWindSpeed =
                sensor.CalculateStandardDeviatonWindSpeed(dateTime, dateTime);

            var windSensorRepositoryMock = new Mock<IWindSensorRepository>();
            windSensorRepositoryMock
                .Setup(mr => mr.Get(It.IsAny<Guid>()))
                .ReturnsAsync(sensor);

            var input = new Get10MinutesDataInput(sensor.Id, dateTime);
            var useCase = new Get10MinutesDataUseCase(windSensorRepositoryMock.Object);

            //act
            var result = await useCase.Execute(input);

            // Assert
            Assert.Equal(input.WindSensorId, result.WindSensorId);
            Assert.Equal(expectedMaximumWindSpeed, result.MaximumWindSpeed);
            Assert.Equal(expectedAverageWindSpeed, result.AverageWindSpeed);
            Assert.Equal(expectedMinimumWindSpeed, result.MinimumWindSpeed);
            Assert.Equal(expectedStandardDeviatonWindSpeed, result.StandardDeviatonWindSpeed);
        }


        [Fact]
        public async Task Get10MinutesDataUseCase_SholdntExecute()
        {
            //Arrange
            var dateTime = DateTime.Now;
            var sensor = new WindSensor(Guid.NewGuid(), 10, "North");
            var windSensorRepository = new Mock<IWindSensorRepository>();

            var input = new Get10MinutesDataInput(sensor.Id, dateTime);
            var useCase = new Get10MinutesDataUseCase(windSensorRepository.Object);

            //act
            Func<Task<Get10MinutesDataOutPut>> func = () => useCase.Execute(input);

            //assert
            await Assert.ThrowsAsync<Exception>(func);
        }
    }
}