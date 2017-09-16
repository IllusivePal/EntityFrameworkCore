using System;
using System.Collections.Generic;

namespace TestingFrameworkCore.Data.Models
{
    public partial class TransactionMaster
    {
        public string TmtTransactionCode { get; set; }
        public string TmtUserCode { get; set; }
        public DateTime? TmtTransactionDate { get; set; }
        public string TmtTransactionStatus { get; set; }

        public virtual UserMaster TmtUserCodeNavigation { get; set; }
    }
}
