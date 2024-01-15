using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models
{
    /// <summary>
    /// Бу таблица ChargePoint ларнинг хозирги пайтдаги холатининг курсаткичлари
    /// </summary>
    public partial class tbConnectorStatus
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string ChargePointId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int ConnectorId { get; set; }
        public int ConnectorTypeId { get; set; }

        [StringLength(100)]
        public string Status { get; set; }
        public DateTime? StatusTime { get; set; }
        public int? Throughput { get; set; }
        public DateTime? MeterValueTime { get; set; }
        public double? ChargeRateKW { get; set; }
        public double? MeterKWH { get; set; }
        public double? Soc { get; set; }

        public int? TransactionId { get; set; }
        public Guid? DriverUserId { get; set; }
        public string DriverUserName { get; set; }
    }
}
