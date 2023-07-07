using MetTowerData.Domain.Entities;
using MetTowerData.Domain.Repositories;
using MetTowerData.Services.Get10MinutesData;
using MetTowerData.Services.GetAverageWindShearPower;
using Moq;

namespace MetTowerData.Services.TestProject
{
    public class GetAverageWindShearPowerUseCaseUnitTest
    {
        [Fact]
        public async Task GetAverageWindShearPowerUseCase_SholdExecute()
        {
            //Arrange
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

            var MetTowerRepositoryMock = new Mock<IMetTowerRepository>();
            MetTowerRepositoryMock
                .Setup(mr => mr.Get(It.IsAny<Guid>()))
                .ReturnsAsync(metTower);

            var input = new GetAverageWindShearPowerInput(
                metTower.Id, 
                startTime, 
                endTime);
            var useCase = new GetAverageWindShearPowerUseCase(
                MetTowerRepositoryMock.Object);

            //act
            var result = await useCase.Execute(input);

            // Assert
            Assert.Equal(input.MetTowerId, result.MetTowerId);
            Assert.Equal(expectedAverageWindShearExponent, result.AverageWindSpeed, 2);
        }


        [Fact]
        public async Task GetAverageWindShearPowerUseCase_SholdntExecute()
        {
            //Arrange
            var startDateTime = DateTime.Now;
            var endDateTime = DateTime.Now;
            var metTower = new MetTower(
                "Met Tower Test",
                5.9,
                new Location("Location test", 5.6));
            var MetTowerRepository = new Mock<IMetTowerRepository>();

            var input = new GetAverageWindShearPowerInput(metTower.Id, startDateTime, endDateTime);
            var useCase = new GetAverageWindShearPowerUseCase(MetTowerRepository.Object);

            //act
            Func<Task<GetAverageWindShearPowerOutPut>> func = () => useCase.Execute(input);

            //assert
            await Assert.ThrowsAsync<Exception>(func);
        }
    }
}