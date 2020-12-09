using System;
using System.Collections.Generic;

namespace BaoCao.DAL.Models
{
    public partial class AssigneeDepartments
    {
        public int AssigneeDepartmentId { get; set; }
        public int? AssigneeId { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Assignees Assignee { get; set; }
        public virtual Departments Department { get; set; }
    }
}
