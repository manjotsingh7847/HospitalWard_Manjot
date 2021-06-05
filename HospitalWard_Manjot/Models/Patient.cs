using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWard_Manjot.Models
{
    public class Patient
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public int WardID { get; set; }
        public Ward Ward { get; set; }
    }
}
