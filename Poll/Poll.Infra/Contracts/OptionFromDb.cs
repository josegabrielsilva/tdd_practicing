namespace Poll.Infra.Contracts
{
    public class OptionFromDb
    {
        public Guid Id { get; set; }
        public string Description { get;set; }
        public int Votes { get; set; }
    }
}