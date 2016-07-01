using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA_Game.Library.Model;

namespace OA_Game.Library.Services
{
    public interface IArticleService : IDisposable
    {
        void Insert(Article article);
        void Update();
        Article GetArticle(Guid id);
        IQueryable<Article> GetArticles();
    }
}
