using System.Threading.Tasks;

using mvc.vuejs.infrastructure.Context;
using mvc.vuejs.infrastructure.Entities;

namespace mvc.vuejs.infrastructure.Commands.Games
{
    public class CreateGame
    {
        public class Command : ICommand
        {
            public Game Game { get; set; }
        }

        public class Validator : ICommandValidator<Command>
        {
            public void Validate(Command command)
            {
                if (string.IsNullOrEmpty(command.Game.Name))
                    throw new CommandValidationException("You must specify a game name!");

                if (string.IsNullOrEmpty(command.Game.Description))
                    throw new CommandValidationException("You must specify a game description!");
            }
        }

        public class Handler : ICommandHandlerAsync<Command>, ICommandHandler<Command>
        {
            public void Execute(Command command)
            {
                using (var ctx = new GameContext())
                {
                    ctx.Games.Add(command.Game);
                    ctx.SaveChanges();
                }
            }

            public async Task ExecuteAsync(Command command)
            {
                using (var ctx = new GameContext())
                {
                    ctx.Games.Add(command.Game);
                    await ctx.SaveChangesAsync();
                }
            }
        }
    }
}
