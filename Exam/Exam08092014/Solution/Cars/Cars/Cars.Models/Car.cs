namespace Cars.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Car
    {
        [Required]
        public int CarId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Model { get; set; }

        [Required]
        public TransmissionType TransmisionType { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public double Price { get; set; }

        public int DealerId { get; set; }

        public virtual Dealer Dealer { get; set; }

        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }        
    }
}