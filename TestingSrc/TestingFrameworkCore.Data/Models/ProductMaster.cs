using System;
using System.Collections.Generic;

namespace TestingFrameworkCore.Data.Models
{
    public partial class ProductMaster
    {
      

        public string Pmt_ProductCode { get; set; }
        public string Pmt_ProductName { get; set; }
        public decimal? Pmt_ProductPrice { get; set; }
        public int? Pmt_ProductQuantity { get; set; }
        public string Status { get; set; }
        public DateTime ludatetime { get; set; }

        public List<HistoryTableMaster> HistoryTableMaster { get; set; }
        public ProductAccountCodeIdentityMaster ProductAccountCodeIdentityMaster { get; set; }
        public List<TransactionDetailMaster> TransactionDetailMaster { get; set; }
    }
}
