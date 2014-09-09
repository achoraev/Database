namespace Cars.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Dealer
    {
        private ICollection<Car> cars;

        public int DealerId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string CityId { get; set; }

        [Required]
        public virtual City Cities { get; set; }

        public virtual ICollection<Car> Cars
        {
            get
            {
                return this.cars;
            }
            set
            {
                this.cars = value;
            }
        }
    }
}