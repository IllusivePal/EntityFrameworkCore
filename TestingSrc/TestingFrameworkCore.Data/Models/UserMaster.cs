using System;
using System.Collections.Generic;

namespace TestingFrameworkCore.Data.Models
{
    public partial class UserMaster
    {

        public string UmtUserCode { get; set; }
        public string UmtFirstName { get; set; }
        public string UmtMiddleName { get; set; }
        public string Umt_UserLastName { get; set; }
        public string UmtEmail { get; set; }
        public string UmtPassword { get; set; }
        public string UmtStatus { get; set; }
        public string Umt_Gender { get; set; }

        public List<HistoryTableMaster> HistoryTables { get; set; }
        public AuthIdentityMaster AuthIdentityMaster { get; set; }
        public List<TransactionMaster> TTransactionMaster { get; set; }
    }
}
