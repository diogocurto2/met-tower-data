namespace MetTowerData.Services.GetAverageWindSpeed
{
    public class GetAverageWindSpeedInput
    {
        public Guid WindSensorId { get; private set; }
        public DateTime StartDateTime { get; private set; }
        public DateTime EndDateTime { get; private set; }

        public GetAverageWindSpeedInput(
            Guid windSensorId,
            DateTime startDateTime,
            DateTime endDateTime)
        {
            WindSensorId = windSensorId;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
        }
    }
}
