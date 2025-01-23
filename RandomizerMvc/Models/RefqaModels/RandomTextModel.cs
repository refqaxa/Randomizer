using System;
using System.ComponentModel.DataAnnotations;

namespace RandomizerMvc.Models.RefqaModels
{
    public class RandomTextModel
    {
        [Display(Name = "Hoeveel paragrafen wil je?")]
        [Required(ErrorMessage = "Vul een geldige waarde in")]
        public int ParagraphsAmount { get; set; }

        [Display(Name = "In Nederlands?")]
        [Required(ErrorMessage = "Vul een geldige waarde in")]
        public bool InDutch { get; set; }

        [Display(Name = "Wil je het als HTML?")]
        [Required(ErrorMessage = "Vul een geldige waarde in")]
        public bool AsHtml { get; set; }

    }

}
