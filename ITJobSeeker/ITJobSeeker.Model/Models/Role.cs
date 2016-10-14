using System;
using System.ComponentModel.DataAnnotations;

namespace ITJobSeeker.Model.Models
{
    public class Role : IEntity
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public string Name { get; set; }
        
    }
}
