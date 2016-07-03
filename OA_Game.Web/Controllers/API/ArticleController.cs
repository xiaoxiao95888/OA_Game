using OA_Game.Library.Model;
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
    public class ArticleController : BaseApiController
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }
        public object Get()
        {
            return _articleService.GetArticles().Select(n => new ArticleModel
            {
                Id = n.Id,
                Title = n.Title,
                Description = n.Description,
                Content = n.Content,
                ThumbnailUrl = n.ThumbnailUrl,
                UpdateTime = n.UpdateTime,
                ArticleCategoryId = n.ArticleCategoryId,  
                ArticleCategoryName=n.ArticleCategory.Name        
            });
        }
        [Authorize]
        public object Post(ArticleModel model)
        {
            var data = new Article
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                Description = model.Description,
                Content = model.Content,
                ArticleCategoryId = model.ArticleCategoryId,
                ThumbnailUrl = model.ThumbnailUrl
            };
            try
            {
                _articleService.Insert(data);

            }
            catch (Exception ex)
            {
                return Failed(ex.Message);
            }
            return Success();
        }
        [Authorize]
        public object Put(ArticleModel model)
        {
            var data = _articleService.GetArticle(model.Id);
            data.IsDeleted = model.IsDeleted;
            data.Title = model.Title;
            data.ThumbnailUrl = model.ThumbnailUrl;
            data.Content = model.Content;
            data.Description = model.Description;
            data.ArticleCategoryId = model.ArticleCategoryId;
            try
            {
                _articleService.Update();
            }
            catch(Exception ex)
            {
                return Failed();
            }
            return Success();
        }
        [Authorize]
        public object Delete(Guid id)
        {
            var data = _articleService.GetArticle(id);
            data.IsDeleted = true;
            try
            {
                _articleService.Update();
            }
            catch (Exception ex)
            {
                return Failed();
            }
            return Success();
        }
    }
}
