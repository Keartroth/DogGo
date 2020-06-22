using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DogGo.Models
{
    public class Walker
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your Name.")]
        [MaxLength(35)]
        public string Name { get; set; }

        [Required]
        [DisplayName("Neighborhood")]
        public int NeighborhoodId { get; set; }

        [Required(ErrorMessage = "Please enter a Photo Url.")]
        [DisplayName("Photo")]
        public string ImageUrl { get; set; }
        public Neighborhood Neighborhood { get; set; }
    }
}