using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangement.DAL.Models
{
    public class Category : ModelBase
    {
        public string Name { get; set; } = null!;

        public ICollection<Session> Sessions{ get; set; } = new HashSet<Session>();
    }
}
