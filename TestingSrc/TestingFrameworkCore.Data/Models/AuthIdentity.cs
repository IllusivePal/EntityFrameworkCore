using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingFrameworkCore.Data.Models
{
    public class AuthIdentity
    {
        public string AuthCode { get; set; }
        public string AuthName { get; set; }
        public string UmtUserCode { get; set; }
        public UserMaster UserMaster { get; set; }
    }
}
