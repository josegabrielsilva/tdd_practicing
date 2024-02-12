using Microsoft.Extensions.Options;
using Poll.Application.ViewModels;
using Poll.Domain.Entities;

namespace Poll.Application.Services
{
    public interface IOptionService
    {
        Task<ValidateOptionsResult> AddVote(Guid optionId);
        Task<List<AccuracyResultViewModel>> OptionsByPollId(Guid pollId);
    }
}