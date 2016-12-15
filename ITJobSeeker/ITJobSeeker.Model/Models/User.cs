using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITJobSeeker.Model.Models
{
    public class User : IEntity
    {
        public User()
        {
            ID = Guid.NewGuid();
        }

        [Key]
        public Guid ID { get; set; }

        [Required, MaxLength(15)]
        public string UserName { get; set; }

        [Required, MaxLength(15)]
        public string FirstName { get; set; }

        [Required, MaxLength(15)]
        public string LastName { get; set; }

        [Required, RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage ="Wrong format Email")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Telephone { get; set; }

        public bool IsMale { get; set; }

        [Required]
        public Guid RoleID { get; set; }

        [ForeignKey("RoleID")]
        public virtual Role Role { get; set; }

        public virtual Company Company { get; set; }
    }
}
