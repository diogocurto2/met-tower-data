using MetTowerData.Domain.Repositories;

namespace MetTowerData.Services.GetAverageWindSpeed
{
    public class GetAverageWindSpeedUseCase : IGetAverageWindSpeedUseCase
    {
        private readonly IWindSensorRepository _windSensorRepository;

        public GetAverageWindSpeedUseCase(IWindSensorRepository windSensorRepository)
        {
            _windSensorRepository = windSensorRepository;
        }

        public async Task<GetAverageWindSpeedOutPut> Execute(GetAverageWindSpeedInput input)
        {
            var sensor = await _windSensorRepository.Get(input.WindSensorId);

            if (sensor == null) throw new Exception("Invalid Sensor");

            var averageWindSpeed =
                sensor.CalculateStandardDeviatonWindSpeed(
                    input.StartDateTime,
                    input.EndDateTime);

            return new GetAverageWindSpeedOutPut(
                input.WindSensorId,
                input.StartDateTime,
                input.EndDateTime,
                averageWindSpeed);
        }
    }
}
