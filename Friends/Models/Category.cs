namespace Friends.Models
{
    public class Category
    {
        public int ID { get; set; }

        public string Name { get; set; }

        // FK to Area of Expertise
        public string AreaOfExpertiseName { get; set; }
    }
}
