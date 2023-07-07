namespace MetTowerData.Domain.Entities
{
    public class MetTower
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid LocationId { get; private set; }
        public Location Location { get; private set; }
        public double Elevation { get; private set; }
        
        public IEnumerable<WindSensor> Sensors { get; private set; }

        private MetTower() { } // Empty Constructor for Entity Framework

        public MetTower(
            string name, 
            double elevation,
            Location location)
        {
            Id = Guid.NewGuid();
            Name = name;
            LocationId = location.Id;
            Location = location;
            Elevation = elevation;
            Sensors = Enumerable.Empty<WindSensor>();
        }

        public void AddWindSensor(int windSensorHeight, string windSensorOrientation)
        {
            var windSensor = new WindSensor(this.Id, windSensorHeight, windSensorOrientation);
            Sensors = Sensors.Append(windSensor);
        }

        public double CalculateAverageWindShearExponent(DateTime startTime, DateTime endTime)
        {
            if (!Sensors.Any())
            {
                // Return a default value to indicate no data available
                return -1;
            }

            double sumExponent = 0;

            foreach (var windSensor in Sensors)
            {
                var averageWindSpeed = windSensor.CalculateAverageWindSpeed(startTime, endTime);
                sumExponent += CalculateWindShearExponent(
                        windSensor.Height, averageWindSpeed);
            }

            return sumExponent / Sensors.Count();
        }

        /// <summary>
        /// I don't know if this calculation is correct.
        /// This is just for demonstration.
        /// </summary>
        /// <param name="sensorHeight"></param>
        /// <param name="windSpeed"></param>
        /// <returns></returns>
        private double CalculateWindShearExponent(
            double sensorHeight, double windSpeed)
        {
            double shearExponent =  Math.Log(windSpeed / this.Location.ShearCoeficiente) / Math.Log(sensorHeight / this.Elevation);

            return shearExponent;
        }
    }
}
