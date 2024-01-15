using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class tbConnector
    {
        [Key]
        public int Id { get; set; }
        public int ChargePointId { get; set; }
        public virtual tbChargePoint ChargePoint { get; set; }
        public int ConnectorId { get; set; }
        public int ConnectorTypeId { get; set; }
        public new int Status { get; set; }
        public int Throughput { get; set; }
    }
}
