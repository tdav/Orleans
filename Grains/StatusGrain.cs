using Abstraction.Models;
using Database;
using Microsoft.EntityFrameworkCore;

namespace Grains
{
    public class StatusGrain : Grain, IStatusGrain
    {
        private readonly MyDbContext db;
        private ChargePointStatus chargePointStatus;

        public StatusGrain(MyDbContext db)
        {
            this.db = db;
        }

        public override async Task OnActivateAsync(CancellationToken cancellationToken)
        {
            var key = this.GetGrainId().Key.ToString();
            var cc = await db.tbChargePoints
                             .Include(i => i.Connectors)
                             .AsNoTracking()
                             .FirstOrDefaultAsync(x => x.ChargePointId == key);

            chargePointStatus = new ChargePointStatus()
            {
                KeyId = 1,
                Id = key,
                Name = key,
                HeartBeatDateTime = DateTime.Now,
                OnlineConnectors = new Dictionary<int, OnlineConnectorStatus>(),
                Protocol = "ocpp1.6"
            };

            foreach (var it in cc.Connectors)
            {
                var ss = new OnlineConnectorStatus()
                {
                    Throughput = it.Throughput,
                    ConnectorTypeId = it.ConnectorTypeId,
                    CurUserId = null,
                    Soc = 0,
                    MeterKWH = 0,
                    ChargeRateKW = 0,
                    Status = ConnectorStatusEnum.Undefined,
                };

                chargePointStatus.OnlineConnectors.Add(it.ConnectorId, ss);
            }
        }

        public override Task OnDeactivateAsync(DeactivationReason reason, CancellationToken cancellationToken)
        {
            return base.OnDeactivateAsync(reason, cancellationToken);
        }

        public Task<ChargePointStatus> GetAsync()
        {
            return Task.FromResult(chargePointStatus);
        }
    }
}
