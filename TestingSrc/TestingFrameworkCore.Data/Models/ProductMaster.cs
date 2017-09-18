using System;
using System.Collections.Generic;

namespace TestingFrameworkCore.Data.Models
{
    public partial class ProductMaster
    {
        public ProductMaster()
        {
            TTransactionDetailMaster = new HashSet<TransactionDetailMaster>();
        }

        public string PmtProductCode { get; set; }
        public string PmtProductName { get; set; }
        public decimal? PmtProductPrice { get; set; }
        public int? PmtProductQuantity { get; set; }
        public string Status { get; set; }
        public DateTime ludatetime { get; set; }

        public List<HistoryTable> HistoryTables { get; set; }
        public virtual ICollection<TransactionDetailMaster> TTransactionDetailMaster { get; set; }
    }
}
