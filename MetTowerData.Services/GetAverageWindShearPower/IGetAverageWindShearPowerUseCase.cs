namespace MetTowerData.Services.GetAverageWindShearPower
{
    public interface IGetAverageWindShearPowerUseCase
    {
        Task<GetAverageWindShearPowerOutPut> Execute(GetAverageWindShearPowerInput input);
    }
}