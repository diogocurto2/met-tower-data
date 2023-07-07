using MetTowerData.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetTowerData.Domain.TestProject
{
    public class WindDataStandardDeviation
    {
        public WindDataStandardDeviation(WindData windData, double value)
        {
            WindDataId = windData.Id;
            WindData = windData;
            Value = value;
        }

        public Guid WindDataId { get; }
        public WindData WindData { get; }
        public double Value { get; }
    }
}
