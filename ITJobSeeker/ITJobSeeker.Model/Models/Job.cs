using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITJobSeeker.Model.Models
{
    public class Job : IEntity
    {
        public Job()
        {
            ID = Guid.NewGuid();
            IsActive = false;
            PostedDate = DateTime.Now;
        }

        [Key]
        public Guid ID { get; set; }

        public DateTime PostedDate { get; set; }

        public DateTime ExpiredDate { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Requirement { get; set; }

        [Required]
        public string Salary { get; set; }

        [Required]
        public string Benefits { get; set; }

        [Required, MaxLength(25), MinLength(2)]
        public string FirstTechStack { get; set; }

        [Required, MaxLength(25), MinLength(2)]
        public string SecondTechStack { get; set; }

        [Required, MaxLength(25), MinLength(2)]
        public string ThirdTechStack { get; set; }

        public bool IsActive { get; set; }

        public Guid CompanyID { get; set; }

        [ForeignKey("CompanyID")]
        public virtual Company Comapny { get; set; }
    }
}
