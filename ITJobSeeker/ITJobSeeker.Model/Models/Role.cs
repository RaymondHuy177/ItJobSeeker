﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITJobSeeker.Model.Models
{
    public class Role : IEntity
    {
        public Role()
        {
            ID = Guid.NewGuid();
            Users = new List<User>();
        }

        [Key]
        public Guid ID { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
        
    }
}
