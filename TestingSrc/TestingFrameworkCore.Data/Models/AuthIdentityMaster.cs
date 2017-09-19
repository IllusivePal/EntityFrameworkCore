using System;
using System.Collections.Generic;

namespace TestingFrameworkCore.Data.Models
{
    public partial class AuthIdentityMaster
    {
        public string Amt_AuthCode { get; set; }
        public string Amt_AuthName { get; set; }
        public string Amt_UmtUserCode { get; set; }
        public UserMaster UserMaster { get; set; }
    }
}
