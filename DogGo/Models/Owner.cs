using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DogGo.Models
{
    public class Owner
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your Name.")]
        [MaxLength(35)]
        public string Name { get; set; }

        [Required]
        [DisplayName("Neighborhood")]
        public int NeighborhoodId { get; set; }

        [Phone]
        [DisplayName("Phone Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage ="Please enter a valid Email.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(55, MinimumLength = 5)]
        public string Address { get; set; }

        public Neighborhood Neighborhood { get; set; }
    }
}