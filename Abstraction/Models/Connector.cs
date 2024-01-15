namespace Abstraction.Models
{
    [GenerateSerializer]
    public record Connector
    {
        [Id(0)]
        public int Id { get; set; }
        [Id(1)]
        public int ChargePointId { get; set; }
        [Id(2)]
        public int ConnectorId { get; set; }
        [Id(3)]
        public int ConnectorTypeId { get; set; }
        [Id(4)]
        public int Status { get; set; }
        [Id(5)]
        public int Throughput { get; set; }
    }
}
