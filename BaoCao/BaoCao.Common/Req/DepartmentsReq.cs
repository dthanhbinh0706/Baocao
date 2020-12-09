using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaoCao.Common.Req
{
    public class DepartmentsReq
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
