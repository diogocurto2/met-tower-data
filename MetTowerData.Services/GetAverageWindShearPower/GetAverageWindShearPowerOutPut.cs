namespace MetTowerData.Services.GetAverageWindShearPower
{
    public class GetAverageWindShearPowerOutPut
    {
        public Guid MetTowerId { get; private set; }
        public DateTime StartDateTime { get; private set; }
        public DateTime EndDateTime { get; private set; }
        public double AverageWindSpeed { get; }

        public GetAverageWindShearPowerOutPut(
            Guid metTowerId,
            DateTime startDateTime,
            DateTime endDateTime,
            double averageWindSpeed)
        {
            MetTowerId = metTowerId;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            AverageWindSpeed = averageWindSpeed;
        }
    }
}
