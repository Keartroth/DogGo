using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DogGo.Models
{
    public class Dog
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your dog's Name.")]
        [MaxLength(35)]
        public string Name { get; set; }

        [Required]
        [DisplayName("Owner")]
        public int OwnerId { get; set; }

        [Required(ErrorMessage = "Please enter your dog's Breed.")]
        [MaxLength(35)]
        public string Breed { get; set; }

        public string Notes { get; set; }

        [DisplayName("Photo")]
        public string ImageUrl { get; set; }
        public Owner Owner { get; set; }
    }
}