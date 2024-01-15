using Abstraction.Interface;
using Abstraction.Models;
using Database;
using Microsoft.EntityFrameworkCore;

namespace Grains
{
    public class ChargePointGrain : Grain, IChargePointGrain
    {
        private readonly MyDbContext db;
        private ChargePoint chargePoint;

        public ChargePointGrain(MyDbContext db)
        {
            this.db = db;
        }

        public override async Task OnActivateAsync(CancellationToken cancellationToken)
        {
            var id = this.GetGrainId().Key.ToString();
            var cc = await db.tbChargePoints.FirstOrDefaultAsync(x => x.ChargePointId == id);

            if (cc == null)
            {
                chargePoint = new ChargePoint();
            }
            else
            {
                chargePoint = new ChargePoint
                {
                    Id = cc.Id,
                    ChargePointId = cc.ChargePointId,
                    ClientCertThumb = cc.ClientCertThumb,
                    Landmark = cc.Landmark,
                    Latitude = cc.Latitude,
                    Longitude = cc.Longitude,
                    Name = cc.Name,
                    Password = cc.Password,
                    Status = cc.Status,
                    Street = cc.Street,
                    Username = cc.Username,
                    Connectors = new List<Connector>()
                };
            }
        }

        public Task<ChargePoint> GetAsync()
        {
            return Task.FromResult(chargePoint);
        }
    }
}
