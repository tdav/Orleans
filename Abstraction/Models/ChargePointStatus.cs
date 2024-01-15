using Newtonsoft.Json;
using System.Net.WebSockets;

namespace Abstraction.Models
{
    [GenerateSerializer]
    public record class ChargePointStatus
    {
        [Id(0)]
        public Dictionary<int, OnlineConnectorStatus> OnlineConnectors { get; set; }

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

        /// <summary>
        /// Name of chargepoint
        /// </summary>
        [JsonProperty("name")]
        [Id(4)]
        public string Name { get; set; }

        /// <summary>
        /// OCPP protocol version
        /// </summary>
        [JsonProperty("protocol")]
        [Id(5)]
        public string Protocol { get; set; }

        /// <summary>
        /// WebSocket for internal processing
        /// </summary>
        [JsonIgnore]
        public WebSocket WebSocket { get; set; }
    }
}
