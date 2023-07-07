namespace MetTowerData.Services.Get10MinutesData
{
    public class Get10MinutesDataOutPut
    {
        public Get10MinutesDataOutPut(
            Guid windSensorId, 
            DateTime startDateTime, 
            DateTime endDateTime, 
            double averageWindSpeed, 
            double minimumWindSpeed,
            double maximumWindSpeed,
            double standardDeviatonWindSpeed)
        {
            WindSensorId = windSensorId;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            AverageWindSpeed = averageWindSpeed;
            MaximumWindSpeed = maximumWindSpeed;
            MinimumWindSpeed = minimumWindSpeed;
            StandardDeviatonWindSpeed = standardDeviatonWindSpeed;
        }

        public Guid WindSensorId { get; private set; }
        public DateTime StartDateTime { get; private set; }
        public DateTime EndDateTime { get; private set; }
        public double AverageWindSpeed { get; }
        public double MinimumWindSpeed { get; }
        public double MaximumWindSpeed { get; }
        public double StandardDeviatonWindSpeed { get; }
    }
}
