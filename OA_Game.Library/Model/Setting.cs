using OA_Game.Library.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Game.Library.Model
{
    public class Setting : IDtStamped
    {
        public Guid Id { get; set; }
        public string VideoUrl { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
