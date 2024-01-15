namespace Abstraction.Models
{
    public interface IConnectorGrain : IGrainWithIntegerKey
    {
        Task<Connector> GetAsync();
    }
}
