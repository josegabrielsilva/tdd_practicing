namespace Poll.Domain.Entities
{
    public sealed class Poll(string description, List<Option> options) : BaseEntity
    {
        public string Description { get; set; } 
            = string.IsNullOrEmpty(description)
                ? throw new ArgumentException("Description is required.", nameof(Description))
                : description;
        public List<Option> Options { get; set; }
            = options is not null && options.Count != 0
            ? options
            : throw new ArgumentException("Empty or null option list is not allowed.", nameof(Options));
    }
}