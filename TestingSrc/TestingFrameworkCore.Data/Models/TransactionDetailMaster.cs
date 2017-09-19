using System;
using System.Collections.Generic;

namespace TestingFrameworkCore.Data.Models
{
    public partial class TransactionDetailMaster
    {
        public string Tdmt_TransactionDetailCode { get; set; }
        public string Tdmt_TransactionCode { get; set; }
        public string Tdmt_ProductCode { get; set; }
        public decimal? Tdmt_Quantity { get; set; }
        public decimal? Tdmt_Price { get; set; }
        public decimal? Tdmt_TotalPayment { get; set; }
        public string Tdmt_Status { get; set; }
        public DateTime? Tdmt_Date { get; set; }

        public  ProductMaster ProductMaster { get; set; }
    }
}
