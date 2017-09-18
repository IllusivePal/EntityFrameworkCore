using System;
using System.Collections.Generic;

namespace TestingFrameworkCore.Data.Models
{
    public partial class UserMaster
    {
        public UserMaster()
        {
            TTransactionMaster = new HashSet<TransactionMaster>();
        }

        public string UmtUserCode { get; set; }
        public string UmtFirstName { get; set; }
        public string UmtMiddleName { get; set; }
        public string UmtLastName { get; set; }
        public string UmtEmail { get; set; }
        public string UmtPassword { get; set; }
        public string UmtStatus { get; set; }

        public List<HistoryTable> HistoryTables { get; set; }
        public AuthIdentity AuthIdentity { get; set; }
        public virtual ICollection<TransactionMaster> TTransactionMaster { get; set; }
    }
}
