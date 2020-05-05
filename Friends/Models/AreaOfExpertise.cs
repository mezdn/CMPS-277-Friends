using System.ComponentModel.DataAnnotations;

namespace Friends.Models
{
    public class AreaOfExpertise
    {
        public string Name { get; set; }
        
        [Display(Name = "Year Emerged")]
        public int YearEmerged { get; set; }
    }
}
