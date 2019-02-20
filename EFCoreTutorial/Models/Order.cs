using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCoreTutorial.Models {
    public class Order {

        public int Id { get; set; }
        public DateTime Date { get; set; }
        [StringLength(200)]
        [Required]
        public string Description { get; set; }
        public double Total { get; set; } = 0;
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }


        public override string ToString() {
            return $"Descipriton: {Description}, Total: {Total:C}";
        }

        public Order() {

        }
    }
}
