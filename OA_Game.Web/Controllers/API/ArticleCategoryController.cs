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
    public class ArticleCategoryController : BaseApiController
    {
        private readonly IArticleCategoryService _articleCategoryService;

        public ArticleCategoryController(IArticleCategoryService articleCategoryService)
        {
            _articleCategoryService = articleCategoryService;
        }
        public object Get()
        {
            return _articleCategoryService.GetArticleCategories().Select(n => new ArticleCategoryModel
            {
                Id = n.Id,
                Name=n.Name
            });
        }
    }
}
