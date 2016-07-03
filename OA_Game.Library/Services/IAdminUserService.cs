using OA_Game.Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Game.Library.Services
{
    public interface IAdminUserService : IDisposable
    {       
        void Update();
        AdminUser GetAdminUser(string userName,string password);
       
    }
}
