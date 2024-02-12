namespace Poll.Domain.Entities
{
    public sealed class Option (string description) : BaseEntity
    {
        public string Description { get; set; }
            = !string.IsNullOrEmpty(description)
                ? description
                : throw new ArgumentException("Description is required.");
        public int Votes { get; set; } = 0;

        public int AddVote()
        {
            Votes++;
            return Votes;
        }
    }
}