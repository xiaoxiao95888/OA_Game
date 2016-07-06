using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA_Game.Library.Model;
using OA_Game.Library.Services;

namespace OA_Game.Service.Services
{
    public class PvService : BaseService, IPvService
    {
        public PvService(OaGameDataContext dbContext)
            : base(dbContext)
        {
        }

        public Pv GetPv(Guid id)
        {
            return DbContext.Pvs.FirstOrDefault(n => n.Id == id);
        }

        public IQueryable<Pv> GetPvs()
        {
            return DbContext.Pvs;
        }

        public void Update()
        {
            DbContext.SaveChanges();
        }
    
}
}
