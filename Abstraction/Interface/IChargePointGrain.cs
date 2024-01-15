using Abstraction.Models;

namespace Abstraction.Interface
{
    public interface IChargePointGrain : IGrainWithStringKey
    {
        Task<ChargePoint> GetAsync();
    }
}
