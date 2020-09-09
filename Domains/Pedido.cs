using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORM.EFCore.Domains
{
    public class Pedido : BaseDomains
    {
       
        public string Status { get; set; }

        public DateTime OrderDate { get; set; }

    }
}
