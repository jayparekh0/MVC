using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace WebApp.Models
{
    public class ContractModel
    {
        [Required]
        public int ContractID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [StringLength(15)]
        [Phone]
        [Display(Name = "Phone No")]
        public string Phone { get; set; }

        [Required]
        public int StatusID { get; set; }

        [Display(Name = "Status")]
        public string StatusDesc { get; set; }
    }
}
