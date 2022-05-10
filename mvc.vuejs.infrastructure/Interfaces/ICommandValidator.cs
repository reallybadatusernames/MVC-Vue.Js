using System.Threading.Tasks;

namespace mvc.vuejs.infrastructure
{
    interface ICommandValidator<in TCommand>
    {
        void Validate(TCommand command);
    }

    interface ICommandValidatorAsync<in TCommand>
    {
        Task ValidateAsync(TCommand command);
    }
}
