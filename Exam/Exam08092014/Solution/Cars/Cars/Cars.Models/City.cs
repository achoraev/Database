namespace Cars.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class City
    {
        [Key, ForeignKey("Dealer")]
        public int DealerId { get; set; }

        public int CityId { get; set; }

        [Required]
        [MaxLength(10)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual Dealer Dealer { get; set; }
    }
}