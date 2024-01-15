using Newtonsoft.Json;
using System.Net.WebSockets;

namespace Abstraction.Models
{
    [GenerateSerializer]
    public record class ChargePointStatus
    {
        [Id(0)]
        private Dictionary<int, OnlineConnectorStatus> _onlineConnectors;

        public ChargePointStatus(ChargePoint chargePoint)
        {
            KeyId = chargePoint.Id;
            Id = chargePoint.ChargePointId;
            Name = chargePoint.Name;

            foreach (var it in chargePoint.Connectors)
            {
                var cc = new OnlineConnectorStatus()
                {
                    Throughput = it.Throughput,
                    ConnectorTypeId = it.ConnectorTypeId,
                    CurUserId = null,
                    Soc = 0,
                    MeterKWH = 0,
                    ChargeRateKW = 0,
                    Status = ConnectorStatusEnum.Undefined,
                };

                OnlineConnectors.Add(it.ConnectorId, cc);
            }
        }

        public Dictionary<int, OnlineConnectorStatus> OnlineConnectors
        {
            get
            {
                if (_onlineConnectors == null)
                {
                    _onlineConnectors = new Dictionary<int, OnlineConnectorStatus>();
                }
                return _onlineConnectors;
            }
            set
            {
                _onlineConnectors = value;
            }
        }

        /// <summary>
        /// ForenKey
        /// </summary>
        [Id(1)]
        public int KeyId { get; set; }

        [Id(2)]
        public DateTime? HeartBeatDateTime { get; set; }


        /// <summary>
        /// ID of chargepoint
        /// </summary>
        [JsonProperty("id")]
        [Id(3)]
        public string Id { get; set; }

        [JsonProperty("connectorId")]
        [Id(4)]
        public string ConnectorId { get; set; }

        /// <summary>
        /// Name of chargepoint
        /// </summary>
        [JsonProperty("name")]
        [Id(5)]
        public string Name { get; set; }

        /// <summary>
        /// OCPP protocol version
        /// </summary>
        [JsonProperty("protocol")]
        [Id(6)]
        public string Protocol { get; set; }

        /// <summary>
        /// WebSocket for internal processing
        /// </summary>
        [JsonIgnore]
        [Id(7)]
        public WebSocket WebSocket { get; set; }
    }
}
