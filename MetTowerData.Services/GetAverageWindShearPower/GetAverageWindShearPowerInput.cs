namespace MetTowerData.Services.GetAverageWindShearPower
{
    public class GetAverageWindShearPowerInput
    {
        public Guid MetTowerId { get; private set; }
        public DateTime StartDateTime { get; private set; }
        public DateTime EndDateTime { get; private set; }

        public GetAverageWindShearPowerInput(
            Guid windSensorId,
            DateTime startDateTime,
            DateTime endDateTime)
        {
            MetTowerId = windSensorId;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
        }
    }
}
