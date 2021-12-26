using DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class User
    {
        [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Surname { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Login { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Pass { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? KnowledgeFormId { get; set; }
        public virtual KnowledgeForm KnowledgeForm { get; set; }
        public Role Role { get; set; }
        public int? ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
