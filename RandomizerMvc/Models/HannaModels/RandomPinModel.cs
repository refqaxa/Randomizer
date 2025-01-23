using System.ComponentModel.DataAnnotations;

namespace RandomizerMvc.Models.HannaModels
{
    public class RandomPinModel
    {
        [Display(Name = "Length")]
        [Required(ErrorMessage = "Please enter a value.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Please enter a valid positive integer.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a valid positive integer.")]

        public int UserChoice { get; set; }
    }
}
