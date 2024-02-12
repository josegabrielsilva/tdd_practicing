using Poll.Domain.Entities;

namespace Poll.Application.Repositories
{
    public interface IOptionRepository
    {
        Task<Option?> ById(Guid id);
        Task<int> UpdateOption(Option option);
        Task<List<Option>> ByPollId(Guid pollId);
    }
}