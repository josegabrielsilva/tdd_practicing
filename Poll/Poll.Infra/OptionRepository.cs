using Dapper;
using Poll.Application.Repositories;
using Poll.Domain.Entities;
using Poll.Infra.Contracts;

namespace Poll.Infra
{
    public class OptionRepository (DbSession session) : IOptionRepository
    {
        public async Task<List<Option>> ByPollId(Guid pollId)
        {
            const string query = @"SELECT
	                ops.Description,
	                ops.Votes
                FROM Options ops
                INNER JOIN Poll p ON ops.PollId = p.Id
                WHERE p.Id = @pollId";

            var result = await session.Connection.QueryAsync<OptionFromDb>(query, new { pollId });

            return result is not null
                ? result.Select(op => new Option(op.Description)
                        {
                            Id = op.Id,
                            Votes = op.Votes,
                        }).ToList()
                : [];
        }

        public async Task<Option?> ById(Guid id)
        {
            const string query = @"SELECT * FROM Options WHERE Id = @Id";

            var result = await session.Connection.QueryFirstAsync<OptionFromDb>(query, new { id });

            return result is not null 
                ? new Option(result.Description)
                    { 
                        Id = result.Id,
                        Votes = result.Votes,
                    }
                : null;
        }
        
        public async Task<int> UpdateOption(Option option)
        {
            const string query = @"
                    UPDATE Options 
                    SET Description = @Description, Votes = @Votes 
                    WHERE Id = @Id";

            return await session.Connection.ExecuteAsync(query, 
                new { 
                    option.Description, 
                    option.Votes,
                    option.Id
                });
        }
    }
}