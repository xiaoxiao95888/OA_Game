using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA_Game.Library.Model.Interfaces;

namespace OA_Game.Library.Model
{
    public class Required : IDtStamped
    {
        public Guid Id { get; set; }
        public string PersonName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
