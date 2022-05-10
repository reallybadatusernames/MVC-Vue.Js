using System.Threading.Tasks;

namespace mvc.vuejs.infrastructure
{
    interface IQueryValidator<in TQuery>
    {
        void Validate(TQuery query);
    }

    interface IQueryValidatorAsync<in TQuery>
    {
        Task ValidateAsync(TQuery query);
    }
}
