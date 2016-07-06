using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OA_Game.Library.Services;

namespace OA_Game.Web.Controllers.API
{
    public class PvController : BaseApiController
    {
        private readonly IPvService _pvService;

        public PvController(IPvService pvService)
        {
            _pvService = pvService;
        }

        public object Get()
        {
            return _pvService.GetPvs().Select(n => n.Count).FirstOrDefault();
        }

        public object Put()
        {
            var model = _pvService.GetPvs().FirstOrDefault();
            if (model != null)
            {
                model.Count = model.Count + 1;
                _pvService.Update();
            }
            return Success();
        }
    }
}
