using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaoCao.Common.Req
{
    public class AssigneeDepartmentsReq
    {
        public int AssigneeDepartmentId { get; set; }
        public int AssigneeId { get; set; }
        public int DepartmentId { get; set; }
    }
}
