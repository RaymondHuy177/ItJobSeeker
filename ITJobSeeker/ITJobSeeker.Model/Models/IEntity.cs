using System;
using System.ComponentModel.DataAnnotations;

namespace ITJobSeeker.Model.Models
{
    public interface IEntity
    {
        [Required]
        Guid ID { get; set; }
    }
}
