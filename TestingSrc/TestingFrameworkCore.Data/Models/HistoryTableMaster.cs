using System;
using System.Collections.Generic;

namespace TestingFrameworkCore.Data.Models
{
    public partial class HistoryTableMaster
    {
        public string Hmt_UmtUserCode { get; set; }
        public string Hmt_PmtProductCode { get; set; }
        public string Hmt_Description { get; set; }
        public UserMaster UserMaster { get; set; }
        public ProductMaster ProductMaster { get; set; }
        
    }
}
