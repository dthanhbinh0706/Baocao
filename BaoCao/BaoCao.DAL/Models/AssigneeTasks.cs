using System;
using System.Collections.Generic;

namespace BaoCao.DAL.Models
{
    public partial class AssigneeTasks
    {
        public int AssigneeTaskId { get; set; }
        public int AssigneeId { get; set; }
        public int TaskId { get; set; }
        public int StateId { get; set; }
        public DateTime? Schedule { get; set; }

        public virtual Assignees Assignee { get; set; }
        public virtual States State { get; set; }
        public virtual Tasks Task { get; set; }
    }
}
