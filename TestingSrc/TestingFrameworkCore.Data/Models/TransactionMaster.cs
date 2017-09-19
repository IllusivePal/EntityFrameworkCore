using System;
using System.Collections.Generic;

namespace TestingFrameworkCore.Data.Models
{
    public partial class TransactionMaster
    {
        public string Tmt_TransactionCode { get; set; }
        public string Tmt_UserCode { get; set; }
        public DateTime? Tmt_TransactionDate { get; set; }
        public string Tmt_TransactionStatus { get; set; }

        public UserMaster UserMaster { get; set; }
    }
}
