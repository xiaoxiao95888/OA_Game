using OA_Game.Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA_Game.Library.Model;

namespace OA_Game.Service.Services
{
    public class AdminUserService : BaseService, IAdminUserService
    {
        public AdminUserService(OaGameDataContext dbContext)
            : base(dbContext)
        {
        }

        public AdminUser GetAdminUser(string userName, string password)
        {
            return DbContext.AdminUsers.FirstOrDefault(n => n.UserName == userName && n.Password == password);
        }

        public void Update()
        {
            DbContext.SaveChanges();
        }
    }
}
