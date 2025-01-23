using System.ComponentModel.DataAnnotations;

namespace RandomizerMvc.Models.HannaModels
{
    public class RandomIntModel
    {
        [Display(Name = "Allow Negative")]
        [Required(ErrorMessage = "Please enter a value")]

        public bool UserChoice { get; set; }
    }
}
