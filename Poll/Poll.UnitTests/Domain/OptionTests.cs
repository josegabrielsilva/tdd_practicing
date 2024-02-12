using FluentAssertions;
using Poll.Domain.Entities;

namespace Poll.UnitTests.Domain
{
    public class OptionTests
    {
        private readonly Poll.Domain.Entities.Poll poll;

        private readonly Guid FirstOptionId = Guid.NewGuid();
        private readonly Guid SecondOptionId = Guid.NewGuid();

        public OptionTests()
        {
            poll = new Poll.Domain.Entities.Poll(
                    description: "Qual seu regime de contratação?",
                    options:
                        [
                            new Option("CLT") { Id = FirstOptionId },
                            new Option("CLT") { Id = SecondOptionId }
                        ]
                );
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(0)]
        public void WhenOptionIsCreated(int quantityOfVotes)
        {
            var pollSearched = poll.Options
                .Where(op => op.Id == FirstOptionId)
                .First();

            for (var i = 1; i <= quantityOfVotes; i++)
                pollSearched.AddVote();

            pollSearched.Votes.Should().Be(quantityOfVotes);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(0)]
        public void WhenOptionAlreadyVoted(int quantityOfVotes)
        {
            var pollSearched = poll.Options
                .Where(op => op.Id == FirstOptionId)
                .First();

            pollSearched.AddVote();

            for (var i = 1; i <= quantityOfVotes; i++)
                pollSearched.AddVote();

            pollSearched.Votes.Should().Be(quantityOfVotes + 1);
        }
    }
}