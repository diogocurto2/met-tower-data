namespace MetTowerData.Services.GetAverageWindSpeed
{
    public class GetAverageWindSpeedOutPut
    {
        public Guid WindSensorId { get; private set; }
        public DateTime StartDateTime { get; private set; }
        public DateTime EndDateTime { get; private set; }
        public double AverageWindSpeed { get; }

        public GetAverageWindSpeedOutPut(
            Guid windSensorId,
            DateTime startDateTime,
            DateTime endDateTime,
            double averageWindSpeed)
        {
            WindSensorId = windSensorId;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            AverageWindSpeed = averageWindSpeed;
        }
    }
}
