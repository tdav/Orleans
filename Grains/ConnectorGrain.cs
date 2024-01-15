using Abstraction.Models;
using Database;
using Microsoft.EntityFrameworkCore;

namespace Grains
{
    public class ConnectorGrain : Grain, IConnectorGrain
    {
        private readonly MyDbContext db;
        private Connector connector;

        public ConnectorGrain(MyDbContext db)
        {
            this.db = db;
        }

        public override async Task OnActivateAsync(CancellationToken cancellationToken)
        {
            var key = this.GetGrainId().Key.ToString();
            var id = Convert.ToInt32(key);
            var cc = await db.tbConnectors.FirstOrDefaultAsync(x => x.Id == id);

            if (cc == null)
            {
                connector = new Connector();
            }
            else
            {
                connector = new Connector()
                {
                    Id = cc.Id,
                    ChargePointId = cc.ChargePointId,
                    ConnectorId = cc.ConnectorId,
                    ConnectorTypeId = cc.ConnectorTypeId,
                    Status = cc.Status,
                    Throughput = cc.Throughput,
                };
            }
        }

        public override Task OnDeactivateAsync(DeactivationReason reason, CancellationToken cancellationToken)
        {
            return base.OnDeactivateAsync(reason, cancellationToken);
        }

        public Task<Connector> GetAsync()
        {
            return Task.FromResult(connector);
        }
    }
}
