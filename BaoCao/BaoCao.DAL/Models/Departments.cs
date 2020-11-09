using System;
using System.Collections.Generic;

namespace BaoCao.DAL.Models
{
    public partial class Departments
    {
        public Departments()
        {
            AssigneeDepartments = new HashSet<AssigneeDepartments>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<AssigneeDepartments> AssigneeDepartments { get; set; }
    }
}
