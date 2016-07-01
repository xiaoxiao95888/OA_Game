using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA_Game.Library.Model;
using OA_Game.Library.Services;

namespace OA_Game.Service.Services
{
    public class ArticleCategoryService : BaseService, IArticleCategoryService
    {
        public ArticleCategoryService(OaGameDataContext dbContext)
            : base(dbContext)
        {
        }

        public IQueryable<ArticleCategory> GetArticleCategories()
        {
            return DbContext.ArticleCategories.Where(n => !n.IsDeleted);
        }

        public ArticleCategory GetArticleCategory(Guid id)
        {
            return DbContext.ArticleCategories.FirstOrDefault(n => n.Id == id);
        }

        public void Insert(ArticleCategory articleCategory)
        {
            DbContext.ArticleCategories.Add(articleCategory);
            Update();
        }

        public void Update()
        {
            DbContext.SaveChanges();
        }
    }
}
