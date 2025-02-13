using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAD302Week3Lab12025CL.S00233992
{
    namespace DataModel
    {
        public class Customer
        {
            [Key]
            [Display(Name = "Customer Number")]
            public int ID { get; set; }

            [Display(Name = "Name")]
            public string Name { get; set; }

            [Display(Name = "Address")]
            public string Address { get; set; }

            [Display(Name = "Credit Rating")]
            public float CreditRating { get; set; }
        }
    }
}