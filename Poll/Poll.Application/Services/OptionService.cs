using Microsoft.Extensions.Options;
using Poll.Application.Repositories;
using Poll.Application.ViewModels;

namespace Poll.Application.Services
{
    public class OptionService(IOptionRepository repository) : IOptionService
    {
        public async Task<ValidateOptionsResult> AddVote(Guid optionId)
        {
            ValidateOptionsResultBuilder builder = new();

            var option = await repository.ById(optionId);

            if (option is null)
            {
                builder.AddError("Option not found");
            }else
            {
                option?.AddVote();

                await repository.UpdateOption(option);

                builder.AddResult(ValidateOptionsResult.Success);
            }

            return builder.Build();
        }

        public async Task<List<AccuracyResultViewModel>> OptionsByPollId(Guid pollId)
        {
            var result = await repository.ByPollId(pollId);

            return result
                .Select(x => new AccuracyResultViewModel() { Result = $"{x.Description} | {x.Votes}"})
                .ToList();
        }
    }
}