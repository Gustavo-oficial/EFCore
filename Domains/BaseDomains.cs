﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ORM.EFCore.Domains
{
    public class BaseDomains
    {
        [Key]
        public Guid Id { get; set; }

        public BaseDomains()
        {
            Id = Guid.NewGuid();
        }
    }
}
