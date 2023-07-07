namespace MetTowerData.Services.Get10MinutesData
{
    public interface IGet10MinutesDataUseCase
    {
        Task<Get10MinutesDataOutPut> Execute(Get10MinutesDataInput input);
    }
}