using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary1
{
  public  class SellStatistic
    {
        [Key, Column(Order = 0)]
        public int VmId { get; set; }
        [Key, Column(Order = 1)]
        [MaxLength(4)]
        public string ProductId { get; set; }
        public DateTime datetime { get; set; }
        public int amountofproductsold { get; set; }
    }
}
