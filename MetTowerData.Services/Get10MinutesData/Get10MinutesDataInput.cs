namespace MetTowerData.Services.Get10MinutesData
{
    public class Get10MinutesDataInput
    {
        public Guid WindSensorId { get; private set; }
        public DateTime StartDateTime { get; private set; }

        public Get10MinutesDataInput(Guid windSensorId, DateTime startDateTime)
        {
            WindSensorId = windSensorId;
            StartDateTime = startDateTime;
        }
    }
}
