namespace Friends.Models.Relations
{
    public class AreFriends
    {
        // FK to Person
        public string PersonUsernameA { get; set; }

        // FK to Person
        public string PersonUsernameB { get; set; }
    }
}
