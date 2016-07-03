using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OA_Game.Web.Models
{
    public class ArticleModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string ThumbnailUrl { get; set; }
        public Guid ArticleCategoryId { get; set; }
        public string ArticleCategoryName { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}