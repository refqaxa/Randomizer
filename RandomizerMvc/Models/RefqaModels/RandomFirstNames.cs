using System;
using System.ComponentModel.DataAnnotations;

namespace RandomizerMvc.Models.RefqaModels
{
    public class RandomFirstNames
    {
        public bool IncludeBoysNames { get; set; }
        public bool IncludeGirlsNames { get; set; }
        public int NumberOfNames { get; set; }

    }

}
