using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaoCao.Common.Req
{
    public class AssigneeTasksReq
    {
        public int AssigneeTaskId { get; set; }
        public int AssigneeId { get; set; }
        public int TaskId { get; set; }
        public int StateId { get; set; }
        public DateTime Schedule { get; set; }
    }
}
