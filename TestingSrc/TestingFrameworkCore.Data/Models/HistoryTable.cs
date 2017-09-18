using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingFrameworkCore.Data.Models
{
    public class HistoryTable
    {
        public string UmtUserCode { get; set; }
        public UserMaster UserMaster { get; set; }
        public string PmtProductCode { get; set; }
        public ProductMaster ProductMaster { get; set; }
        public string Description { get; set; }
    }
}
