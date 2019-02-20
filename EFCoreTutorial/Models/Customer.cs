using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCoreTutorial.Models {
    public class Customer {

        public int Id { get; set; }
        [StringLength(50)]
        [Required]       
        public string Name { get; set; }
        public bool Active { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdateed { get; set; }


        public Customer() {

        }
    }
}