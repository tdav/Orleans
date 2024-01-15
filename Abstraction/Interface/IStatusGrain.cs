namespace Abstraction.Models
{
    public interface IStatusGrain : IGrainWithStringKey
    {
        Task<ChargePointStatus> GetAsync();
    }
}
