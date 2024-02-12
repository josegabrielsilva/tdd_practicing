using FluentAssertions;

namespace Poll.UnitTests.Domain.Entities
{
    public class OptionEntityTests
    {
        private const string OptionDescription = "Description test";

        [Fact]
        public void WithValidInputs()
        {
            var option = new Poll.Domain.Entities.Option(OptionDescription);

            option.Should().NotBeNull();
            option.Description.Should().Be(OptionDescription);
            option.Votes.Should().Be(0);
        }

        [Fact]
        public void WithInvalidDescription()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var poll = new Poll.Domain.Entities.Option("");
            });

            exception.Message
                .Should()
                .Contain("Description is required.");
        }
    }
}