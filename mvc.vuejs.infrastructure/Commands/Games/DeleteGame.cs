using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;

using mvc.vuejs.infrastructure.Context;

namespace mvc.vuejs.infrastructure.Commands.Games
{
    public class DeleteGame
    {
        public class Command : ICommand
        {
            public int Id { get; set; }
        }

        public class Validator : ICommandValidator<Command>
        {
            public void Validate(Command command)
            {
                using (var ctx = new GameContext())
                {
                    if (!ctx.Games.Where(g => g.Id == command.Id).Any())
                        throw new CommandValidationException("Game doesn't exist!");
                }
            }
        }

        public class Handler : ICommandHandler<Command>, ICommandHandlerAsync<Command>
        {
            public void Execute(Command command)
            {
                using (var ctx = new GameContext())
                {
                    var game = ctx.Games.Where(g => g.Id == command.Id).FirstOrDefault();
                    ctx.Games.Remove(game);
                    ctx.SaveChanges();
                }
            }

            public async Task ExecuteAsync(Command command)
            {
                using (var ctx = new GameContext())
                {
                    var game = await ctx.Games.Where(g => g.Id == command.Id).FirstOrDefaultAsync();
                    ctx.Games.Remove(game);
                    ctx.SaveChanges();
                }
            }
        }
    }
}
