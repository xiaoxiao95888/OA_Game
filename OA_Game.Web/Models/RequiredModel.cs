using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OA_Game.Web.Models
{
    public class RequiredModel
    {
        public Guid Id { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime CreatedTime { get; set; }
    }

    public class PageRequiredModel
    {
        public RequiredModel[] RequiredModels { get; set; }
        public int CurrentPageIndex { get; set; }
        public int AllPage { get; set; }
        public int TotalCount { get; set; }
    }

          
    
}