using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA_Game.Library.Model;

namespace OA_Game.Library.Services
{
    public interface IDataContext : IObjectContextAdapter, IDisposable
    {
        IDbSet<Pv> Pvs { get; set; }
        IDbSet<AdminUser> AdminUsers { get; set; }
        IDbSet<Required> Requireds { get; set; }
        IDbSet<ArticleCategory> ArticleCategories { get; set; }
        IDbSet<Article> Articles { get; set; }
        int SaveChanges();
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
