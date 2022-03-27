using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDWithEF
{
    public class Employee
    {
        [Key]
        public int EmpID { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)] 
        public string Email { get; set; }
        [StringLength(255)] 
        public string Dob { get; set; }
        [StringLength(255)] 
        public string Address { get; set; }
        [StringLength(255)] 
        public string ImageUrl { get; set; }
    }
}
