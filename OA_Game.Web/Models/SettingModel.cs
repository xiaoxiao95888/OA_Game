using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OA_Game.Web.Models
{
    public class SettingModel
    {
        public Guid Id { get; set; }
        public string VideoUrl { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}