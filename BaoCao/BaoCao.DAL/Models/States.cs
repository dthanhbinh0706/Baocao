using System;
using System.Collections.Generic;

namespace BaoCao.DAL.Models
{
    public partial class States
    {
        public States()
        {
            AssigneeTasks = new HashSet<AssigneeTasks>();
        }

        public int StateId { get; set; }
        public string StateName { get; set; }

        public virtual Reports Reports { get; set; }
        public virtual ICollection<AssigneeTasks> AssigneeTasks { get; set; }
    }
}
