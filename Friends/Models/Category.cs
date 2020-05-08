namespace Friends.Models
{
    public class Category
    {
        public string Name { get; set; }

        // FK to Area of Expertise
        public string AreaOfExpertiseName { get; set; }
    }
}
