using System;
using System.Collections.Generic;

namespace BaoCao.DAL.Models
{
    public partial class Assignees
    {
        public Assignees()
        {
            AssigneeDepartments = new HashSet<AssigneeDepartments>();
            AssigneeTasks = new HashSet<AssigneeTasks>();
        }

        public int AssigneeId { get; set; }
        public string AssigneeName { get; set; }

        public virtual ICollection<AssigneeDepartments> AssigneeDepartments { get; set; }
        public virtual ICollection<AssigneeTasks> AssigneeTasks { get; set; }
    }
}
