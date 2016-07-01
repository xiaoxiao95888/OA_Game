using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA_Game.Library.Model;
using OA_Game.Library.Services;

namespace OA_Game.Service.Services
{
    public class RequiredService : BaseService, IRequiredService
    {
        public RequiredService(OaGameDataContext dbContext)
            : base(dbContext)
        {
        }
        public Required GetRequired(Guid id)
        {
            return DbContext.Requireds.FirstOrDefault(n => n.Id == id);
        }

        public IQueryable<Required> GetRequireds()
        {
            return DbContext.Requireds.Where(n => !n.IsDeleted);
        }

        public void Insert(Required required)
        {
            DbContext.Requireds.Add(required);
            Update();
        }

        public void Update()
        {
            DbContext.SaveChanges();
        }
    }
}
