using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWard_Manjot.Models
{
    public class Nurse
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string NurseName { get; set; }
        [Required]
        public string Specialty { get; set; }
        public List<Ward> Wards { get; set; }
    }
}
