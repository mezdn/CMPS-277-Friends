namespace Friends.Models.Relations
{
    public class GroupMember
    {
        // FK to Person
        public string MemberUsername { get; set; }

        // FK to Group
        public int GroupID { get; set; }
    }
}
