using System;
using System.ComponentModel.DataAnnotations;

namespace RandomizerMvc.Models.JosModels
{
    public class RandomPasswordModel
    {
        public class OneParameter
        {
            [Display(Name = "User Password Length")]
            [Required(ErrorMessage = "Please enter a number.")]
            [Range(1, 100, ErrorMessage = "Please enter a number between 1 and 100.")]
            public int UserPasswordLength { get; set; }
        }
        public class FiveParameter
        {
            [Display(Name = "User Password Length")]
            [Required(ErrorMessage = "Please enter a number.")]
            [Range(1, 200, ErrorMessage = "Please enter a number between 1 and 200.")]
            public int UserPasswordLength { get; set; }

            [Display(Name = "Allow Lowercase")]
            public bool UserAllowLowercase { get; set; }

            [Display(Name = "Allow Uppercase")]
            public bool UserAllowUppercase { get; set; }

            [Display(Name = "Allow Numbers")]
            public bool UserAllowNumbers { get; set; }

            [Display(Name = "Allow Special Characters")]
            public bool UserAllowSpecialCharacters { get; set; }
        }
        public class FourParameter
        {
            //between 0 and 255
            [Display(Name = "Uppercase Amount")]
            [Required(ErrorMessage = "Please enter a number.")]
            [Range(0, 255, ErrorMessage = "Please enter a number between 0 and 255.")]
            public byte uppercaseAmount { get; set; }
            [Display(Name = "Lowercase Amount")]
            [Required(ErrorMessage = "Please enter a number.")]
            [Range(0, 255, ErrorMessage = "Please enter a number between 0 and 255.")]
            public byte lowerCaseAmount { get; set; }
            [Display(Name = "Numbers Amount")]
            [Required(ErrorMessage = "Please enter a number.")]
            [Range(0, 255, ErrorMessage = "Please enter a number between 0 and 255.")]
            public byte  numbersAmount { get; set; }
            [Display(Name = "Special characters Amount")]
            [Required(ErrorMessage = "Please enter a number.")]
            [Range(0, 255, ErrorMessage = "Please enter a number between 0 and 255.")]
            public byte specialCharsAmount { get; set; }





        }


    }
}
