using Abstraction.Interface;
using Abstraction.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OcppController : ControllerBase
    {
        private readonly ILogger<OcppController> logger;
        private readonly IClusterClient clusterClient;

        public OcppController(ILogger<OcppController> logger, IClusterClient clusterClient)
        {
            this.logger = logger;
            this.clusterClient = clusterClient;
        }

        [HttpGet("ChargePoint/{id}")]
        public async Task<ChargePoint> GetChargePoint(string id)
        {
            var grain = clusterClient.GetGrain<IChargePointGrain>(id);
            var res = await grain.GetAsync();
            return res;
        }

        [HttpGet("Connector/{id}")]
        public async Task<Connector> GetConnector(int id)
        {
            var grain = clusterClient.GetGrain<IConnectorGrain>(id);
            var res = await grain.GetAsync();
            return res;
        }

        [HttpGet("StatusGrain/{id}")]
        public async Task<ChargePointStatus> GetStatus(string id)
        {
            var grain = clusterClient.GetGrain<IStatusGrain>(id);
            var res = await grain.GetAsync();
            return res;
        }
    }
}
