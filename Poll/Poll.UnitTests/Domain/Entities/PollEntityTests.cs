using FluentAssertions;
using Poll.Domain.Entities;

namespace Poll.UnitTests.Domain.Entities
{
    public class PollEntityTests
    {
        private readonly List<Option> OptionCollection =
            [
                new Option ("op1"),
                new Option ("op2"),
                new Option ("op3")
            ];
        
        private const string PollDescription = "Description test";

        [Fact]
        public void WithValidInputs() 
        {
            var poll = new Poll.Domain.Entities.Poll(PollDescription, OptionCollection);

            poll.Should().NotBeNull();
            poll.Description.Should().Be(PollDescription);
            poll.Options.Should().HaveCount(OptionCollection.Count);
        }

        [Fact]
        public void WithInvalidDescription() 
            => ExecuteWithThrowsAssertion("", OptionCollection, "Description is required.");

        [Fact]
        public void WithInvalidOptionCollection() 
            => ExecuteWithThrowsAssertion(PollDescription, [], "Empty or null option list is not allowed.");

        [Fact]
        public void WithInvalidDescriptionAndEmptyOptionCollection()
             => ExecuteWithThrowsAssertion("", [], "Description is required.");

        [Fact]
        public void WithInvalidDescriptionAndNullOptionCollection()
             => ExecuteWithThrowsAssertion("", null, "Description is required.");

        private static void ExecuteWithThrowsAssertion(string description, List<Option> options, string exceptionMessage)
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var poll = new Poll.Domain.Entities.Poll(description, options);
            });

            exception.Message
                .Should()
                .Contain(exceptionMessage);
        }
    }
}