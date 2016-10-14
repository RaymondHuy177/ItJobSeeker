﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITJobSeeker.Model.Models
{
    public class Company : IEntity
    {
        [Key, ForeignKey("User")]
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public virtual User User { get; set; }
    }
}
