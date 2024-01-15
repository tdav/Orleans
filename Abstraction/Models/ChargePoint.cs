namespace Abstraction.Models
{
    [GenerateSerializer]
    public record ChargePoint
    {
        [Id(0)]
        public int Id { get; set; }
        [Id(1)]
        public string ChargePointId { get; set; }
        [Id(2)]
        public string Name { get; set; }
        [Id(3)]
        public string Username { get; set; }
        [Id(4)]
        public string Password { get; set; }
        [Id(5)]
        public string ClientCertThumb { get; set; }
        [Id(6)]
        public double Latitude { get; set; }
        [Id(7)]
        public double Longitude { get; set; }
        [Id(8)]
        public string Street { get; set; }
        [Id(9)]
        public string Landmark { get; set; }
        [Id(10)]
        public int Status { get; set; }

        [Id(11)]
        public List<Connector> Connectors { get; set; }
    }
}
