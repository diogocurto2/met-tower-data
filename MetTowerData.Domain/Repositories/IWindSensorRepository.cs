using MetTowerData.Domain.Entities;

namespace MetTowerData.Domain.Repositories
{
    public interface IWindSensorRepository
    {
        public Task<WindSensor> Get(Guid id);
    }
}
