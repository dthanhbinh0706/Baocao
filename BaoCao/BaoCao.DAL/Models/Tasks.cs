using System;
using System.Collections.Generic;

namespace BaoCao.DAL.Models
{
    public partial class Tasks
    {
        public Tasks()
        {
            AssigneeTasks = new HashSet<AssigneeTasks>();
        }

        public int TaskId { get; set; }
        public string TaskName { get; set; }

        public virtual ICollection<AssigneeTasks> AssigneeTasks { get; set; }
    }
}
