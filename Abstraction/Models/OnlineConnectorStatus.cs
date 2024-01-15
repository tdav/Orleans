namespace Abstraction.Models
{
    /// <summary>
    /// Encapsulates details about online charge point connectors
    /// </summary>
    [GenerateSerializer]
    public record OnlineConnectorStatus
    {
        /// <summary>
        /// Status of charge connector
        /// </summary>
        [Id(0)]
        public ConnectorStatusEnum Status { get; set; }

        /// <summary>
        /// Current charge rate in kW
        /// </summary>
        [Id(1)]
        public double? ChargeRateKW { get; set; }

        /// <summary>
        /// Current meter value in kWh
        /// </summary>
        [Id(2)]
        public double? MeterKWH { get; set; }

        /// <summary>
        /// StateOfCharges in percent
        /// </summary>
        [Id(3)]
        public double? Soc { get; set; }

        [Id(4)]
        public Guid? CurUserId { get; set; }

        [Id(5)]
        public int ConnectorTypeId { get; set; }

        /// <summary>
        /// Пропускная способность
        /// </summary>
        [Id(6)]
        public int Throughput { get; set; }
    }
}
