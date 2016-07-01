using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using OA_Game.Library.Model;
using OA_Game.Library.Services;
using OA_Game.Web.Models;

namespace OA_Game.Web.Controllers.API
{
    public class RequiredController : BaseApiController
    {
        private readonly IRequiredService _requiredService;

        public RequiredController(IRequiredService requiredService)
        {
            _requiredService = requiredService;
        }

        public object Post(RequiredModel model)
        {
            if (string.IsNullOrEmpty(model.PersonName) || string.IsNullOrEmpty(model.Email))
            {
                return Failed("请填写完整");
            }
            if (!Regex.IsMatch(model.Email,
                    @"^([/w-/.]+)@((/[[0-9]{1,3}/.[0-9]{1,3}/.[0-9]{1,3}/.)|(([/w-]+/.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(/]?)$"))
            {
                return Failed("邮箱格式错误");
            }
            if (_requiredService.GetRequireds().Any(n => n.Email == model.Email))
            {
                return Failed("禁止重复提交");
            }
            var required = new Required { Id = Guid.NewGuid(), Email = model.Email, PersonName = model.PersonName };
            _requiredService.Insert(required);
            return Success();
        }

        public object Get()
        {
            var pageIndexstr = HttpContext.Current.Request["pageIndex"] ?? string.Empty;
            var pageSize = Convert.ToInt32(ConfigurationManager.AppSettings["PageSize"]);
            var pageIndex = string.IsNullOrEmpty(pageIndexstr) ? 1 : Convert.ToInt32(pageIndexstr);
            var data = _requiredService.GetRequireds();
            var totalcount = data.Count();
            var model = new PageRequiredModel
            {
                RequiredModels =
                    data.Select(
                        n =>
                            new RequiredModel
                            {
                                Id = n.Id,
                                CreatedTime = n.CreatedTime,
                                Email = n.Email,
                                PersonName = n.PersonName
                            }).ToArray(),
                TotalCount = totalcount,
                AllPage = (totalcount/pageSize) + (totalcount%pageSize == 0 ? 0 : 1),
                CurrentPageIndex = pageIndex
            };
            return model;
        }
    }
}
