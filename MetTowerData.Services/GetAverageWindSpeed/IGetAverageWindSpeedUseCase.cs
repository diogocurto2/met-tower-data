namespace MetTowerData.Services.GetAverageWindSpeed
{
    public interface IGetAverageWindSpeedUseCase
    {
        Task<GetAverageWindSpeedOutPut> Execute(GetAverageWindSpeedInput input);
    }
}