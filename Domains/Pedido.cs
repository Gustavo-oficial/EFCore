using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORM.EFCore.Domains
{
    public class Pedido
    {
        [Key]
        public Guid Id { get; set; }

        public string Status { get; set; }

        public DateTime OrderDate { get; set; }

        public Pedido()
        {
            Id = Guid.NewGuid();
        }


    }
}
