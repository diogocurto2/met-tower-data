namespace MetTowerData.Domain.Entities
{
    public class WindSensor
    {
        public Guid Id { get; }
        public int Height { get; }
        public string Orientation { get; }
        public Guid MetTowerId { get; }
        public IEnumerable<WindData> Data { get; private set; }

        private WindSensor() { } // Empty Constructor for Entity Framework

        public WindSensor(Guid metTowerId, int height, string orientation)
        {
            Id = Guid.NewGuid();
            MetTowerId = metTowerId;
            Height = height;
            Orientation = orientation;
            Data = Enumerable.Empty<WindData>();
        }

        public void AddWindData(
            DateTime timestamp,
            double windyVelocity)
        {
            var windData = new WindData(this.Id, timestamp, windyVelocity);
            Data = Data.Append(windData);
        }

        public double CalculateAverageWindSpeed(DateTime startTime, DateTime endTime)
        {
            List<WindData> rangeData = GetWindDataByDateTime(startTime, endTime);

            if (!rangeData.Any())
            {
                // Return a default value to indicate no data available
                return -1;
            }

            double sum = rangeData.Sum(data => data.Velocity);
            return sum / rangeData.Count();
        }

        private List<WindData> GetWindDataByDateTime(DateTime startTime, DateTime endTime)
        {
            return Data.Where(d => d.Timestamp > startTime && d.Timestamp < endTime).ToList();
        }

        public double CalculateMinimumWindSpeed(DateTime startTime, DateTime endTime)
        {
            List<WindData> rangeData = GetWindDataByDateTime(startTime, endTime);

            if (!rangeData.Any())
            {
                // Return a default value to indicate no data available
                return -1;
            }

            return rangeData.Min(data => data.Velocity);
        }

        public double CalculateMaximumWindSpeed(DateTime startTime, DateTime endTime)
        {
            List<WindData> rangeData = GetWindDataByDateTime(startTime, endTime);

            if (!rangeData.Any())
            {
                // Return a default value to indicate no data available
                return -1;
            }

            return rangeData.Max(data => data.Velocity);
        }

        public double CalculateStandardDeviatonWindSpeed(DateTime startTime, DateTime endTime)
        {
            List<WindData> rangeData = GetWindDataByDateTime(startTime, endTime);

            if (!rangeData.Any())
            {
                // Return a default value to indicate no data available
                return -1;
            }

            double averageWindSpeed = CalculateAverageWindSpeed(startTime, endTime);

            double sumSquareDistance = 0;
            foreach (var windData in rangeData)
            {
                double distance = windData.Velocity - averageWindSpeed;
                double squareDistance = Math.Pow(distance, 2);

                sumSquareDistance += squareDistance;
            }

            double standardDeviaton = Math.Sqrt(sumSquareDistance / rangeData.Count);

            return standardDeviaton;
        }
    }

}
