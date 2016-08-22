using OA_Game.Library.Services;
using OA_Game.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA_Game.Library.Model;

namespace OA_Game.Service.Services
{
    public class SettingService : BaseService, ISettingService
    {
        public SettingService(OaGameDataContext dbContext)
            : base(dbContext)
        {
        }

        public Setting GetSetting(Guid id)
        {
            return DbContext.Settings.FirstOrDefault(n => n.Id == id);
        }

        public IQueryable<Setting> GetSettings()
        {
            return DbContext.Settings.Where(n => !n.IsDeleted);
        }

        public void Insert(Setting setting)
        {
            DbContext.Settings.Add(setting);
            Update();
        }

        public void Update()
        {
            DbContext.SaveChanges();
        }

    }
}
