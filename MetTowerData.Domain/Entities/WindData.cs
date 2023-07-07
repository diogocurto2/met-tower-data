namespace MetTowerData.Domain.Entities
{
    public class WindData
    {
        public Guid Id { get; }
        public Guid SensorId { get; }
        public DateTime Timestamp { get; }
        public double Velocity { get; }

        private WindData() { } // Empty Constructor for Entity Framework

        public WindData(Guid sensorId,
            DateTime timestamp,
            double velocity)
        {
            Id = Guid.NewGuid();
            SensorId = sensorId;
            Timestamp = timestamp;
            Velocity = velocity;
        }
    }
}