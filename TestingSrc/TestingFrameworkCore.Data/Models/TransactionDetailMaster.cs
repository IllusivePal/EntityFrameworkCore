using System;
using System.Collections.Generic;

namespace TestingFrameworkCore.Data.Models
{
    public partial class TransactionDetailMaster
    {
        public string TdmtTransactionDetailCode { get; set; }
        public string TdmtTransactionCode { get; set; }
        public string TdmtProductCode { get; set; }
        public decimal? TdmtQuantity { get; set; }
        public decimal? TdmtPrice { get; set; }
        public decimal? TdmtTotalPayment { get; set; }
        public string TdmtStatus { get; set; }
        public DateTime? TdmtDate { get; set; }

        public virtual ProductMaster TdmtProductCodeNavigation { get; set; }
    }
}
