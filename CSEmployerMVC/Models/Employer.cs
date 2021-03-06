﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSEmployerMVC.Models
{
    public class Employer
    {
        public int ID { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(10)]
        public string Zip { get; set; }

        
        [StringLength(30)]
        public string City { get; set; }


        [StringLength(2)]
        public string State { get; set; }

        [Required]
        [StringLength(30)]
        public string Country { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(16)]
        public string Phone { get; set; }

        [StringLength(16)]
        public string Fax { get; set; }

        /* Login information */
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string ePassword { get; set; }

        public string Location
        {
            get { return City + ", " + State + ", " + Country; }
        }


        public virtual ICollection<Job> Jobs { get; set; }
    }
}