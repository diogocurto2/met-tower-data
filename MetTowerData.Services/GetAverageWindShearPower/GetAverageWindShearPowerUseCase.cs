using MetTowerData.Domain.Repositories;
using MetTowerData.Services.Get10MinutesData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetTowerData.Services.GetAverageWindShearPower
{
    public class GetAverageWindShearPowerUseCase : IGetAverageWindShearPowerUseCase
    {

        private readonly IMetTowerRepository _metTowerRepository;

        public GetAverageWindShearPowerUseCase(IMetTowerRepository metTowerRepository)
        {
            _metTowerRepository = metTowerRepository;
        }

        public async Task<GetAverageWindShearPowerOutPut> Execute(GetAverageWindShearPowerInput input)
        {
            var metTower = await _metTowerRepository.Get(input.MetTowerId);

            if (metTower == null) throw new Exception("Invalid Met Tower");

            var averageWindShearExponent =
                metTower.CalculateAverageWindShearExponent(
                    input.StartDateTime,
                    input.EndDateTime);

            return new GetAverageWindShearPowerOutPut(
                input.MetTowerId,
                input.StartDateTime,
                input.EndDateTime,
                averageWindShearExponent);
        }
    }
}
