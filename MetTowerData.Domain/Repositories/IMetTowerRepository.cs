using MetTowerData.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetTowerData.Domain.Repositories
{
    public interface IMetTowerRepository
    {
        public Task<MetTower> Get(Guid id);
    }
}
