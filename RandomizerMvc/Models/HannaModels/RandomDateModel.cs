using System;
using System.ComponentModel.DataAnnotations;

namespace RandomizerMvc.Models.HannaModels
{
    public class RandomDateModel
    {
        public class OneParameter
        {
            [Display(Name = "UserDateChoice")]
            [Required(ErrorMessage = "Please enter a date.")]
            [DataType(DataType.Date, ErrorMessage = "Please enter a valid date.")]

            public DateTime UserDateChoice { get; set; }
        }

        public class TwoParameter
        {
            [Display(Name = "First User Date Choice")]
            [Required(ErrorMessage = "Please enter a date.")]
            [DataType(DataType.Date, ErrorMessage = "Please enter a valid date.")]

            public DateTime FirstUserDateChoice { get; set; }
            
            [Display(Name = "Second User Date Choice")]
            [Required(ErrorMessage = "Please enter a date.")]
            [DataType(DataType.Date, ErrorMessage = "Please enter a valid date.")]

            public DateTime SecondUserDateChoice { get; set; }
        }
    }
}
