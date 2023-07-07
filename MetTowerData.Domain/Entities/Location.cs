namespace MetTowerData.Domain.Entities
{
    public class Location
    {
        public Guid Id { get; }
        public string Name { get; }
        public double ShearCoeficiente { get; }

        private Location() { }// Empty Constructor for Entity Framework

        public Location(string name, double shearCoeficiente)
        {
            Id = Guid.NewGuid();
            Name = name;
            ShearCoeficiente = shearCoeficiente;
        }
    }
}
