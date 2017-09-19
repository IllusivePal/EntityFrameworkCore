using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingFrameworkCore.Data.Models
{
    public partial class ProductAccountCodeIdentityMaster
    {
       public string Pacmt_ProductCode { get; set; }
       public ProductMaster ProductMaster { get; set; }
       public int Pacmt_Account { get; set; }
       public string Pacmt_Description { get; set; }
    }
}
