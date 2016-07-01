using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA_Game.Library.Model;

namespace OA_Game.Library.Services
{
    public interface IArticleCategoryService : IDisposable
    {
        void Insert(ArticleCategory articleCategory);
        void Update();
        ArticleCategory GetArticleCategory(Guid id);
        IQueryable<ArticleCategory> GetArticleCategories();
    }
}
