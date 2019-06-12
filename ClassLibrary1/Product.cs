using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary1
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MaxLength(4)]
        public string Id { get; set; }
        public string Name { get; set; }
        public int Sellprice { get; set; }
        public int BuyPrice { get; set; }
      

    }
}
