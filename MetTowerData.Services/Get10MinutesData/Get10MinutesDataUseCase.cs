using MetTowerData.Domain.Repositories;

namespace MetTowerData.Services.Get10MinutesData
{
    public class Get10MinutesDataUseCase : IGet10MinutesDataUseCase
    {
        private readonly IWindSensorRepository _windSensorRepository;

        public Get10MinutesDataUseCase(IWindSensorRepository windSensorRepository)
        {
            _windSensorRepository = windSensorRepository;
        }

        public async Task<Get10MinutesDataOutPut> Execute(Get10MinutesDataInput input)
        {
            var sensor = await _windSensorRepository.Get(input.WindSensorId);

            if (sensor == null) throw new Exception("Invalid Sensor");

            var startDateTime = input.StartDateTime;
            var endDateTime = input.StartDateTime.AddMinutes(10);

            double averageWindSpeed = sensor.CalculateAverageWindSpeed(startDateTime, endDateTime);
            double minimumWindSpeed = sensor.CalculateMinimumWindSpeed(startDateTime, endDateTime);
            double maximumWindSpeed = sensor.CalculateMaximumWindSpeed(startDateTime, endDateTime);
            double standardDeviatonWindSpeed = sensor.CalculateAverageWindSpeed(startDateTime, endDateTime);

            return new Get10MinutesDataOutPut(
                input.WindSensorId,
                startDateTime,
                endDateTime,
                averageWindSpeed,
                minimumWindSpeed,
                maximumWindSpeed,
                standardDeviatonWindSpeed);
        }
    }
}