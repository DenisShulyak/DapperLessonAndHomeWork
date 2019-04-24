using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dl.Models
{
   public class Reciever :Entity
    {
        public string FullAName { get; set; }
        public string Address { get; set; }
        
        public ICollection<Mail> Mails { get; set; }
    }
}
