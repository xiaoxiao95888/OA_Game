using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA_Game.Library.Model;
using OA_Game.Library.Services;

namespace OA_Game.Service.Services
{
    public class ArticleService : BaseService, IArticleService
    {
        public ArticleService(OaGameDataContext dbContext)
            : base(dbContext)
        {
        }

        public Article GetArticle(Guid id)
        {
            return DbContext.Articles.FirstOrDefault(n => n.Id == id);
        }

        public IQueryable<Article> GetArticles()
        {
            return DbContext.Articles.Where(n => !n.IsDeleted);
        }

        public void Insert(Article article)
        {
            DbContext.Articles.Add(article);
            Update();
        }

        public void Update()
        {
            DbContext.SaveChanges();
        }
    }
}
