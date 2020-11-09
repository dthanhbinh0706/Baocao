using System;
using System.Collections.Generic;

namespace BaoCao.DAL.Models
{
    public partial class Reports
    {
        public int StateId { get; set; }
        public int? Total { get; set; }

        public virtual States State { get; set; }
    }
}
