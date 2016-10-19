using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITJobSeeker.Model.Models
{
    public class TechnologyKeyword : IEntity
    {
        [Key]
        public Guid ID { get; set; }

        public string Name { get; set; }
    }
}
