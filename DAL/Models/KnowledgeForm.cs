using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class KnowledgeForm
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KnowledgeFormId { get; set; }
        public string ProfPerformance { get; set; }
        public int WebGrade { get; set; }
        public int MobDevGrade { get; set; }
        public int DataScienceGrade { get; set; }
        public string WebDesc { get; set; }
        public string MobDevDesc { get; set; }
        public int DataScienceDesc { get; set; }

    }
}
