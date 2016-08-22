using OA_Game.Library.Services;
using OA_Game.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OA_Game.Web.Controllers.API
{
    public class SettingController : BaseApiController
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }
        public object Get()
        {
            var model = _settingService.GetSettings().FirstOrDefault();
            if (model != null)
            {
                return new SettingModel
                {
                    Id = model.Id,
                    VideoUrl = model.VideoUrl,
                    CreatedTime = model.CreatedTime,
                    UpdateTime = model.UpdateTime
                };
            }
            return null;
        }
        [Authorize]
        public object Put(SettingModel model)
        {
            var item = _settingService.GetSetting(model.Id);
            if (item != null)
            {
                item.VideoUrl = model.VideoUrl;
                _settingService.Update();
            }
            return Success();
        }
    }
}
