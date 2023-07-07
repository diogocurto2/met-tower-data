using MetTowerData.Domain.Entities;
using MetTowerData.Domain.Repositories;
using MetTowerData.Services.Get10MinutesData;
using MetTowerData.Services.GetAverageWindSpeed;
using Moq;

namespace MetTowerData.Services.TestProject
{
    public class GetAverageWindSpeedUseCaseUnitTest
    {
        [Fact]
        public async Task GetAverageWindSpeedUseCase_SholdExecute()
        {
            //Arrange
            var startDateTime = DateTime.Now;
            var endDateTime = DateTime.Now;
            var sensor = new WindSensor(Guid.NewGuid(), 10, "North");
            sensor.AddWindData(startDateTime, 4);
            sensor.AddWindData(startDateTime, 6);
            var expectedAverageWindSpeed =
                sensor.CalculateAverageWindSpeed(startDateTime, startDateTime);

            var windSensorRepositoryMock = new Mock<IWindSensorRepository>();
            windSensorRepositoryMock
                .Setup(mr => mr.Get(It.IsAny<Guid>()))
                .ReturnsAsync(sensor);

            var input = new GetAverageWindSpeedInput(
                sensor.Id, 
                startDateTime, 
                endDateTime);
            var useCase = new GetAverageWindSpeedUseCase(
                windSensorRepositoryMock.Object);

            //act
            var result = await useCase.Execute(input);

            // Assert
            Assert.Equal(input.WindSensorId, result.WindSensorId);
            Assert.Equal(expectedAverageWindSpeed, result.AverageWindSpeed, 2);
        }


        [Fact]
        public async Task GetAverageWindSpeedUseCase_SholdntExecute()
        {
            //Arrange
            var startDateTime = DateTime.Now;
            var endDateTime = DateTime.Now;
            var sensor = new WindSensor(Guid.NewGuid(), 10, "North");
            var windSensorRepository = new Mock<IWindSensorRepository>();

            var input = new GetAverageWindSpeedInput(sensor.Id, startDateTime, endDateTime);
            var useCase = new GetAverageWindSpeedUseCase(windSensorRepository.Object);

            //act
            Func<Task<GetAverageWindSpeedOutPut>> func = () => useCase.Execute(input);

            //assert
            await Assert.ThrowsAsync<Exception>(func);
        }
    }
}