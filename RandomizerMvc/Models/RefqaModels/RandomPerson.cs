using System;
using System.ComponentModel.DataAnnotations;

namespace RandomizerMvc.Models.RefqaModels
{
    public class RandomPerson
    {
        [Display(Name = "Person Type")]
        [Required(ErrorMessage = "Select a valid person type")]
        public string PersonType { get; set; }

        public List<string> PersonTypeOptions = new List<string> { "student", "teacher", "person" };
    }
}

