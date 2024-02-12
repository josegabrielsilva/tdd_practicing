using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using Moq.AutoMock;
using Poll.Application.Repositories;
using Poll.Application.Services;

namespace Poll.UnitTests.Application
{
    public class OptionServiceTests
    {
        private readonly AutoMocker Mocker = new ();

        private void MakeSetup(bool withOption = true)
        {
            Mocker
                .GetMock<IOptionRepository>()
                .Setup(method => method.ById(It.IsAny<Guid>()))
                .ReturnsAsync(withOption 
                    ? new Poll.Domain.Entities.Option("CLT")
                    : null);
        }

        [Fact]
        public async Task WhenOptionExistsShouldBeSuccess()
        {
            MakeSetup();

            var optionService = Mocker.CreateInstance<OptionService>();

            var result = await optionService.AddVote(Guid.NewGuid());
                
            result
                .Should()
                .BeOfType<ValidateOptionsResult>();

            result
                .Succeeded
                .Should()
                .BeTrue();
        }

        [Fact]
        public async Task WhenOptionNotExistsShouldBeFail()
        {
            MakeSetup(withOption: false);

            var optionService = Mocker.CreateInstance<OptionService>();

            var result = await optionService.AddVote(Guid.NewGuid());

            result
                .Should()
                .BeOfType<ValidateOptionsResult>();

            result
                .Failed
                .Should()
                .BeTrue();

            result
                .FailureMessage
                .Should()
                .Be("Option not found");
        }
    }
}