using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITJobSeeker.Model.Models
{
    public class Picture : IEntity
    {
        public Picture()
        {
            Users = new List<User>();
        }

        [Key]
        public Guid ID { get; set; }

        public byte[] Data { get; set; }

        public virtual ICollection<User> Users { get; set; }

    }
}
