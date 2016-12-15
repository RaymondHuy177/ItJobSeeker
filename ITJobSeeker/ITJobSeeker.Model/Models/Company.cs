using System;
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
        public Company() 
        {
            Jobs = new List<Job>();
        }

        [Key, ForeignKey("User")]
        public Guid ID { get; set; }

        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Location { get; set; }

        public string Type { get; set; }

        public string Size { get; set; }

        public virtual User User { get; set; }

        public Guid? FirstPictureID { get; set; }

        public Guid? SecondPictureID { get; set; }

        public Guid? ThirdPictureID { get; set; }

        public Guid? AvatarID { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
        
    }
}
