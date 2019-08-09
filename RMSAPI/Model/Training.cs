using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RMSAPI.Model
{
    [Table("Training")]
    public class Training
    {
        [Key]
        public int Training_Id { get; set; }
        public string Training_Name { get; set; }
        public DateTime? Training_Startdate { get; set; }
        public DateTime? Training_Endate { get; set; }
    }
}
