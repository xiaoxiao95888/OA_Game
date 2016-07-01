using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA_Game.Library.Model;

namespace OA_Game.Library.Services
{
    public interface IRequiredService : IDisposable
    {
        void Insert(Required required);
        void Update();
        Required GetRequired(Guid id);
        IQueryable<Required> GetRequireds();
    }
}
