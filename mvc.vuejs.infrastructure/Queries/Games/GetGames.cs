using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Collections.Generic;

using mvc.vuejs.infrastructure.Context;
using mvc.vuejs.infrastructure.Entities;

namespace mvc.vuejs.infrastructure.Queries.Games
{
    public class GetGames
    {
        public class Query : IQuery { }

        public class Result : IQueryResult
        {
            public List<Game> Games { get; set; } = new List<Game>();
        }

        public class Handler : IQueryHandler<Query, Result>, IQueryHandlerAsync<Query, Result>
        {
            public Result Retrieve(Query query)
            {
                using (var ctx = new GameContext())
                {
                    return new Result
                    {
                        Games = ctx.Games.ToList()
                    };
                }
            }

            public async Task<Result> RetrieveAsync(Query query)
            {
                using (var ctx = new GameContext())
                {
                    return new Result
                    {
                        Games = await ctx.Games.ToListAsync()
                    };
                }
            }
        }
    }
}
