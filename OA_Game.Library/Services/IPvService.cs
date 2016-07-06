using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA_Game.Library.Model;

namespace OA_Game.Library.Services
{
    public interface IPvService : IDisposable
    {
        void Update();
        Pv GetPv(Guid id);
        IQueryable<Pv> GetPvs();


    }
}
