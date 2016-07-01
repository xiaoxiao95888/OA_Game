using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Game.Service
{
    public class BaseService
    {
        public readonly OaGameDataContext DbContext;

        public BaseService(OaGameDataContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
