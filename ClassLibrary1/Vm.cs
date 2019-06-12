using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary1
{
   public class Vm
    {
        [Key]
        public int Id { get; set; }
        public string Location { get; set; }
        public string Banknotes { get; set; }
        public string Coins { get; set; }
        
    }
}
